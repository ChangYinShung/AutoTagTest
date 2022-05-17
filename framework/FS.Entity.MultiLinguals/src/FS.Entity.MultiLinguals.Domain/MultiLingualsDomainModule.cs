using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.Entity.MultiLinguals
{
    [DependsOn(typeof(FS.Entity.EntityDomainModule))]
    [DependsOn(
        typeof(MultiLingualsDomainSharedModule)
    )]
    [DependsOn(typeof(FS.Abp.Data.AbpDataModule))]
    public class MultiLingualsDomainModule : AbpModule
    {

    }
}


