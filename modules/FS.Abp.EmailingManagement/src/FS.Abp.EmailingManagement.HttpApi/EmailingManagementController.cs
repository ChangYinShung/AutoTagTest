using FS.Abp.EmailingManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.Abp.EmailingManagement;

public abstract class EmailingManagementController : AbpControllerBase
{
    protected EmailingManagementController()
    {
        LocalizationResource = typeof(EmailingManagementResource);
    }
}
