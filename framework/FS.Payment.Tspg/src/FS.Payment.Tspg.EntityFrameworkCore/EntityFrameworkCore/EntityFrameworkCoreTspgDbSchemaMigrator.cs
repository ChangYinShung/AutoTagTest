using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FS.Payment.Tspg.Data;
using Volo.Abp.DependencyInjection;

namespace FS.Payment.Tspg.EntityFrameworkCore;

public class EntityFrameworkCoreTspgDbSchemaMigrator
    : ITspgDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreTspgDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the TspgDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<TspgDbContext>()
            .Database
            .MigrateAsync();
    }
}
