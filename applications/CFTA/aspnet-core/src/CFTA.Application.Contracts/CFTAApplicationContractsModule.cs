using Volo.Abp.Account;
using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.LanguageManagement;
using Volo.Abp.LeptonTheme.Management;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.Saas.Host;
using Volo.CmsKit;
using Volo.FileManagement;

namespace CFTA;

[DependsOn(
    typeof(CFTADomainSharedModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(SaasHostApplicationContractsModule),
    typeof(AbpAuditLoggingApplicationContractsModule),
    typeof(AbpIdentityServerApplicationContractsModule),
    typeof(AbpAccountPublicApplicationContractsModule),
    typeof(AbpAccountAdminApplicationContractsModule),
    typeof(LanguageManagementApplicationContractsModule),
    typeof(LeptonThemeManagementApplicationContractsModule),
    typeof(CmsKitProApplicationContractsModule),
    typeof(TextTemplateManagementApplicationContractsModule)
)]
[DependsOn(typeof(FileManagementApplicationContractsModule))]
[DependsOn(
    typeof(FS.CmsKitManagement.CmsKitManagementApplicationContractsModule),
    typeof(FS.EntityManagement.EntityManagementApplicationContractsModule),
    typeof(FS.EShopManagement.EShopManagementApplicationContractsModule),
    typeof(FS.FormManagement.FormManagementApplicationContractsModule)
    )]
[DependsOn(typeof(Volo.Payment.Admin.AbpPaymentAdminApplicationContractsModule))]
[DependsOn(
    typeof(EasyAbp.PaymentService.PaymentServiceApplicationContractsModule)
    )]
public class CFTAApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        CFTADtoExtensions.Configure();
    }
}
