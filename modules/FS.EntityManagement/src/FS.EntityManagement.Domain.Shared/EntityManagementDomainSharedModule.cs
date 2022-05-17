using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using FS.Entity.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace FS.EntityManagement
{

    [DependsOn(
        typeof(AbpValidationModule)
    )]
    [DependsOn(
        typeof(FS.Entity.EntityDefaults.EntityDefaultsDomainSharedModule),
        typeof(FS.Entity.EntityFeatures.EntityFeaturesCoreModule),
        typeof(FS.Entity.MultiLinguals.MultiLingualsDomainSharedModule)
        )]
    public class EntityManagementDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<EntityManagementDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<EntityResource>()
                    .AddVirtualJson("/Localization/EntityManagement");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("EntityManagement", typeof(EntityResource));
            });
        }
    }
}
