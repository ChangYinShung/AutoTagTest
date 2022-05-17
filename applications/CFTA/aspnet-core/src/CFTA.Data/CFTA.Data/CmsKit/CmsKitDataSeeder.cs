using FS.Abp.Npoi.Mapper;
using FS.CmsKit.EntityMedias;
using FS.Entity.EntityFeatures;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;
using Volo.Abp.VirtualFileSystem;
using Volo.CmsKit.Admin.Blogs;
using Volo.CmsKit.Admin.MediaDescriptors;
using Volo.CmsKit.Admin.Menus;
using Volo.CmsKit.Admin.Pages;
using Volo.CmsKit.Blogs;
using Volo.CmsKit.MediaDescriptors;
using Volo.CmsKit.Pages;

namespace CFTA.Data.CmsKit
{
    public class CmsKitDataSeeder : DomainService
    {
        private const string EntityTypeBlogPost = "BlogPost";

        private VirtualFileNpoiReader virtualFileNpoiReader => this.LazyServiceProvider.LazyGetRequiredService<VirtualFileNpoiReader>();
        private IVirtualFileProvider virtualFileProvider => this.LazyServiceProvider.LazyGetRequiredService<IVirtualFileProvider>();

        private DataService dataService => this.LazyServiceProvider.LazyGetRequiredService<DataService>();

        private IBlogAdminAppService BlogAdminAppService => this.LazyServiceProvider.LazyGetRequiredService<IBlogAdminAppService>();
        private IBlogPostAdminAppService BlogPostAdminAppService => this.LazyServiceProvider.LazyGetRequiredService<IBlogPostAdminAppService>();

        private IPageAdminAppService PageAdminAppService => this.LazyServiceProvider.LazyGetRequiredService<IPageAdminAppService>();
        private IMenuItemAdminAppService MenuItemAdminAppService => this.LazyServiceProvider.LazyGetRequiredService<IMenuItemAdminAppService>();

        private IBlogRepository BlogRepository => this.LazyServiceProvider.LazyGetRequiredService<IBlogRepository>();
        private IPageRepository PageRepository => this.LazyServiceProvider.LazyGetRequiredService<IPageRepository>();

        private FS.Entity.EntityFeatures.EntityFeaturesOptions EntityFeaturesOptions => this.LazyServiceProvider.LazyGetRequiredService<IOptions<FS.Entity.EntityFeatures.EntityFeaturesOptions>>().Value;
        private IEntityMediaRepository EntityMediaRepository => this.LazyServiceProvider.LazyGetRequiredService<IEntityMediaRepository>();

        /// <summary>
        /// 建立 Blog, BlogPost
        /// </summary>
        public async Task CreateBlogAndBlogPostAsync()
        {
            var hasDatas = await this.BlogRepository.GetCountAsync() > 0;
            if (hasDatas) return;

            var blogs = this.virtualFileNpoiReader.Read<Files.CmsKit.Blog>();
            var blogPosts = this.virtualFileNpoiReader.Read<Files.CmsKit.BlogPost>();

            var filesPath = $"Files/CmsKit/CoverImage";
            var files = this.virtualFileProvider.GetDirectoryContents(filesPath).ToList();

            var mediaDescriptors = await this.dataService.CreateMediaDesciptorsAsync(EntityTypeBlogPost, files);

            await blogs.ForEachAsync(async (blog) =>
            {
                var blogItem = await this.BlogAdminAppService.CreateAsync(new CreateBlogDto()
                {
                    Name = blog.Name,
                    Slug = blog.Slug
                });

                var posts = blogPosts.Where(x => x.BlogSlug == blog.Slug).ToList();
                await posts.ForEachAsync(async (post) =>
                {
                    var media = mediaDescriptors.SingleOrDefault(x => x.Name == post.CoverImageName);

                    var postItem = new CreateBlogPostDto()
                    {
                        BlogId = blogItem.Id,
                        Title = post.Title,
                        Slug = post.Slug,
                        Content = post.Content,
                        ShortDescription = post.ShortDescription ?? "",
                        CoverImageMediaId = media?.Id
                    };

                    await this.BlogPostAdminAppService.CreateAsync(postItem);
                });
            });
        }

