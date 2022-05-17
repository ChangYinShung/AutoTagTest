using FS.EShopManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.EShopManagement;

public abstract class EShopManagementController : AbpControllerBase
{
    protected EShopManagementController()
    {
        LocalizationResource = typeof(EShopManagementResource);
    }
}
