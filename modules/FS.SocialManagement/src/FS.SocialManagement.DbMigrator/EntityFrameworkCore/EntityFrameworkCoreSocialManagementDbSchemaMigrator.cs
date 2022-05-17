using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FS.SocialManagement.DbMigrator.Data;
using Volo.Abp.DependencyInjection;

namespace FS.SocialManagement.EntityFrameworkCore.DbMigrator;

public class EntityFrameworkCoreSocialManagementDbSchemaMigrator
    : ISocialManagementDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSocialManagementDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the SocialManagementDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SocialManagementDbContext>()
            .Database
            .MigrateAsync();
    }
}
