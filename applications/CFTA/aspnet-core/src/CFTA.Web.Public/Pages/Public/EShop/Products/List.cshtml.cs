using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CFTA.Web.Public.Pages.EShop.Products
{
    public class ListModel : PageModel
    {
        public string ApiUrl { get; set; }

        public ListModel(IConfiguration Configuration)
        {
            var apiUrl = Configuration["AuthServer:Authority"];
            this.ApiUrl = apiUrl + "/";
        }

        public void OnGet()
        {
        }
    }
}
