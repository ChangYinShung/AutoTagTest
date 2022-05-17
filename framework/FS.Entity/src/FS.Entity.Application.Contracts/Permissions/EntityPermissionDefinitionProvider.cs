using FS.Entity.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FS.Entity.Permissions;

public class EntityPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(EntityPermissions.GroupName, L("Permission:Entity"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EntityResource>(name);
    }
}
