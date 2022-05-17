using FS.Social.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FS.Social.Permissions;

public class SocialPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void PreDefine(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SocialPermissions.GroupName, L("Permission:Social"));
    }
    public override void Define(IPermissionDefinitionContext context)
    {
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SocialResource>(name);
    }
}
