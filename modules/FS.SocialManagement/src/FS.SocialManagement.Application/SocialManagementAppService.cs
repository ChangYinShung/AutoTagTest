using FS.Social.Localization;
using Volo.Abp.Application.Services;

namespace FS.SocialManagement;

public abstract class SocialManagementAppService : ApplicationService
{
    protected SocialManagementAppService()
    {
        LocalizationResource = typeof(SocialResource);
        ObjectMapperContext = typeof(SocialManagementApplicationModule);
    }
}
