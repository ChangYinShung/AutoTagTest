using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using FS.EcPay.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace FS.EcPay;

[DependsOn(
    typeof(AbpValidationModule)
)]
[DependsOn(typeof(FS.EcPay.HttpClient.EcPayHttpClientCoreModule))]
public class EcPayDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<EcPayDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<EcPayResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/EcPay");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("EcPay", typeof(EcPayResource));
        });
    }
}
