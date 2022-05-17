﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating AbpSettings.
// 4.4.4
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using Volo.Abp.Domain.Services;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using FS.Abp.Settings;
using Volo.Abp.Localization;
using Volo.Abp.Settings;
using Volo.Abp.SettingManagement;
using FS.CmsKitManagement.Localization;
using System.Collections.Generic;
using System;

namespace FS.CmsKitManagement.Blogs
{
    public partial class CmsKitManagementSettingNames
    {
        public partial class BlogPostSetting
        {
            private const string Prefix = "FS.CmsKitManagement.Blogs.BlogPostSetting";
            public const string DefaultCoverImage = Prefix + ".DefaultCoverImage";
        }
    }
    public partial class BlogPostSettingSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                        new SettingDefinition(CmsKitManagementSettingNames.BlogPostSetting.DefaultCoverImage, @"", L("DisplayName:BlogPostSetting.DefaultCoverImage"), L("Description:BlogPostSetting.DefaultCoverImage"), false).WithProperty("Type","String")
                        );
        }
        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CmsKitManagementResource>(name);
        }
    }
    public partial class BlogPostSettingFactory : Factory<BlogPostSetting>
    {
        public override async Task<BlogPostSetting> GetAsync(string providerName = null, string providerKey = null, bool fallback = true)
        {
            var result = new BlogPostSetting();
            result.DefaultCoverImage = await this.TryGetAsync(CmsKitManagementSettingNames.BlogPostSetting.DefaultCoverImage, providerName, providerKey, fallback);
            return result;
        }

        public override async Task SetAsync(BlogPostSetting input, string providerName, string providerKey, bool forceToSet = false)
        {
            await this.TrySetAsync(CmsKitManagementSettingNames.BlogPostSetting.DefaultCoverImage, input.DefaultCoverImage.ToString(), providerName, providerKey, forceToSet);
        }
    }
}
