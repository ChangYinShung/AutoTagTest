using System.Threading.Tasks;

namespace FS.SocialManagement.DbMigrator.Data
{
    public interface ISocialManagementDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
