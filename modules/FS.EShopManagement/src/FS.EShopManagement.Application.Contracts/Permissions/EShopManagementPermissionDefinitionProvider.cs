using FS.EShopManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace FS.EShopManagement.Permissions;

public class EShopManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(EShopManagementPermissions.GroupName, L("Permission:EShopManagement"));
        myGroup.AddPermission(EShopManagementPermissions.Menu.Show, L("Permission:Menu:Show"), MultiTenancySides.Host);
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EShopManagementResource>(name);
    }
}
