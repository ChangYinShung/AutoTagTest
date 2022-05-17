using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using FS.EShopManagement.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace FS.EShopManagement;

[DependsOn(
    typeof(AbpValidationModule)
)]
[DependsOn(typeof(EasyAbp.EShop.Orders.EShopOrdersDomainSharedModule))]
[DependsOn(typeof(FS.EShopManagement.EShopManagementCoreModule))]
public class EShopManagementDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<EShopManagementDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<EShopManagementResource>("en")
                //.AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/EShopManagement");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("EShopManagement", typeof(EShopManagementResource));
        });
    }
}
