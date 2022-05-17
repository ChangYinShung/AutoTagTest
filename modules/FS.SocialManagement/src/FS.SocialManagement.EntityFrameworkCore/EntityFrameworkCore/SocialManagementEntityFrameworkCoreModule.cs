using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.SocialManagement.EntityFrameworkCore;

[DependsOn(typeof(FS.Social.EntityFrameworkCore.SocialEntityFrameworkCoreModule))]
[DependsOn(
    typeof(SocialManagementDomainModule)
)]
public class SocialManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<SocialManagementDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
