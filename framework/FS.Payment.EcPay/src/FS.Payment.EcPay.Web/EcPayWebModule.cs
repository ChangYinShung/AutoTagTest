using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
//using FS.Payment.EcPay.Localization;
using FS.Payment.EcPay.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
//using FS.Payment.EcPay.Permissions;

namespace FS.Payment.EcPay.Web;

[DependsOn(
    typeof(Volo.Payment.AbpPaymentWebModule),
    typeof(AbpAspNetCoreMvcUiThemeSharedModule),
    typeof(AbpAutoMapperModule)
    )]
public class EcPayWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        //context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        //{
        //    options.AddAssemblyResource(typeof(EcPayResource), typeof(EcPayWebModule).Assembly);
        //});

        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(EcPayWebModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpNavigationOptions>(options =>
        //{
        //    options.MenuContributors.Add(new EcPayMenuContributor());
        //});

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<EcPayWebModule>();
        });

        context.Services.AddAutoMapperObjectMapper<EcPayWebModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<EcPayWebModule>(validate: true);
        });

        Configure<RazorPagesOptions>(options =>
        {
            //Configure authorization.
        });
    }
}
