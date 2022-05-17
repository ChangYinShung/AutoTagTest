using FS.CmsKit.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FS.CmsKit.Permissions;

public class CmsKitPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void PreDefine(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CmsKitPermissions.GroupName, L("Permission:CmsKit"));
    }
    public override void Define(IPermissionDefinitionContext context)
    {
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CmsKitResource>(name);
    }
}
