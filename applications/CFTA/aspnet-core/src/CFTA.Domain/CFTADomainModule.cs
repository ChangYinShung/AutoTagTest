using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using CFTA.Localization;
using CFTA.MultiTenancy;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.LanguageManagement;
using Volo.Abp.LeptonTheme.Management;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
using Volo.Abp.SettingManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.Saas;
using Volo.Abp.BlobStoring.Database;
using Volo.Abp.Commercial.SuiteTemplates;
using Volo.CmsKit;
using Volo.CmsKit.Contact;
using Volo.CmsKit.Newsletters;
using Volo.FileManagement;
using EasyAbp.PaymentService.Options;
using EasyAbp.PaymentService.Payments;
using FS.Tspg.PaymentService;
using FS.EcPay.PaymentService;
using Volo.Abp.GlobalFeatures;
using Volo.CmsKit.GlobalFeatures;
using Volo.CmsKit.MediaDescriptors;
using System.Collections.Generic;

namespace CFTA;

[DependsOn(
    typeof(CFTADomainSharedModule),
    typeof(AbpAuditLoggingDomainModule),
    typeof(AbpBackgroundJobsDomainModule),
    typeof(AbpFeatureManagementDomainModule),
    typeof(AbpIdentityProDomainModule),
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpIdentityServerDomainModule),
    typeof(AbpPermissionManagementDomainIdentityServerModule),
    typeof(AbpSettingManagementDomainModule),
    typeof(SaasDomainModule),
    typeof(TextTemplateManagementDomainModule),
    typeof(LeptonThemeManagementDomainModule),
    typeof(LanguageManagementDomainModule),
    typeof(VoloAbpCommercialSuiteTemplatesModule),
    typeof(AbpEmailingModule),
    typeof(CmsKitProDomainModule),
    typeof(BlobStoringDatabaseDomainModule)
    )]
[DependsOn(typeof(FileManagementDomainModule))]
[DependsOn(
    typeof(FS.CmsKitManagement.CmsKitManagementDomainModule),
    typeof(FS.EntityManagement.EntityManagementDomainModule),
    typeof(FS.EShopManagement.EShopManagementDomainModule),
    typeof(FS.FormManagement.FormManagementDomainModule)
    )]
[DependsOn(typeof(Volo.Payment.AbpPaymentDomainModule))]
[DependsOn(
    typeof(EasyAbp.PaymentService.PaymentServiceDomainModule),
    typeof(FS.Tspg.TspgPaymentServiceModule),
    typeof(FS.EcPay.EcPayPaymentServiceModule)
    )]
[DependsOn(typeof(FS.Abp.EmailingManagement.EmailingManagementDomainModule))]
public class CFTADomainModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        this.PreConfigureEntityFeatures();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });

        Configure<AbpLocalizationOptions>(options =>
        {

            options.Languages.Add(new LanguageInfo("en", "en", "English", "gb"));
            options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文", "tw"));
        });
        Configure<NewsletterOptions>(options =>
        {
            options.AddPreference(
                "Newsletter_Default",
                new NewsletterPreferenceDefinition(
                    LocalizableString.Create<CFTAResource>("NewsletterPreference_Default"),
                    privacyPolicyConfirmation: LocalizableString.Create<CFTAResource>("NewsletterPrivacyAcceptMessage")
                )
            );
        });

        ConfigurePaymentService();

        ConfigureCmsKitMediaOptions();

#if DEBUG
        //context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
    }


    private void ConfigurePaymentService()
    {
        Configure<PaymentServiceOptions>(options =>
        {
            options.Providers.Configure<FreePaymentServiceProvider>(FreePaymentServiceProvider.PaymentMethod);
            options.Providers.Configure<TspgPaymentServiceProvider>(TspgPaymentServiceProvider.PaymentMethod);
            options.Providers.Configure<EcPayPaymentServiceProvider>(EcPayPaymentServiceProvider.PaymentMethod);
        });
    }

    private void ConfigureCmsKitMediaOptions()
    {
        if (GlobalFeatureManager.Instance.IsEnabled<MediaFeature>())
        {
            Configure<CmsKitMediaOptions>(options =>
            {
                options.EntityTypes.AddIfNotContains(
                    new MediaDescriptorDefinition(
                        "EasyAbp.EShop.Products.Products.Product"));

                options.EntityTypes.AddIfNotContains(
                    new MediaDescriptorDefinition(
                        "EasyAbp.EShop.Products.Products.ProductSku"));
            });
        }
    }
    private void PreConfigureEntityFeatures()
    {
        PreConfigure<FS.Entity.EntityFeatures.EntityFeaturesOptions>(options =>
        {
            options.GetOrAdd<FS.CmsKit.EntityMedias.EntityMedia>(a =>
            {
                a.AddOrReplace<EasyAbp.EShop.Products.Products.Product>();

                a.AddOrReplace<EasyAbp.EShop.Products.Products.ProductSku>();
            });
        });
    }
}
