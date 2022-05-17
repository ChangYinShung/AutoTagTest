using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.EShop.Products.Categories;
using EasyAbp.EShop.Products.Categories.Dtos;
using EasyAbp.EShop.Products.Products;
using EasyAbp.EShop.Products.Products.Dtos;
using EasyAbp.EShop.Stores.Stores;
using FS.EShopManagement.Products;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;
using EasyAbp.EShop.Stores.Stores.Dtos;

namespace CFTA.Web.Public.Pages.Demo;

public class ShopListModel : CFTAPublicPageModel
{
    public int PageSize { get; set; } = 10;

    [BindProperty(SupportsGet = true)]
    public int CurrentPage { get; set; } = 1;

    [BindProperty(SupportsGet = true)]
    public IEnumerable<Guid> CategoryIds { get; set; }

    [BindProperty(SupportsGet = true)]
    public FilterTypeEnum FilterType { get; set; }

    [BindProperty(SupportsGet = true)]
    public SortTypeEnum SortType { get; set; }

    public PagedResultDto<ProductViewDto> ProductViewList { get; set; }
    public List<CategoryDto> CategoryList { get; set; }

    public PagerModel PagerModel => new PagerModel(ProductViewList.TotalCount, ProductViewList.Items.Count, CurrentPage, PageSize, Request.Path.ToString());

    protected FS.EShopManagement.Public.Products.IProductViewAppService ProductViewAppService { get; }
    protected ICategoryAppService CategoryAppService { get; }
    protected IStoreAppService StoreAppService { get; }


    public ShopListModel(
        FS.EShopManagement.Public.Products.IProductViewAppService productViewAppService,
        ICategoryAppService categoryAppService,
        IStoreAppService storeAppService)
    {
        ProductViewAppService = productViewAppService;
        CategoryAppService = categoryAppService;
        StoreAppService = storeAppService;
    }

    public virtual async Task<IActionResult> OnGetAsync()
    {
        // TODO: 按照目前需求，使用默认商店比较好找，appservice未提供FindByName方法
        var store = await StoreAppService.GetDefaultAsync();

        CategoryList = (await CategoryAppService.GetListAsync(new GetCategoryListDto
        {
            ParentId = null,
        })).Items.ToList();

        var categoryIdList = FilterType switch
        {
            FilterTypeEnum.All => CategoryList.Select(p => p.Id).ToList(),
            _ => CategoryIds.ToList(),
        };

        ProductViewList = await ProductViewAppService.GetListV2Async(new FS.EShopManagement.Public.Products.Dtos.GetProductViewListInput
        {
            StoreId = store.Id,
            CategoryIds = categoryIdList,
            MaxResultCount = PageSize,
            SkipCount = (CurrentPage - 1) * PageSize
        });

        return Page();
    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }


    public enum SortTypeEnum
    {
        CategoryAsc = 0,
        CategoryDesc = 1,
        PriceAsc = 2,
        PriceDesc = 3,
    }

    public enum FilterTypeEnum
    {
        All = 0,
        Custom = 1,
    }
}