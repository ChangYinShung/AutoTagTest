using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Volo.Payment;
using Volo.Payment.Requests;
using FS.Tspg.HttpClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using EasyAbp.EShop.Orders.Orders.Dtos;
using System.Linq;
using Volo.Abp.Data;
using CFTA.Web.Public.Models;

namespace CFTA.Pages.EShop.PaymentService.Payments.EcPay
{
    // IgnoreAntiforgery fix AntiforgeryValidationException
    // Order »Ý > 1000¡A°Ñ¦Ò https://github.com/aspnet/Mvc/issues/7012
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class PrePaymentModel : PageModel
    {
        private readonly FS.EShopManagement.Public.Orders.IOrdersAppService ordersAppService;

        public string html { get; set; }

        public PrePaymentModel(
            FS.EShopManagement.Public.Orders.IOrdersAppService ordersAppService
            )
        {
            this.ordersAppService = ordersAppService;
        }

        public ActionResult OnGet()
        {
            return Page();
        }

        [Volo.Abp.Uow.UnitOfWork(IsDisabled = true)]
        public async Task<ActionResult> OnPost(FormDataModel form)
        {
            var orders = form.SkuItems
                .GroupBy(x => x.StoreId)
                .Select(skuGroup =>
                {
                    var createOrder = new CreateOrderDto()
                    {
                        StoreId = new Guid(skuGroup.Key),
                        CustomerRemark = form.Remark,
                        OrderLines = skuGroup.Select(x =>
                        {
                            var orderLine = new CreateOrderLineDto()
                            {
                                ProductSkuId = new Guid(x.SkuId),
                                ProductId = new Guid(x.ProductId),
                                Quantity = x.Quantity
                            };

                            decimal.TryParse(x.RemarkExtraFee, out decimal remarkExtraFee);
                            decimal totalExtraFee = remarkExtraFee * x.Quantity;
                            
                            orderLine.SetProperty("remark", $"{x.Remark} * {x.Quantity}");
                            orderLine.SetProperty("remarkExtraFee", remarkExtraFee);
                            orderLine.SetProperty("TotalExtraFee", totalExtraFee);

                            return orderLine;
                        }).ToList()
                    };

                    createOrder.SetProperty("firstName", form.FirstName);
                    createOrder.SetProperty("lastName", form.LastName);
                    createOrder.SetProperty("phone", form.Phone);
                    createOrder.SetProperty("email", form.Email);
                    createOrder.SetProperty("country", form.Country);
                    createOrder.SetProperty("address", form.FullAddress);

                    return createOrder;
                })
                .ToList();

            var skuNames = form.SkuItems.Select(x => $"{x.SkuName} * {x.Quantity}").ToList();
            var model = new FS.EShopManagement.Public.Orders.Dtos.CreateOrderToPayDto()
            {
                CreateOrders = orders,
                PaymentProperties = new Volo.Abp.ObjectExtending.ExtensibleObject(),
                PaymentMethod = "EcPay"
            };
            model.PaymentProperties.SetProperty("EcPay", new FS.EcPay.Models.EcPayPaymentExtraProperty()
            {
                ItemNames = skuNames
            });

            var result = await this.ordersAppService.CreateOrderToPayAsync(model);

            var html = result.GetProperty<string>("HttpUrl");
            this.html = html;

            return Page(); //Redirect(url);
        }


    }
}
