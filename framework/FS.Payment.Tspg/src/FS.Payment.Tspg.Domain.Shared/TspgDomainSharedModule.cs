using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using FS.Payment.Tspg.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using FS.Tspg;

namespace FS.Payment.Tspg;

[DependsOn(
    typeof(AbpValidationModule)
)]
[DependsOn(typeof(TspgCoreModule))]
public class TspgDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<TspgDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<TspgResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/Tspg");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Tspg", typeof(TspgResource));
        });
    }
}
