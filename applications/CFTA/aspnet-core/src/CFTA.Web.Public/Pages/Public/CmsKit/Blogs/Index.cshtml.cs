using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.BlobStoring;
using Volo.CmsKit.Blogs;
using Volo.CmsKit.MediaDescriptors;
using Volo.CmsKit.Public.Blogs;

namespace CFTA.Web.Public.Pages.CmsKitManagement.Blogs
{


    public class IndexModel : PageModel
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IBlogPostPublicAppService _blogPostAppService;
        #region ViewData
        public PagedResultDto<BlogPostPublicDto> BlogPostList { get; set; }
        public Blog CurrentBlog { get; set; }

        public string DisplayStyle { get; set; }
        #endregion

        #region PagerInfo
        [BindProperty(SupportsGet = true)]
        public int? SkipCount { get; set; }
        public int MaxResultCount = 10;
        #endregion



        public IndexModel(IBlogRepository blogRepository,
            IBlogPostPublicAppService blogPostAppService)
        {
            _blogRepository = blogRepository;
            _blogPostAppService = blogPostAppService;
        }

        public async Task OnGetAsync(string blogSlug)
        {

            DisplayStyle = HttpContext.Request.Query["display-style"];
            PagedAndSortedResultRequestDto queryparams = new PagedAndSortedResultRequestDto();
            queryparams.Sorting = "CreationTime DESC";
            SkipCount = SkipCount.HasValue ? SkipCount.Value : 0;
            queryparams.SkipCount = SkipCount.Value;
            queryparams.MaxResultCount = String.IsNullOrEmpty(DisplayStyle) ? MaxResultCount : 999;
            CurrentBlog = await _blogRepository.GetBySlugAsync(blogSlug);
            BlogPostList = await _blogPostAppService.GetListAsync(CurrentBlog.Slug, queryparams);
        }
    }
}
