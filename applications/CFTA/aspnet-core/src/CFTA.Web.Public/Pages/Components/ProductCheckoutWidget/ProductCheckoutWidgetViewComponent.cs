using CFTA.Web.Public.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.VeeValidate;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Vue;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;
using Volo.Abp.VirtualFileSystem;
using Volo.Payment;

namespace CFTA.Web.Public.Pages.Components.ProductCheckoutWidget
{
    [Widget(
        ScriptTypes = new[]
        {
            typeof(VueScriptContributor),
            typeof(VeeValidateScriptContributor),
            typeof(ProductCheckoutWidgetScriptContributor)
        }
    )]
    public class ProductCheckoutWidgetViewComponent : AbpViewComponent
    {
        private readonly IVirtualFileProvider virtualFileProvider;
        public readonly PaymentWebOptions paymentWebOptions;


        public ProductCheckoutWidgetViewComponent(
            IVirtualFileProvider virtualFileProvider,
            IOptions<PaymentWebOptions> paymentWebOptions)
        {
            this.virtualFileProvider = virtualFileProvider;
            this.paymentWebOptions = paymentWebOptions.Value;
        }

        public virtual IViewComponentResult Invoke()
        {
            var zipCodes = this.LoadZipCode();
            var model = new ProductCheckoutWidgetModel()
            {
                ZipCodes = JsonConvert.SerializeObject(zipCodes),
                PaymentGateways = JsonConvert.SerializeObject(this.paymentWebOptions.Gateways)
            };

            return View(model);
        }

        private List<ZipCodeModel> LoadZipCode()
        {
            var fileInfo = this.virtualFileProvider.GetFileInfo("/Models/zipcode.json");
            using (var stream = new StreamReader(fileInfo.CreateReadStream()))
            {
                string jsonStr = stream.ReadToEnd();
                var list = JsonConvert.DeserializeObject<List<ZipCodeModel>>(jsonStr);
                return list;
            }
        }
    }

    public class ProductCheckoutWidgetScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.Add("/Pages/Components/ProductCheckoutWidget/Default.js");
        }
    }

    public class ProductCheckoutWidgetModel
    {
        public string ZipCodes { get; set; }
        public string PaymentGateways { get; set; }
    }
}
