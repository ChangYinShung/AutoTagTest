using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using FS.Social.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace FS.Social;

[DependsOn(
    typeof(AbpValidationModule)
)]
public class SocialDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SocialDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<SocialResource>("en")
                //.AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/Social");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Social", typeof(SocialResource));
        });
    }
}
