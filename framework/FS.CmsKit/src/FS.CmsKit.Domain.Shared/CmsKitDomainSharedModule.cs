using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using FS.CmsKit.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace FS.CmsKit;

[DependsOn(
    typeof(AbpValidationModule)
)]
[DependsOn(typeof(FS.CmsKit.CmsKitCoreModule))]
public class CmsKitDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CmsKitDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<CmsKitResource>("en")
                //.AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/CmsKit");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("CmsKit", typeof(CmsKitResource));
        });
    }
}
