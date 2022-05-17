using Localization.Resources.AbpUi;
using CFTA.Localization;
using Volo.Abp.Account;
using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.LanguageManagement;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Saas.Host;
using Volo.Abp.LeptonTheme;
using Volo.Abp.Localization;
using Volo.Abp.SettingManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.CmsKit;
using Volo.FileManagement;

namespace CFTA;

[DependsOn(
   typeof(CFTAApplicationContractsModule),
   typeof(AbpIdentityHttpApiModule),
   typeof(AbpPermissionManagementHttpApiModule),
   typeof(AbpFeatureManagementHttpApiModule),
   typeof(AbpSettingManagementHttpApiModule),
   typeof(AbpAuditLoggingHttpApiModule),
   typeof(AbpIdentityServerHttpApiModule),
   typeof(AbpAccountAdminHttpApiModule),
   typeof(LanguageManagementHttpApiModule),
   typeof(SaasHostHttpApiModule),
   typeof(LeptonThemeManagementHttpApiModule),
   typeof(CmsKitProHttpApiModule),
   typeof(AbpAccountPublicHttpApiModule),
   typeof(TextTemplateManagementHttpApiModule)
   )]
[DependsOn(typeof(FileManagementHttpApiModule))]
[DependsOn(typeof(Volo.Payment.Admin.AbpPaymentAdminHttpApiModule))]
[DependsOn(
    typeof(EasyAbp.PaymentService.PaymentServiceHttpApiModule)
    )]
public class CFTAHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CFTAResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
