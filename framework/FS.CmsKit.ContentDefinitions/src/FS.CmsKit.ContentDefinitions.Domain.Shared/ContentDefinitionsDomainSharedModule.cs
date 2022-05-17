using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using FS.CmsKit.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Microsoft.Extensions.DependencyInjection;
using FS.Abp.MediatR;

namespace FS.CmsKit.ContentDefinitions;

[DependsOn(typeof(FS.CmsKit.CmsKitDomainSharedModule))]
[DependsOn(typeof(FS.Abp.MediatR.AbpMediatRCoreModule))]
[DependsOn(typeof(Volo.Abp.TextTemplating.AbpTextTemplatingCoreModule))]
public class ContentDefinitionsDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ContentDefinitionsDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CmsKitResource>()
                .AddVirtualJson("/Localization/ContentDefinitions");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("ContentDefinitions", typeof(CmsKitResource));
        });
    }
}
