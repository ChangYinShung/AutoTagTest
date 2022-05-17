using FS.Abp.AspNetCore.Mvc.UI.Theme.Unice.Bundling;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FS.Abp.AspNetCore.Mvc.UI.Theme.Unice;

[DependsOn(
    typeof(Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.AbpAspNetCoreMvcUiBasicThemeModule)
    )]

public class AbpAspNetCoreMvcUIUniceThemeModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpAspNetCoreMvcUIUniceThemeModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpThemingOptions>(options =>
        {
            options.Themes.Add<UniceTheme>();

            if (options.DefaultThemeName == null)
            {
                options.DefaultThemeName = UniceTheme.Name;
            }
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpAspNetCoreMvcUIUniceThemeModule>("FS.Abp.AspNetCore.Mvc.UI.Theme.Unice");
        });

        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new BasicThemeMainTopToolbarContributor());
        });

        Configure<AbpBundlingOptions>(options =>
        {
            options
                .StyleBundles
                .Add(UniceThemeBundles.Styles.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(StandardBundles.Styles.Global)
                        .AddContributors(typeof(UniceThemeGlobalStyleContributor));
                });

            options
                .ScriptBundles
                .Add(UniceThemeBundles.Scripts.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(StandardBundles.Scripts.Global)
                        .AddContributors(typeof(UniceThemeGlobalScriptContributor));
                });
            //Sass Layout
            options
                .StyleBundles
                .Add(UniceThemeBundles.Styles.Sass, bundle =>
                {
                    bundle
                        .AddBaseBundles(UniceThemeBundles.Styles.Global)
                        .AddContributors(typeof(UniceThemeSassStyleContributor));
                });

            options
                  .ScriptBundles
                  .Add(UniceThemeBundles.Scripts.Sass, bundle =>
                  {
                      bundle
                          .AddBaseBundles(UniceThemeBundles.Scripts.Global)
                          .AddContributors(typeof(UniceThemeSassScriptContributor));
                  });
            //Ecommercial Layout
            options
                .StyleBundles
                .Add(UniceThemeBundles.Styles.Ecommercial, bundle =>
                {
                    bundle
                        .AddBaseBundles(UniceThemeBundles.Styles.Global)
                        .AddContributors(typeof(UniceThemeEcommercialStyleContributor));
                });

            options
                  .ScriptBundles
                  .Add(UniceThemeBundles.Scripts.Ecommercial, bundle =>
                  {
                      bundle
                          .AddBaseBundles(UniceThemeBundles.Scripts.Global)
                          .AddContributors(typeof(UniceThemeEcommercialScriptContributor));
                  });

        });
    }
}
