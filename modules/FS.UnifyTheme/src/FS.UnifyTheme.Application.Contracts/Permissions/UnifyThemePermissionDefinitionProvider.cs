using FS.UnifyTheme.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FS.UnifyTheme.Permissions
{
    public class UnifyThemePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(UnifyThemePermissions.GroupName, L("Permission:UnifyTheme"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<UnifyThemeResource>(name);
        }
    }
}