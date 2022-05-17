using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using FS.Abp.Emailing.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace FS.Abp.EmailingManagement;

[DependsOn(typeof(FS.Abp.Emailing.EmailingDomainSharedModule))]
public class EmailingManagementDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<EmailingManagementDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<EmailingResource>()
                .AddVirtualJson("/Localization/EmailingManagement");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("EmailingManagement", typeof(EmailingResource));
        });
    }
}
