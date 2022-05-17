using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;


namespace CFTA.Web.Public.Components.PagerWidget
{
    public class Pagination
    {
        public PagedAndSortedResultRequestDto pageResultDto { get; set; }
        public int TotalCount { get; set; }
        public string blogSlug { get; set; }

        public long totalPage
        {
            get
            {
                return TotalCount % pageResultDto.MaxResultCount == 0 ?
                  TotalCount / pageResultDto.MaxResultCount
                  : TotalCount / pageResultDto.MaxResultCount + 1;
            }
        }
        public long nowPageNo
        {
            get
            {
                return (pageResultDto.SkipCount / pageResultDto.MaxResultCount) + 1;
            }
        }
        public bool havePrePage
        {
            get { return nowPageNo - 1 > 0; }
        }
        public bool haveNextPage
        {
            get { return nowPageNo + 1 <= totalPage; }
        }
        //TODO:  Alex:Path Should not use relative
        public string prePageUrl
        {
            get
            {
                return havePrePage ?
                                  "./" + blogSlug + "?SkipCount=" + (pageResultDto.SkipCount - pageResultDto.MaxResultCount).ToString()
                                  : "javascript:;";
            }
        }
        //TODO:  Alex: Path Should not use relative
        public string nextPageUrl
        {
            get
            {
                return haveNextPage ?
                                    "./" + blogSlug + "?SkipCount=" + (pageResultDto.SkipCount + pageResultDto.MaxResultCount).ToString()
                                    : "javascript:;";
            }
        }
        public Pagination(int skipCount, int maxResultCount, int totalCount)
        {
            pageResultDto = new PagedAndSortedResultRequestDto()
            {
                MaxResultCount = maxResultCount,
                SkipCount = skipCount
            };
            TotalCount = totalCount;
        }
    }

    [Widget]
    public class PagerWidgetViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke(int skipCount, int maxResultCount, int totalCount)
        {
            Pagination PaginationData = new Pagination(skipCount, maxResultCount, totalCount);
            PaginationData.blogSlug = ViewContext.RouteData.Values["blogSlug"].ToString() ?? "";
            return View(PaginationData);
        }
    }
}
