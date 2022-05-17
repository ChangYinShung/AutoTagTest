using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using FS.Social.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace FS.SocialManagement;

[DependsOn(
    typeof(FS.Social.SocialDomainSharedModule)
)]
public class SocialManagementDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SocialManagementDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<SocialResource>()
                .AddVirtualJson("/Localization/SocialManagement");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("SocialManagement", typeof(SocialResource));
        });
    }
}
