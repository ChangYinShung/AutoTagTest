using EasyAbp.PaymentService.Options;
using EasyAbp.PaymentService.Payments;
using FS.EShopManagement.Stores;
using FS.PaymentService.EcPay;
using FS.PaymentService.Tspg;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.EShopManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(EShopManagementDomainSharedModule)
)]
[DependsOn(
    typeof(EasyAbp.EShop.Orders.EShopOrdersDomainModule),
    typeof(EasyAbp.EShop.Payments.EShopPaymentsDomainModule),
    typeof(EasyAbp.EShop.Products.EShopProductsDomainModule),
    typeof(EasyAbp.EShop.Stores.EShopStoresDomainModule),
    typeof(EasyAbp.PaymentService.PaymentServiceDomainModule))]
[DependsOn(
    typeof(FS.PaymentService.PaymentServiceDomainModule),
    typeof(FS.PaymentService.Tspg.PaymentServiceTspgDomainModule),
    typeof(FS.PaymentService.EcPay.PaymentServiceEcPayDomainModule)
    )]
public class EShopManagementDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        Configure<StoresOptions>(configuration.GetSection("EShopManagement:Stores"));

        this.ConfigurePaymentService();
    }

    private void ConfigurePaymentService()
    {
        Configure<EasyAbp.PaymentService.Options.PaymentServiceOptions>(options =>
        {
            options.Providers.Configure<FreePaymentServiceProvider>(FreePaymentServiceProvider.PaymentMethod);
            options.Providers.Configure<TspgPaymentServiceProvider>(TspgPaymentServiceProvider.PaymentMethod);
            options.Providers.Configure<EcPayPaymentServiceProvider>(EcPayPaymentServiceProvider.PaymentMethod);
        });
    }
}
