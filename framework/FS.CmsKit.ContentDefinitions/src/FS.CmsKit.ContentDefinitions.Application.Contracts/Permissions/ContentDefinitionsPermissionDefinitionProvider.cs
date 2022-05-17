using FS.CmsKit.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FS.CmsKit.ContentDefinitions.Permissions;

public partial class ContentDefinitionsPermissionDefinitionProvider : PermissionDefinitionProvider
{
    //public override void Define(IPermissionDefinitionContext context)
    //{
    //    var myGroup = context.AddGroup(ContentDefinitionsPermissions.GroupName, L("Permission:ContentDefinitions"));
    //}

    //private static LocalizableString L(string name)
    //{
    //    return LocalizableString.Create<ContentDefinitionsResource>(name);
    //}
}
