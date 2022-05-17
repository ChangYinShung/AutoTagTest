using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EventBus.Local;
using Volo.Abp.Modularity;

namespace FS.Entity.EntityFeatures;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(EntityFeaturesDomainSharedModule)
)]
public class EntityFeaturesDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var entityFeaturesOptions = context.Services.GetPreConfigureActions<EntityFeaturesOptions>().Configure();

        var distributedHandlers = entityFeaturesOptions.Values
            .SelectMany(v => v.Keys)
            .Distinct()
            .Select(x =>
            {
                var type = typeof(EntityFeatureOwnerCreatedOrDeletedDistributedEventHandler<>).MakeGenericType(x);
                context.Services.TryAddTransient(type);
                return type;

            }).ToList();

        Configure<AbpDistributedEventBusOptions>(options =>
        {
            options.Handlers.AddIfNotContains(distributedHandlers);
        });


        //context.Services.TryAddEnumerable(ServiceDescriptor
        //    .Transient<IConfigureOptions<AbpDistributedEventBusOptions>, AbpLocalEventBusOptionsSetup>(x =>
        //    {
        //        var options = context.Services.BuildServiceProvider().GetService<IOptions<EntityFeaturesOptions>>();
        //        return new AbpLocalEventBusOptionsSetup(context.Services, options);
        //    }));
    }

}
