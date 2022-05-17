using FS.Entity.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using FS.Entity.Permissions;

namespace FS.Entity.EntityDefaults.Permissions
{
    public partial class EntityDefaultsPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        partial void CustomizeDefine(IPermissionDefinitionContext context)
        {
            var myGroup = context.GetGroup(EntityPermissions.GroupName);
        }
    }
}


