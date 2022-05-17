using FS.Abp.Emailing.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FS.Abp.EmailingManagement.Permissions;

public class EmailingManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        //var myGroup = context.AddGroup(EmailingManagementPermissions.GroupName, L("Permission:EmailingManagement"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EmailingResource>(name);
    }
}
