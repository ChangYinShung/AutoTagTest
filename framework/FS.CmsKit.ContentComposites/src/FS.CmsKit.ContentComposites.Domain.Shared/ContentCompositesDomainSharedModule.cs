using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using FS.CmsKit.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace FS.CmsKit.ContentComposites;

[DependsOn(typeof(FS.CmsKit.CmsKitDomainSharedModule))]
[DependsOn(typeof(FS.Abp.JsonSubTypes.JsonSubTypesCoreModule))]
public class ContentCompositesDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ContentCompositesDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CmsKitResource>()
                .AddVirtualJson("/Localization/ContentComposites");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("ContentComposites", typeof(CmsKitResource));
        });
    }
}
