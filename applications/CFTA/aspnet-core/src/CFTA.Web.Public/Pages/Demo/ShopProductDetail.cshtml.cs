using EasyAbp.EShop.Products.Products;
using EasyAbp.EShop.Products.Products.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CFTA.Web.Public.Pages.Demo
{
    public class ShopProductDetailModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Guid ProductId { get; set; }

        public ProductDto Product { get; set; }

        protected IProductAppService ProductAppService { get; }


        public ShopProductDetailModel(IProductAppService productAppService)
        {
            ProductAppService = productAppService;
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            Product = await ProductAppService.GetAsync(ProductId);

            // TODO: 使用ICollection不太方便 无法使用索引器和List自带的快排 dto集合类型是否考虑换成List或者IList
            var attributes = Product.ProductAttributes.ToList();
            Product.ProductAttributes = attributes;
            attributes.Sort((item1, item2) => item1.DisplayOrder.CompareTo(item2.DisplayOrder));

            foreach (var attribute in attributes)
            {
                var options = attribute.ProductAttributeOptions.ToList();
                attribute.ProductAttributeOptions = options;
                options.Sort((item1, item2) => item1.DisplayOrder.CompareTo(item2.DisplayOrder));
            }

            return Page();
        }
    }
}
