using Microsoft.Extensions.DependencyInjection;
using FS.UnifyTheme.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace FS.UnifyTheme.Blazor
{
    [DependsOn(
        typeof(UnifyThemeApplicationContractsModule),
        typeof(AbpAspNetCoreComponentsWebThemingModule),
        typeof(AbpAutoMapperModule)
        )]
    public class UnifyThemeBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<UnifyThemeBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<UnifyThemeBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new UnifyThemeMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(UnifyThemeBlazorModule).Assembly);
            });
        }
    }
}