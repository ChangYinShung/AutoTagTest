﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating AbpSettings.
// 4.4.4
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using FS.CmsKitManagement.Blogs.Dtos;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace FS.CmsKitManagement.Blogs
{
    public partial class BlogPostSettingAppService : ApplicationService, IBlogPostSettingAppService // auto-generated
    {
        protected BlogPostSettingFactory Factory => this.LazyServiceProvider.LazyGetRequiredService<BlogPostSettingFactory>();

        public async Task<BlogPostSettingDto> GetAsync(string providerName = null, string providerKey = null, bool fallback = true)
        {
            BlogPostSettingDto result = new BlogPostSettingDto();
            return ObjectMapper.Map(await Factory.GetAsync(providerName,providerKey,fallback), result);
        }

        public async Task UpdateAsync(BlogPostSettingDto input, string providerName = null, string providerKey = null)
        {
            var domain = new BlogPostSetting();

            ObjectMapper.Map(input, domain);

            await Factory.SetAsync(domain, providerName, providerKey);

        }
    }
}
