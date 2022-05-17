using FS.Payment.Tspg.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FS.Payment.Tspg.Permissions;

public class TspgPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TspgPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(TspgPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TspgResource>(name);
    }
}
