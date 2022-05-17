using FS.Tspg.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FS.Tspg.Permissions;

public class TspgPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TspgPermissions.GroupName, L("Permission:Tspg"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TspgResource>(name);
    }
}
