using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.VeeValidate;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Vue;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;
using Volo.Abp.VirtualFileSystem;

namespace CFTA.Web.Public.Pages.Components.ProductListWidget
{
    [Widget(
        StyleFiles = new[]
        {
            "/Pages/Components/ProductListWidget/Default.css"
        },
        ScriptTypes = new[]
        {
            typeof(VueScriptContributor),
            typeof(VeeValidateScriptContributor),
            typeof(ProductListWidgetScriptContributor)
        }
    )]
    public class ProductListWidgetViewComponent : AbpViewComponent
    {
        protected FS.EShopManagement.Public.Stores.IStoresAppService StoresAppService { get; }
        protected IConfiguration Configuration { get; }
        protected IVirtualFileProvider VirtualFileProvider { get; }

        public ProductListWidgetViewComponent(
            FS.EShopManagement.Public.Stores.IStoresAppService StoresAppService,
            IConfiguration Configuration,
            IVirtualFileProvider VirtualFileProvider)
        {
            this.StoresAppService = StoresAppService;
            this.Configuration = Configuration;
            this.VirtualFileProvider = VirtualFileProvider;
        }

        public virtual async Task<IViewComponentResult> InvokeAsync()
        {
            var apiUrl = this.Configuration["AuthServer:Authority"];

            var store = await this.StoresAppService.GetDefaultAsync();
            var backNumbers = this.LoadBackNumbers();

            var model = new ProductListWidgetViewModel()
            {
                MediaDescriptorApiUrl = $"{apiUrl}/api/cms-kit/media/",
                StoreId = store.Id,
                BackNumbers = JsonConvert.SerializeObject(backNumbers)
            };

            return View(model);
        }

        private List<Models.BackNumberModel> LoadBackNumbers()
        {
            var fileInfo = this.VirtualFileProvider.GetFileInfo("/Models/back_number.json");
            using (var stream = new StreamReader(fileInfo.CreateReadStream()))
            {
                string jsonStr = stream.ReadToEnd();
                var list = JsonConvert.DeserializeObject<List<Models.BackNumberModel>>(jsonStr);
                return list;
            }
        }
    }

    public class ProductListWidgetViewModel
    {
        public string MediaDescriptorApiUrl { get; set; }

        public Guid StoreId { get; set; }

        public string BackNumbers { get; set; }
    }

    public class ProductListWidgetScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.Add("/client-proxies/e-shop-management-proxy.js");
            context.Files.Add("/client-proxies/easyAbpEShopProducts-proxy.js");
            context.Files.Add("/Pages/Components/ProductListWidget/Default.js");
        }
    }
}
