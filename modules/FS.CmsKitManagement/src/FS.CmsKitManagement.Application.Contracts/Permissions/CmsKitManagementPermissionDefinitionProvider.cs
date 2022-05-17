using FS.CmsKitManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace FS.CmsKitManagement.Permissions
{
    public class CmsKitManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.GetGroup(CmsKitManagementPermissions.GroupName);
            myGroup.AddPermission(CmsKitManagementPermissions.Menu.Show, L("Permission:Menu:Show"), MultiTenancySides.Host);
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CmsKitManagementResource>(name);
        }
    }
}