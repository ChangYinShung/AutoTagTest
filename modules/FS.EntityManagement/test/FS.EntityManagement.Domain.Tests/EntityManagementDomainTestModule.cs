using FS.EntityManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.EntityManagement
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(EntityManagementEntityFrameworkCoreTestModule)
        )]
    public class EntityManagementDomainTestModule : AbpModule
    {

    }
}


