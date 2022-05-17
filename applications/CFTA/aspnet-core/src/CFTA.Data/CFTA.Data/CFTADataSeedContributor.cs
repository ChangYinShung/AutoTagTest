using CFTA.Data;
using CFTA.Data.CmsKit;
using CFTA.Data.EShop;
using CFTA.Data.Frm;
using CFTA.Data.Identity;
using CFTA.Data.TextTemplate;
using System.Threading.Tasks;
using Volo.Abp.Data;

namespace CFTA.DbMigrator.Data
{
    public class CFTADataSeedContributor : Volo.Abp.Domain.Services.DomainService, IDataSeedContributor
    {
        private DataService DataService => this.LazyServiceProvider.LazyGetRequiredService<DataService>();

        public EShopDataSeeder EShopDataSeeder => this.LazyServiceProvider.LazyGetRequiredService<EShopDataSeeder>();

        public CmsKitDataSeeder CmsKitDataSeeder => this.LazyServiceProvider.LazyGetRequiredService<CmsKitDataSeeder>();

        public FrmDataSeeder FrmDataSeeder => this.LazyServiceProvider.LazyGetRequiredService<FrmDataSeeder>();
        public IdentityDataSeeder IdentityDataSeeder => this.LazyServiceProvider.LazyGetRequiredService<IdentityDataSeeder>();
        public TemplateDataSeeder TemplateDataSeeder => this.LazyServiceProvider.LazyGetRequiredService<TemplateDataSeeder>();

        public async Task SeedAsync(DataSeedContext context)
        {
            await this.DataService.ChangeTenantClaimsAsync(this.CurrentTenant.Id, async () =>
            {
                await IdentityDataSeeder.CreateRoleSeedAsync(this.CurrentTenant.Id);
                await TemplateDataSeeder.UpdateTemplateAsync(this.CurrentTenant.Id);
                await CmsKitDataSeeder.CreateEntityMediasAsync();
                await CmsKitDataSeeder.CreateBlogAndBlogPostAsync();
                await CmsKitDataSeeder.CreatePageAndMenuAsync();
                await EShopDataSeeder.CreateStoresAndProductsAsync();
                await FrmDataSeeder.CreateFormsAsync();
            });
            
        }
    }
}
