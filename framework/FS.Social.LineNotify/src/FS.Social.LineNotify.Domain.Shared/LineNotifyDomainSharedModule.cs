using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using FS.Social.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace FS.Social.LineNotify;

[DependsOn(typeof(FS.Social.SocialDomainSharedModule))]
public class LineNotifyDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<LineNotifyDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<SocialResource>()
                //.AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/LineNotify");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("LineNotify", typeof(SocialResource));
        });
    }
}
