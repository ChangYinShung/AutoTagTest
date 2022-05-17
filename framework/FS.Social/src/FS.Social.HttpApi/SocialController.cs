using FS.Social.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.Social;

public abstract class SocialController : AbpControllerBase
{
    protected SocialController()
    {
        LocalizationResource = typeof(SocialResource);
    }
}
