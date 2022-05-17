using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace CFTA.Web.Public
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<CFTAWebPublicModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.ApplicationServices.GetService<ISettingDefinitionManager>().Get(LocalizationSettingNames.DefaultLanguage).DefaultValue = "zh-Hant";
            app.InitializeApplication();
        }
    }
}
