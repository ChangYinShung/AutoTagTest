using FS.Social.Codes.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.Social.EntityFrameworkCore;

[DependsOn(
    typeof(SocialDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class SocialEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<CodesDbContext>(options =>
        {
             /* Add custom repositories here. Example:
              * options.AddRepository<Question, EfCoreQuestionRepository>();
              */
        });
    }
}
