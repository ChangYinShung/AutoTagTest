using FS.Abp.Emailing.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FS.Abp.Emailing.Permissions;

public class EmailingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void PreDefine(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(EmailingPermissions.GroupName, L("Permission:Emailing"));
    }

    public override void Define(IPermissionDefinitionContext context)
    {
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EmailingResource>(name);
    }
}
