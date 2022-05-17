using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;
using FS.EcPay;

namespace FS.EShopManagement;

[DependsOn(
    typeof(EShopManagementDomainModule),
    typeof(EShopManagementApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
[DependsOn(
    typeof(EasyAbp.EShop.Orders.EShopOrdersApplicationModule),
    typeof(EasyAbp.EShop.Payments.EShopPaymentsApplicationModule),
    typeof(EasyAbp.EShop.Products.EShopProductsApplicationModule),
    typeof(EasyAbp.EShop.Stores.EShopStoresApplicationModule),
    typeof(EasyAbp.PaymentService.PaymentServiceApplicationModule)
    )]
[DependsOn(typeof(EcPayCoreModule))]
[DependsOn(
    typeof(FS.EShopManagement.Admin.EShopManagementAdminApplicationModule),
    typeof(FS.EShopManagement.Public.EShopManagementPublicApplicationModule))]
public class EShopManagementApplicationModule : AbpModule
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<EShopManagementApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<EShopManagementApplicationModule>(validate: false);
        });

        ConfigureExtraPropertyServices();
    }

    public static void ConfigureExtraPropertyServices()
    {
        OneTimeRunner.Run(() =>
        {
            ObjectExtensionManager.Instance
                .AddOrUpdate(
                    new[] {
                        typeof(EasyAbp.EShop.Orders.Orders.Order),
                        typeof(EasyAbp.EShop.Orders.Orders.Dtos.CreateOrderDto),
                        typeof(EasyAbp.EShop.Orders.Orders.Dtos.OrderDto)
                    },
                    options =>
                    {
                        options.AddOrUpdateProperty<string>("firstName");
                        options.AddOrUpdateProperty<string>("lastName");
                        options.AddOrUpdateProperty<string>("phone");
                        options.AddOrUpdateProperty<string>("email");
                        options.AddOrUpdateProperty<string>("country");
                        options.AddOrUpdateProperty<string>("address");

                        //發票
                        options.AddOrUpdateProperty<string>("receipt");
                    }
                );

            ObjectExtensionManager.Instance
                .AddOrUpdate(
                    new[] {
                        typeof(EasyAbp.EShop.Orders.Orders.OrderLine),
                        typeof(EasyAbp.EShop.Orders.Orders.Dtos.CreateOrderLineDto),
                        typeof(EasyAbp.EShop.Orders.Orders.Dtos.OrderLineDto)
                    },
                    options =>
                    {
                        options.AddOrUpdateProperty<string>("remark");
                        options.AddOrUpdateProperty<decimal>("remarkExtraFee");
                        options.AddOrUpdateProperty<decimal>("TotalExtraFee");
                    }
                );

            ObjectExtensionManager.Instance
                .AddOrUpdate(
                    new[] {
                        typeof(EasyAbp.EShop.Payments.Payments.Dtos.CreatePaymentDto),
                        typeof(EasyAbp.PaymentService.Payments.CreatePaymentEto),
                        typeof(EasyAbp.EShop.Payments.Payments.Payment),
                        typeof(EasyAbp.EShop.Payments.Payments.Dtos.PaymentDto),
                        typeof(EasyAbp.PaymentService.Payments.Payment),
                        typeof(EasyAbp.PaymentService.Payments.Dtos.PaymentDto)
                    },
                    options =>
                    {
                        options.AddOrUpdateProperty<string>("PaymentNo");
                        options.AddOrUpdateProperty<string>("ReturnCode");
                        options.AddOrUpdateProperty<string>("HttpUrl");

                        options.AddOrUpdateProperty<EcPay.Models.EcPayPaymentExtraProperty>("EcPay");
                    }
                );
        });
    }
}
