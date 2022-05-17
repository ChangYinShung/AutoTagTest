using FS.Entity.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using FS.Entity.Permissions;

namespace FS.Entity.EntityFeatures.Permissions;

public partial class EntityFeaturesPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.GetGroup(EntityPermissions.GroupName);
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EntityResource>(name);
    }
}
