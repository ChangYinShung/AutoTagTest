using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace CFTA.Data
{
    [DependsOn(
        typeof(Volo.Abp.Application.AbpDddApplicationModule),
        typeof(CFTA.CFTAApplicationContractsModule),
        typeof(CFTA.CFTADomainModule)
        )]
    public class CFTADataModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CFTADataModule>();
            });
        }
    }
}
