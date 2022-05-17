using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.Application.Dtos;
using Volo.Abp.BlobStoring;
using Volo.CmsKit.Blogs;
using Volo.CmsKit.MediaDescriptors;
using Volo.CmsKit.Public.Blogs;

namespace CFTA.Web.Public.Pages.CmsKitManagement.Blogs
{



    public class BlogsPostModel : PageModel
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IBlogPostPublicAppService _blogPostAppService;
        #region ViewData
        public BlogPostPublicDto BlogPostPublicDto { get; set; }
        #endregion




        public BlogsPostModel(IBlogRepository blogRepository,
            IBlogPostPublicAppService blogPostAppService)
        {
            _blogRepository = blogRepository;
            _blogPostAppService = blogPostAppService;
            
        }

        public async Task OnGetAsync(string blogSlug,string blogPostSlug)
        {
            BlogPostPublicDto = await _blogPostAppService.GetAsync(blogSlug, blogPostSlug);            
        }
    }
}
