using FS.Social.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FS.Social.LineNotify.Permissions;

public class LineNotifyPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void PreDefine(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(LineNotifyPermissions.GroupName, L("Permission:LineNotify"));
    }

    public override void Define(IPermissionDefinitionContext context)
    {
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SocialResource>(name);
    }
}
