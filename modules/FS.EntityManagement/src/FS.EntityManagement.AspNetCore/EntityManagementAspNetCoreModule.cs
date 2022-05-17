using Localization.Resources.AbpUi;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Volo.Abp.AspNetCore.Mvc.Conventions;
using FS.Entity.MultiLinguals;
using FS.Entity.MultiLinguals.EntityFrameworkCore;
using FS.Entity.EntityDefaults;
using FS.Entity.EntityDefaults.EntityFrameworkCore;
using FS.Entity.EntityFeatures;
using FS.Entity;

namespace FS.EntityManagement
{
    [DependsOn(
        typeof(EntityManagementApplicationModule),
        typeof(EntityFrameworkCore.EntityManagementEntityFrameworkCoreModule),
        typeof(EntityManagementHttpApiModule))]

    [DependsOn(
        typeof(MultiLingualsAspNetCoreModule),
        typeof(EntityDefaultsAspNetCoreModule),
        typeof(EntityFeaturesAspNetCoreModule)
        )]
    public class EntityManagementAspNetCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(EntityManagementApplicationModule).Assembly, c =>
                 {
                     c.RootPath = EntityRemoteServiceConsts.ModuleName;
                     c.RemoteServiceName = EntityRemoteServiceConsts.RemoteServiceName;
                 });
            });
        }
    }
}
