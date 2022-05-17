using FS.Social.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.SocialManagement;

public abstract class SocialManagementController : AbpControllerBase
{
    protected SocialManagementController()
    {
        LocalizationResource = typeof(SocialResource);
    }
}
