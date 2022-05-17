using FS.Abp.EmailingManagement.Localization;
using Volo.Abp.Application.Services;

namespace FS.Abp.EmailingManagement;

public abstract class EmailingManagementAppService : ApplicationService
{
    protected EmailingManagementAppService()
    {
        LocalizationResource = typeof(EmailingManagementResource);
        ObjectMapperContext = typeof(EmailingManagementApplicationModule);
    }
}
