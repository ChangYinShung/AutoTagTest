using FS.Social.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.Social.Blazor.Server.Host;

public abstract class SocialComponentBase : AbpComponentBase
{
    protected SocialComponentBase()
    {
        LocalizationResource = typeof(SocialResource);
    }
}
