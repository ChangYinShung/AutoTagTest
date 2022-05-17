using Localization.Resources.AbpUi;
using FS.FormManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.FormManagement
{

    [DependsOn(
        typeof(FormManagementApplicationModule),
        typeof(FS.FormManagement.FormManagementHttpApiModule),
        typeof(FS.FormManagement.EntityFrameworkCore.FormManagementEntityFrameworkCoreModule))]
    public class FormManagementAspNetCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(FormManagementApplicationModule).Assembly, c =>
                {
                    c.RootPath = FormManagementRemoteServiceConsts.ModuleName;
                    c.RemoteServiceName = FormManagementRemoteServiceConsts.RemoteServiceName;
                });
            });

        }


    }
}