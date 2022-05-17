using FS.Entity.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using FS.Entity.Permissions;

namespace FS.Entity.MultiLinguals.Permissions
{
    public partial class MultiLingualsPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        partial void CustomizeDefine(IPermissionDefinitionContext context)
        {
            var myGroup = context.GetGroup(EntityPermissions.GroupName);
        }
    }
}


