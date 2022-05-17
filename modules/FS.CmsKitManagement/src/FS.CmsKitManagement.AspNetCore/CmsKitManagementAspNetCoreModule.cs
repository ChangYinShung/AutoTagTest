using Localization.Resources.AbpUi;
using FS.CmsKitManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Volo.Abp.AspNetCore.Mvc.Conventions;

namespace FS.CmsKitManagement
{
    [DependsOn(
        typeof(CmsKitManagementApplicationModule),
        typeof(FS.CmsKitManagement.EntityFrameworkCore.CmsKitManagementEntityFrameworkCoreModule),
        typeof(CmsKitManagementHttpApiModule))]

    [DependsOn(
        typeof(FS.CmsKit.ContentDefinitions.ContentDefinitionsApplicationModule),
        typeof(FS.CmsKit.ContentDefinitions.EntityFrameworkCore.ContentDefinitionsEntityFrameworkCoreModule),
        typeof(FS.CmsKit.ContentDefinitions.ContentDefinitionsHttpApiModule)
        )]

    [DependsOn(
        typeof(FS.CmsKit.ContentComposites.ContentCompositesApplicationModule),
        typeof(FS.CmsKit.ContentComposites.EntityFrameworkCore.ContentCompositesEntityFrameworkCoreModule),
        typeof(FS.CmsKit.ContentComposites.ContentCompositesHttpApiModule)
        )]

    [DependsOn(typeof(FS.CmsKit.CmsKitAspNetCoreModule))]

    [DependsOn(typeof(FS.Abp.JsonSubTypes.AbpJsonSubTypesAspNetCoreModule))]

    public class CmsKitManagementAspNetCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(CmsKitManagementApplicationModule).Assembly, c =>
                 {
                     c.RootPath = CmsKitManagementApplicationConsts.RootPath;
                     c.RemoteServiceName = CmsKitManagementApplicationConsts.RemoteServiceName;
                 });

                options.ConventionalControllers.Create(typeof(FS.CmsKit.ContentDefinitions.ContentDefinitionsApplicationModule).Assembly, c =>
                {
                    c.RootPath = CmsKitManagementApplicationConsts.RootPath;
                    c.RemoteServiceName = CmsKitManagementApplicationConsts.RemoteServiceName;
                });

                options.ConventionalControllers.Create(typeof(FS.CmsKit.ContentComposites.ContentCompositesApplicationModule).Assembly, c =>
                {
                    c.RootPath = CmsKitManagementApplicationConsts.RootPath;
                    c.RemoteServiceName = CmsKitManagementApplicationConsts.RemoteServiceName;
                });
            });
        }
    }
}
