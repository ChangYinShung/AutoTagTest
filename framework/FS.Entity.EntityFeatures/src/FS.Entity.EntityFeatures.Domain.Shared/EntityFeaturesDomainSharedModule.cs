using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using FS.Entity.Localization;

namespace FS.Entity.EntityFeatures;

[DependsOn(typeof(FS.Entity.EntityDomainSharedModule))]
[DependsOn(typeof(FS.Abp.Data.AbpDataCoreModule))]
[DependsOn(typeof(FS.Entity.EntityFeatures.EntityFeaturesCoreModule))]
public class EntityFeaturesDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<EntityFeaturesDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<EntityResource>()
                .AddVirtualJson("/Localization/EntityFeatures");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("EntityFeatures", typeof(EntityResource));
        });
    }
}