        /// <summary>
        /// 建立 Page, CmsMenuItem
        /// </summary>
        public async Task CreatePageAndMenuAsync()
        {
            var hasDatas = await this.PageRepository.GetCountAsync() > 0;
            if (hasDatas) return;

            var pages = await createPagesAsync();

            await createMenusAsync(pages);

            async Task<List<PageDto>> createPagesAsync()
            {
                var pages = this.virtualFileNpoiReader.Read<Files.CmsKit.Page>();
                var result = new List<PageDto>();

                await pages.ForEachAsync(async (page) =>
                {
                    var newPage = await this.PageAdminAppService.CreateAsync(new CreatePageInputDto()
                    {
                        Title = page.Title,
                        Slug = page.Slug,
                        Content = page.Content,
                        Script = null,
                        Style = null
                    });

                    result.Add(newPage);
                });

                return result;
            }
            async Task createMenusAsync(List<PageDto> pages)
            {
                var menus = this.virtualFileNpoiReader.ReadToTreeNode<Files.CmsKit.MenuItem>();
                await createMenuChildrenAsync(null, menus, pages);
            }

            async Task createMenuChildrenAsync(Guid? parentId, List<Files.CmsKit.MenuItem> menus, List<PageDto> pages)
            {
                var i = 0;
                await menus.ForEachAsync(async (menuItem) =>
                {
                    var findPage = pages.SingleOrDefault(x => x.Slug == menuItem.PageSlug);

                    try
                    {
                        var newMenu = await this.MenuItemAdminAppService.CreateAsync(new MenuItemCreateInput()
                        {
                            ParentId = parentId,
                            DisplayName = menuItem.DisplayName,
                            IsActive = true,
                            Url = menuItem.Url,
                            Icon = menuItem.Icon,
                            Order = i,
                            Target = menuItem.Target,
                            ElementId = null,
                            CssClass = null,
                            PageId = findPage?.Id
                        });

                        await createMenuChildrenAsync(newMenu.Id, menuItem.Children, pages);
                    }
                    catch (Exception ex)
                    {

                    }
                    

                    i++;
                });
            }
        }

        /// <summary>
        /// 建立 EntityMedia, EntityMediaGroup
        /// 若 Excel 資料無對應，則不建立 EntityMediaGroup
        /// </summary>
        public async Task CreateEntityMediasAsync()
        {
            var entityMediaOption = EntityFeaturesOptions.SingleOrDefault(x => x.Key == typeof(EntityMedia));
            if (entityMediaOption.Equals(default(KeyValuePair<Type, EntityFeatureDefinitions>))) return;

            var existEntityMedias = await this.EntityMediaRepository.GetListAsync();

            var entityTypes = entityMediaOption.Value
                .ToDictionary(x => x.Key, x => x.Value)
                .ToList();
            var entityMediaGroups = this.virtualFileNpoiReader.Read<Files.CmsKit.EntityMediaGroup>();

            var entityMedias = new List<EntityMedia>();
            entityTypes.ForEach((entityType) =>
            {
                // Entity Media 未建立者才建立資料
                var existData = existEntityMedias.FindIndex(x => x.EntityType == entityType.Key.FullName);
                if (existData != -1) return;

                var entityMedia = new EntityMedia()
                {
                    EntityType = entityType.Key.FullName,
                    TenantId = this.CurrentTenant.Id,
                    EntityMediaGroups = entityMediaGroups
                        .Where(x => x.EntityType == entityType.Key.FullName)
                        .Select(x => {
                            var entity = new EntityMediaGroup()
                            {
                                Name = x.Name,
                                MediaType = x.MediaType,
                                TenantId = this.CurrentTenant.Id
                            };
                            EntityHelper.TrySetId(entity, this.GuidGenerator.Create);

                            return entity;
                        })
                        .ToList()
                };

                entityMedias.Add(entityMedia);
            });

            await this.EntityMediaRepository.InsertManyAsync(entityMedias);
        }
    }
}
