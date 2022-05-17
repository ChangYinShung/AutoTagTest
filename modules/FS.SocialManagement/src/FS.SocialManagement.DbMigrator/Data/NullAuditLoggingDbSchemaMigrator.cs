using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace FS.SocialManagement.DbMigrator.Data
{
    /* This is used if database provider does't define
     * IAuditLoggingDbSchemaMigrator implementation.
     */
    public class NullAuditLoggingDbSchemaMigrator : ISocialManagementDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}