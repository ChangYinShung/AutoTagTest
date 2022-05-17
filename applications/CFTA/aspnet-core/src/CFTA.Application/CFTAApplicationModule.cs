using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Account;
using Volo.Abp.AuditLogging;
using Volo.Abp.AutoMapper;
using Volo.Abp.Emailing;
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
    typeof(CFTADomainModule),
    typeof(CFTAApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(SaasHostApplicationModule),
    typeof(AbpAuditLoggingApplicationModule),
    typeof(AbpIdentityServerApplicationModule),
    typeof(AbpAccountPublicApplicationModule),
    typeof(AbpAccountAdminApplicationModule),
    typeof(LanguageManagementApplicationModule),
    typeof(LeptonThemeManagementApplicationModule),
    typeof(CmsKitProApplicationModule),
    typeof(TextTemplateManagementApplicationModule)
    )]
[DependsOn(typeof(FileManagementApplicationModule))]
[DependsOn(typeof(CFTA.Data.CFTADataModule))]

[DependsOn(
    typeof(FS.CmsKitManagement.CmsKitManagementApplicationModule),
    typeof(FS.EntityManagement.EntityManagementApplicationModule),
    typeof(FS.EShopManagement.EShopManagementApplicationModule),
    typeof(FS.FormManagement.FormManagementApplicationModule)
    )]
[DependsOn(typeof(Volo.Payment.Admin.AbpPaymentAdminApplicationModule))]
[DependsOn(
    typeof(EasyAbp.PaymentService.PaymentServiceApplicationModule)
    )]
public class CFTAApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<CFTAApplicationModule>();
        });
    }
}
