using FS.EShopManagement.Localization;
using Volo.Abp.Application.Services;

namespace FS.EShopManagement;

public abstract class EShopManagementAppService : ApplicationService
{
    protected EShopManagementAppService()
    {
        LocalizationResource = typeof(EShopManagementResource);
        ObjectMapperContext = typeof(EShopManagementApplicationModule);
    }
}
