using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using CFTA.EntityFrameworkCore;
using CFTA.Localization;
using CFTA.MultiTenancy;
using CFTA.Web.Public.Menus;
using StackExchange.Redis;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.OpenIdConnect;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
//using Volo.Abp.AspNetCore.Mvc.UI.Theme.Commercial;
//using Volo.Abp.AspNetCore.Mvc.UI.Theme.Lepton;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Http.Client.IdentityModel.Web;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.UI;
using Volo.Abp.UI.Navigation;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundWorkers;
using Owl.reCAPTCHA;
using Volo.CmsKit.Pro.Public.Web;
using Volo.CmsKit.Public.Web;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using CFTA.Public.ContentDefinitions;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Volo.Payment;
using CFTA.Payments.Tspg;
using Volo.Abp.Timing;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using FS.Abp.AspNetCore.Mvc.UI.Theme.Unice;
using CFTA.Payments.EcPay;
using FS.Tspg;
using FS.EcPay;

namespace CFTA.Web.Public;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(CFTAHttpApiModule),
    typeof(CFTAApplicationModule),
    typeof(CFTAEntityFrameworkCoreModule),
    typeof(AbpAspNetCoreAuthenticationOpenIdConnectModule),
    typeof(AbpHttpClientIdentityModelWebModule),
    typeof(CmsKitProPublicWebModule),
    typeof(Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.AbpAspNetCoreMvcUiBasicThemeModule)

    )]
[DependsOn(typeof(CFTAPublicContentDefinitionsModule))]
[DependsOn(
    typeof(TspgCoreModule),
    typeof(EcPayCoreModule))]
[DependsOn(typeof(AbpAspNetCoreMvcUIUniceThemeModule))]
[DependsOn(typeof(FS.SocialManagement.SocialManagementAspNetCoreModule))]
public class CFTAWebPublicModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(
                typeof(CFTAResource),
                typeof(CFTADomainSharedModule).Assembly,
                typeof(CFTAApplicationContractsModule).Assembly,
                typeof(CFTAWebPublicModule).Assembly
            );
        });
    }


    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();
        Configure<Volo.Abp.AspNetCore.Mvc.AntiForgery.AbpAntiForgeryOptions>(options =>
        {
            options.AutoValidate = false;
        });
        ConfigureUrls(configuration);
        ConfigureCache(configuration);
        ConfigureDataProtection(context, configuration, hostingEnvironment);
        ConfigureMultiTenancy();
        ConfigureAuthentication(context, configuration);
        ConfigureAutoMapper();
        ConfigureVirtualFileSystem(hostingEnvironment);
        ConfigureNavigationServices(configuration);
        ConfigureBackgroundJobs();
        ConfigureTheming();
        ConfigurePayments(context);




        //context.Services.AddreCAPTCHAV3(o =>
        //{
        //    o.SiteKey = "test";
        //    o.SiteSecret = "test";
        //});

        Configure<Volo.Abp.AspNetCore.Uow.AbpAspNetCoreUnitOfWorkOptions>(options =>
        {
            options.IgnoredUrls.Add(@"/e-shop/payment-service/tspg/pre-payment");
            options.IgnoredUrls.Add(@"/e-shop/payment-service/ec-pay/pre-payment");
        });
        Configure<AbpClockOptions>(options =>
        {
            options.Kind = DateTimeKind.Local;
        });
        Configure<RazorPagesOptions>(options =>
        {
            ////Permission Check
            options.Conventions.AuthorizePage("/Public/EShop/Products/Checkout");
            options.Conventions.AuthorizePage("/Public/EShop/Orders/Index");
            options.Conventions.AuthorizePage("/Public/EShop/Orders/Order");
            ////Should try AuthorizeFolder
            options.Conventions.AuthorizePage("/Public/EShop/PaymentService/Payments/PaymentFail");
            options.Conventions.AuthorizePage("/Public/EShop/PaymentService/Payments/PaymentSuccess");
            options.Conventions.AuthorizePage("/Public/EShop/PaymentService/Payments/Tspg/PostPayment");
            options.Conventions.AuthorizePage("/Public/EShop/PaymentService/Payments/Tspg/PrePayment");
            //Add Route
            options.Conventions.AddPageRoute("/Public/CmsKit/Index", "");
        });
        Configure<AbpBundlingOptions>(options =>
        {
            options.StyleBundles
                .Get(StandardBundles.Styles.Global)
                .AddFiles("/CFTA/styles/main.css");
        });
    }

    private void ConfigurePayments(ServiceConfigurationContext context)
    {
        context.Services.TryAddEnumerable(ServiceDescriptor
            .Transient<IConfigureOptions<PaymentWebOptions>, TspgPaymentWebOptionsSetup>());

        context.Services.TryAddEnumerable(ServiceDescriptor
            .Transient<IConfigureOptions<PaymentWebOptions>, EcPayPaymentWebOptionsSetup>());
    }

    private void ConfigureBackgroundJobs()
    {
        Configure<AbpBackgroundJobOptions>(options =>
        {
            options.IsJobExecutionEnabled = false;
        });

        Configure<AbpBackgroundWorkerOptions>(options =>
        {
            options.IsEnabled = false;
        });
    }

    private void ConfigureTheming()
    {
        Configure<AbpThemingOptions>(options =>
        {
            options.DefaultThemeName = UniceTheme.Name;
        });
    }

    private void ConfigureUrls(IConfiguration configuration)
    {
        Configure<AppUrlOptions>(options =>
        {
            options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
        });
    }

    private void ConfigureCache(IConfiguration configuration)
    {
        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = "CFTA:";
        });
    }

    private void ConfigureMultiTenancy()
    {
        Configure<AbpMultiTenancyOptions>(options => { options.IsEnabled = MultiTenancyConsts.IsEnabled; });
    }

    private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies", options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(365);
            })
            .AddAbpOpenIdConnect("oidc", options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]); ;
                options.ResponseType = OpenIdConnectResponseType.CodeIdToken;

                options.ClientId = configuration["AuthServer:ClientId"];
                options.ClientSecret = configuration["AuthServer:ClientSecret"];

                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;

                options.Scope.Add("role");
                options.Scope.Add("email");
                options.Scope.Add("phone");
                options.Scope.Add("CFTA");
            });
    }

    private void ConfigureAutoMapper()
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<CFTAWebPublicModule>();
        });
    }

    private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CFTAWebPublicModule>();

            if (hostingEnvironment.IsDevelopment())
            {
                options.FileSets.ReplaceEmbeddedByPhysical<CFTADomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}CFTA.Domain.Shared", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<CFTAApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}CFTA.Application.Contracts", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<CFTAHttpApiModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}CFTA.HttpApi", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<AbpAspNetCoreMvcUIUniceThemeModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}..{0}..{0}..{0}framework{0}FS.Abp.AspNetCore.Mvc.UI.Theme.Unice{0}src", Path.DirectorySeparatorChar)));
            }
        });
    }

    private void ConfigureNavigationServices(IConfiguration configuration)
    {
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new CFTAPublicMenuContributor(configuration));
        });

        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new CFTAToolbarContributor());
        });
    }

    private void ConfigureDataProtection(
        ServiceConfigurationContext context,
        IConfiguration configuration,
        IWebHostEnvironment hostingEnvironment)
    {
        var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("CFTA");
        if (!hostingEnvironment.IsDevelopment())
        {
            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "CFTA-Protection-Keys");
        }
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();

        if (!env.IsDevelopment())
        {
            app.UseErrorPage();
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();

        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }

        app.UseAuthorization();
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseUnitOfWork();
        app.UseConfiguredEndpoints();
    }
}
