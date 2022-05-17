using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FS.Entity.MultiLinguals
{
    [DependsOn(typeof(MultiLingualsDomainSharedModule))]
    [DependsOn(typeof(FS.Entity.EntityApplicationContractsModule))]
    public class MultiLingualsApplicationContractsModule : AbpModule
    {

    }
}


