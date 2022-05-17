using Volo.Abp.Modularity;

namespace FS.EntityManagement
{
    [DependsOn(
       typeof(EntityManagementApplicationModule),
       typeof(EntityManagementDomainTestModule)
       )]
    public class EntityManagementApplicationTestModule : AbpModule
    {

    }

}

