using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace FS.PaymentService.EcPay
{
    [DependsOn(
        typeof(FS.PaymentService.PaymentServiceDomainModule),
        typeof(FS.EcPay.EcPayCoreModule)
        )]
    public class PaymentServiceEcPayDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            Configure<PaymentServiceOptions>(configuration.GetSection("EcPay:PaymentService"));
        }

    }
}
