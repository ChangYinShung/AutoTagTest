using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using FS.Entity.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace FS.Entity.MultiLinguals
{
    [DependsOn(typeof(FS.Entity.EntityDomainSharedModule))]
    [DependsOn(typeof(FS.Entity.MultiLinguals.MultiLingualsCoreModule))]
    public class MultiLingualsDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<MultiLingualsDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<EntityResource>()
                    .AddVirtualJson("/Localization/MultiLinguals");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("MultiLinguals", typeof(EntityResource));
            });
        }
    }
}


