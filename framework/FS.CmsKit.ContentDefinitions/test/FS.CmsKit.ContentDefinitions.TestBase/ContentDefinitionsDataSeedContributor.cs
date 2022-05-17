using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace FS.CmsKit.ContentDefinitions;

public class ContentDefinitionsDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IContentDefinitionsStore store;
    private readonly IGuidGenerator _guidGenerator;
    private readonly ICurrentTenant _currentTenant;

    public ContentDefinitionsDataSeedContributor(
        FS.CmsKit.ContentDefinitions.IContentDefinitionsStore store,
        IGuidGenerator guidGenerator,
        ICurrentTenant currentTenant)
    {
        this.store=store;
        _guidGenerator = guidGenerator;
        _currentTenant = currentTenant;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        /* Instead of returning the Task.CompletedTask, you can insert your test data
         * at this point!
         */

        using (_currentTenant.Change(context?.TenantId))
        {
            await this.store.ContentDefinition.InsertAsync(new ContentDefinition(_guidGenerator.Create())
            {
                Version="Default"

            }, true);

            await this.store.ContentTypeDefinition.InsertAsync(new ContentTypeDefinition(_guidGenerator.Create())
            {
                EntityType="Volo.CmsKit.Blogs.Page",
                EntityId="123"
            }, true);
        }
    }
}
