using FS.Entity.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FS.EntityManagement.Permissions
{
    public class EntityManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.GetGroup(EntityManagementPermissions.GroupName);
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<EntityResource>(name);
        }
    }
}


