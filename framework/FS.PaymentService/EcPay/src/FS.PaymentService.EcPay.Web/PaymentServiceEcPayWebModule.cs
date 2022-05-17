using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using FS.PaymentService.Localization;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace FS.PaymentService.Web;

[DependsOn(
    typeof(AbpAspNetCoreMvcUiThemeSharedModule),
    typeof(AbpAutoMapperModule),
    typeof(EasyAbp.PaymentService.PaymentServiceApplicationModule),
    typeof(FS.PaymentService.PaymentServiceAspNetCoreModule),
    typeof(FS.EcPay.EcPayHttpApiModule)
    )]
public class PaymentServiceEcPayWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(typeof(PaymentServiceResource), typeof(PaymentServiceEcPayWebModule).Assembly);
        });

        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(PaymentServiceEcPayWebModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpNavigationOptions>(options =>
        //{
        //    options.MenuContributors.Add(new PaymentServiceMenuContributor());
        //});

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PaymentServiceEcPayWebModule>();
        });

        context.Services.AddAutoMapperObjectMapper<PaymentServiceEcPayWebModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<PaymentServiceEcPayWebModule>(validate: true);
        });

        Configure<RazorPagesOptions>(options =>
        {
            //Configure authorization.
        });
    }
}
