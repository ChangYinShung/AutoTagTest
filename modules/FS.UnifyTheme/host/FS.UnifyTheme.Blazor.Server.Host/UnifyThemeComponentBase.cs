using FS.UnifyTheme.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.UnifyTheme.Blazor.Server.Host
{
    public abstract class UnifyThemeComponentBase : AbpComponentBase
    {
        protected UnifyThemeComponentBase()
        {
            LocalizationResource = typeof(UnifyThemeResource);
        }
    }
}
