using FS.CmsKit.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FS.CmsKitManagement
{
    [DependsOn(typeof(FS.Abp.Npoi.Mapper.AbpNpoiMapperCoreModule))]
    [DependsOn(typeof(Volo.CmsKit.CmsKitDomainSharedModule))]
    [DependsOn(typeof(FS.Abp.Data.AbpDataCoreModule))]
    [DependsOn(typeof(FS.Abp.AutoFilterer.AbpAutoFiltererCoreModule))]
    [DependsOn(typeof(FS.Entity.EntityFeatures.EntityFeaturesCoreModule))]
    [DependsOn(
        typeof(FS.CmsKit.ContentDefinitions.ContentDefinitionsDomainSharedModule),
        typeof(FS.CmsKit.ContentComposites.ContentCompositesDomainSharedModule)
        )]
    [DependsOn(typeof(FS.Abp.AutoFilterer.AbpAutoFiltererCoreModule))]
    public class CmsKitManagementDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            CmsKitManagementGlobalFeatureConfigurator.Configure();
            CmsKitManagementModuleExtensionConfigurator.Configure();
        }
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CmsKitManagementDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<CmsKitResource>()
                    .AddVirtualJson("/Localization/CmsKitManagement");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("CmsKitManagement", typeof(CmsKitResource));
            });
        }
    }
}
