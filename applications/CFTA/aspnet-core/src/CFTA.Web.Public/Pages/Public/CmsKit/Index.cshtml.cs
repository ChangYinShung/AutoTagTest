using System.Threading.Tasks;
using CFTA.Public.ContentDefinitions.Files;
using Microsoft.AspNetCore.Authentication;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.TextTemplating;
using Volo.CmsKit.Public.Blogs;

namespace CFTA.Web.Public.Pages
{
    public class IndexModel : CFTAPublicPageModel
    {
        public PagedResultDto<BlogPostPublicDto> bannerBlogDtos { get; set; }
        public PagedResultDto<BlogPostPublicDto> newsBlogDtos { get; set; }
        public PagedResultDto<BlogPostPublicDto> albumBlogDtos { get; set; }
        public PagedResultDto<BlogPostPublicDto> videosBlogDtos { get; set; }
        public PagedResultDto<BlogPostPublicDto> employeeBlogDtos { get; set; }
        public PagedResultDto<BlogPostPublicDto> supportCompanyBlogDtos { get; set; }
        private readonly ITemplateRenderer _templateRenderer;
        private readonly IBlogPostPublicAppService _blogPostPublicAppService;

        public string AbountUsContent { get; set; }



        public IndexModel(
            IBlogPostPublicAppService blogPostPublicAppService,
            IThemeManager themeManager,
            ITemplateRenderer templateRenderer
            )
        {
            _blogPostPublicAppService = blogPostPublicAppService;
            _templateRenderer = templateRenderer;

        }

        public async Task OnGet()
        {
            bannerBlogDtos = await _blogPostPublicAppService.GetListAsync("slider", new PagedAndSortedResultRequestDto() { MaxResultCount = 5 });

            PagedAndSortedResultRequestDto newsRequestDto = new PagedAndSortedResultRequestDto()
            {
                MaxResultCount = 3
            };

            newsBlogDtos = await _blogPostPublicAppService.GetListAsync("zuei-sin-siao-si", newsRequestDto);

            PagedAndSortedResultRequestDto albumRequestDto = new PagedAndSortedResultRequestDto()
            {
                MaxResultCount = 5
            };
            albumBlogDtos = await _blogPostPublicAppService.GetListAsync("siang-bu-jhuan-chyu", albumRequestDto);

            PagedAndSortedResultRequestDto videoRequestDto = new PagedAndSortedResultRequestDto()
            {
                MaxResultCount = 10
            };
            videosBlogDtos = await _blogPostPublicAppService.GetListAsync("ying-pian-jhuan-chyu", videoRequestDto);

            PagedAndSortedResultRequestDto employeeRequestDto = new PagedAndSortedResultRequestDto()
            {
                Sorting="CreationTime DESC",
                MaxResultCount = 999
            };
            employeeBlogDtos = await _blogPostPublicAppService.GetListAsync("jhih-yuan-ching-dan", employeeRequestDto);

            PagedAndSortedResultRequestDto supportCompanyRequestDto = new PagedAndSortedResultRequestDto()
            {
                MaxResultCount = 6
            };
            supportCompanyBlogDtos = await _blogPostPublicAppService.GetListAsync("support-company", supportCompanyRequestDto);


            AbountUsContent = await _templateRenderer.RenderAsync(
                "AboutUs", //the template name
                new AboutUsModel
                {
                    Title = "關於我們",
                    Content = "臺南市臺灣鋼鐵足球隊在臺南市政府及臺南市體育總會足球委員會與鴻鑫企業有限公司還有臺灣鋼鐵集團共同支援下成立。我們致力於臺灣的足球發展，展翅上騰、無畏無懼就是我們的鋼鐵精神。",
                    FileUrl = "./assets/images/CFTA/about.jpg"
                });
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}
