using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace FS.CmsKitManagement
{
    [DependsOn(
        typeof(CmsKitManagementDomainModule),
        typeof(CmsKitManagementApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    [DependsOn(typeof(Volo.CmsKit.CmsKitApplicationModule))]
    [DependsOn(
        typeof(FS.CmsKit.ContentDefinitions.ContentDefinitionsApplicationModule),
        typeof(FS.CmsKit.ContentComposites.ContentCompositesApplicationModule)
        )]
    public class CmsKitManagementApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<CmsKitManagementApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<CmsKitManagementApplicationModule>(validate: false);
            });

            //Configure<EntityDefinitionOptions>(o =>
            //{
            //    o.GetOrAdd<Volo.CmsKit.Admin.Blogs.BlogAdminAppService>(
            //        a => { },
            //        (t) => EntityDefinition.CreateByAttribute<Volo.CmsKit.Admin.Blogs.BlogAdminAppService>());

            //    //o.GetOrAdd<Volo.CmsKit.Blogs.Blog>(
            //    //    a => { },
            //    //    (t) => DefaultEntityDefinition.Create<
            //    //        Volo.CmsKit.Admin.Blogs.BlogAdminAppService, 
            //    //        Volo.CmsKit.Blogs.Blog,
            //    //        Volo.CmsKit.Admin.Blogs.BlogGetListInput,
            //    //        Volo.CmsKit.Admin.Blogs.CreateBlogDto>());

            //    //o.GetOrAdd<Volo.CmsKit.Blogs.BlogPost>(
            //    //    a => { },
            //    //    (t) => DefaultEntityDefinition.Create<
            //    //        Volo.CmsKit.Admin.Blogs.BlogPostAdminAppService,
            //    //        Volo.CmsKit.Blogs.BlogPost,
            //    //        Volo.CmsKit.Admin.Blogs.BlogPostGetListInput,
            //    //        Volo.CmsKit.Admin.Blogs.CreateBlogPostDto>());

            //    //o.GetOrAdd<Volo.CmsKit.Tags.Tag>(
            //    //    a => { },
            //    //    (t) => DefaultEntityDefinition.Create<
            //    //        Volo.CmsKit.Admin.Tags.TagAdminAppService,
            //    //        Volo.CmsKit.Tags.Tag,
            //    //        Volo.CmsKit.Admin.Tags.TagGetListInput,
            //    //        Volo.CmsKit.Admin.Tags.TagCreateDto>());

            //    //o.GetOrAdd<Volo.CmsKit.Pages.Page>(
            //    //    a => { },
            //    //    (t) => DefaultEntityDefinition.Create<
            //    //        Volo.CmsKit.Admin.Pages.PageAdminAppService,
            //    //        Volo.CmsKit.Pages.Page, 
            //    //        Volo.CmsKit.Admin.Pages.GetPagesInputDto,
            //    //        Volo.CmsKit.Admin.Pages.CreatePageInputDto>());
            //});
        }

    }
}
