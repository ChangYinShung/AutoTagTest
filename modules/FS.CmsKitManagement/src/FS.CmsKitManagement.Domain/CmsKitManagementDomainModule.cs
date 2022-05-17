using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.CmsKit.Blogs;
using Volo.CmsKit.Menus;
using Volo.CmsKit.Pages;
using FS.Entity.MultiLinguals;
using FS.Entity.EntityFeatures;
using Volo.Abp.GlobalFeatures;
using Volo.CmsKit.GlobalFeatures;
using Volo.CmsKit.MediaDescriptors;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Events.Distributed;
using FS.CmsKit.ContentEntities;
using FS.CmsKit.ContentEntities.Events;

namespace FS.CmsKitManagement
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(CmsKitManagementDomainSharedModule)
    )]
    [DependsOn(typeof(EasyAbp.Abp.Trees.AbpTreesDomainModule))]
    [DependsOn(typeof(Volo.CmsKit.CmsKitDomainModule))]
    [DependsOn(typeof(FS.Abp.Settings.SettingsDomainModule))]
    [DependsOn(typeof(FS.Entity.MultiLinguals.MultiLingualsDomainModule))]
    [DependsOn(
        typeof(FS.CmsKit.ContentDefinitions.ContentDefinitionsDomainModule),
        typeof(FS.CmsKit.ContentComposites.ContentCompositesDomainModule)
        )]
    [DependsOn(typeof(FS.CmsKit.CmsKitDomainModule))]
    public class CmsKitManagementDomainModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<EntityFeaturesOptions>(options =>
            {
                options.GetOrAdd<MultiLingual>(a =>
                {
                    a.AddOrReplace<Page>(
                        MultiLingualsEntityFeatureDefinition.Default<Page, PageTranslation>());

                    a.AddOrReplace<Blog>(
                        MultiLingualsEntityFeatureDefinition.Default<Blog, BlogTranslation>());

                    a.AddOrReplace<BlogPost>(
                        MultiLingualsEntityFeatureDefinition.Default<BlogPost, BlogPostTranslation>());

                    a.AddOrReplace<MenuItem>(
                        MultiLingualsEntityFeatureDefinition.Default<MenuItem, MenuItemTranslation>());
                });

                options.GetOrAdd<FS.CmsKit.EntityMedias.EntityMedia>(a =>
                {
                    a.AddOrReplace<Page>();

                    a.AddOrReplace<Blog>();

                    a.AddOrReplace<BlogPost>();
                });

                //options.GetOrAdd<FS.CmsKit.ContentDefinitions.ContentTypeDefinition>(d =>
                //{
                //    d.AddOrReplace<Page>();
                //});

                //options.GetOrAdd<FS.CmsKit.ContentEntities.ContentEntity>(d =>
                //{
                //    d.AddOrReplace<Page>();

                //    d.AddOrReplace<Blog>();

                //    d.AddOrReplace<BlogPost>();

                //    d.AddOrReplace<MediaDescriptor>();
                //});

            });
        }
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDistributedEntityEventOptions>(options =>
            {
                options.AutoEventSelectors.Add<ContentEntity>();
                options.EtoMappings.Add<ContentEntity, ContentEntityEto>();
            });

            ConfigureCmsKitOptions();

        }
        private void ConfigureCmsKitOptions()
        {
            if (GlobalFeatureManager.Instance.IsEnabled<MediaFeature>())
            {
                Configure<CmsKitMediaOptions>(options =>
                {
                    options.EntityTypes.AddIfNotContains(
                        new MediaDescriptorDefinition(
                            "Volo.CmsKit.Blogs.Blog"));

                    options.EntityTypes.AddIfNotContains(
                        new MediaDescriptorDefinition(
                            "Volo.CmsKit.Blogs.BlogPost"));

                    options.EntityTypes.AddIfNotContains(
                        new MediaDescriptorDefinition(
                            "Volo.CmsKit.Pages.Page"));
                });
            }
        }
    }


}
