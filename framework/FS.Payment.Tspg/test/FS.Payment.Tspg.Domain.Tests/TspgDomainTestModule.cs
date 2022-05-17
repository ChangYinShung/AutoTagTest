using FS.Payment.Tspg.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.Payment.Tspg;

[DependsOn(
    typeof(TspgEntityFrameworkCoreTestModule)
    )]
public class TspgDomainTestModule : AbpModule
{

}
