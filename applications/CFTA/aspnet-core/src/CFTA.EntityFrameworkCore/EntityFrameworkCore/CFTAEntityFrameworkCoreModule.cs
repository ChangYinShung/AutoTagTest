using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.CmsKit.EntityFrameworkCore;
using Volo.FileManagement.EntityFrameworkCore;

namespace CFTA.EntityFrameworkCore;

[DependsOn(
    typeof(CFTADomainModule),
    typeof(AbpIdentityProEntityFrameworkCoreModule),
    typeof(AbpIdentityServerEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule),
    typeof(LanguageManagementEntityFrameworkCoreModule),
    typeof(SaasEntityFrameworkCoreModule),
    typeof(TextTemplateManagementEntityFrameworkCoreModule),
    typeof(CmsKitProEntityFrameworkCoreModule),
    typeof(BlobStoringDatabaseEntityFrameworkCoreModule)
    )]
[DependsOn(typeof(FileManagementEntityFrameworkCoreModule))]
[DependsOn(
    typeof(FS.CmsKitManagement.EntityFrameworkCore.CmsKitManagementEntityFrameworkCoreModule),
    typeof(FS.EntityManagement.EntityFrameworkCore.EntityManagementEntityFrameworkCoreModule),
    typeof(FS.EShopManagement.EntityFrameworkCore.EShopManagementEntityFrameworkCoreModule),
    typeof(FS.FormManagement.EntityFrameworkCore.FormManagementEntityFrameworkCoreModule)
    )]
[DependsOn(
    typeof(EasyAbp.PaymentService.EntityFrameworkCore.PaymentServiceEntityFrameworkCoreModule)
    )]
[DependsOn(typeof(FS.Abp.EmailingManagement.EntityFrameworkCore.EmailingManagementEntityFrameworkCoreModule))]
public class CFTAEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        CFTAEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<CFTADbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also CFTADbContextFactory for EF Core tooling. */
            options.UseSqlServer();
        });
    }
}
