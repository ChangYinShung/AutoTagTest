using FS.Entity.EntityFeatures;
using FS.Entity.MultiLinguals;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.CmsKit.Blogs;

namespace FS.CmsKitManagement.Blogs
{
    public class BlogsAppService : CmsKitManagementAppService
    {
        private readonly EntityFeaturesOptions entityFeaturesOptions;
        private readonly IMultiLingualsStore multiLingualsStore;
        private readonly IBlogRepository blogRepository;

        public BlogsAppService(
            IOptions<FS.Entity.EntityFeatures.EntityFeaturesOptions> entityFeaturesOptions,
            FS.Entity.MultiLinguals.IMultiLingualsStore multiLingualsStore,
            Volo.CmsKit.Blogs.IBlogRepository blogRepository
            )
        {
            this.entityFeaturesOptions=entityFeaturesOptions.Value;
            this.multiLingualsStore=multiLingualsStore;
            this.blogRepository=blogRepository;
        }
        public async Task<Volo.CmsKit.Admin.Blogs.BlogDto> FindBlogWithMultiLingualsAsync(Guid blogId, string culture)
        {
            var blog = await blogRepository.FindAsync(blogId, false);

            var dto = ObjectMapper.Map<Blog, Volo.CmsKit.Admin.Blogs.BlogDto>(blog);

            var multiLingual = await multiLingualsStore.MultiLingual.FindByAsync(blog);

            var translation = multiLingual.GetOrDefaultLingualTranslation(entityFeaturesOptions, blog, culture);

            ObjectMapper.Map(translation, dto);

            return dto;

        }

    }
}
