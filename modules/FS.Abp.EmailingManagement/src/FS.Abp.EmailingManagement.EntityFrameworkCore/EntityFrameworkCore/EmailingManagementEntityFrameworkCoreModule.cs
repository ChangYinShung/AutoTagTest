using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.Abp.EmailingManagement.EntityFrameworkCore;

[DependsOn(typeof(EmailingManagementDomainModule))]
[DependsOn(typeof(FS.Abp.Emailing.EntityFrameworkCore.EmailingEntityFrameworkCoreModule))]
public class EmailingManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<EmailingManagementDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
