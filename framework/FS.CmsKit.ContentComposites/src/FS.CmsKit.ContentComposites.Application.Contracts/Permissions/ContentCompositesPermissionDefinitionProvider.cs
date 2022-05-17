using FS.CmsKit.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FS.CmsKit.ContentComposites.Permissions;

public partial class ContentCompositesPermissionDefinitionProvider : PermissionDefinitionProvider
{
    //public override void Define(IPermissionDefinitionContext context)
    //{
    //    var myGroup = context.AddGroup(ContentCompositesPermissions.GroupName, L("Permission:ContentComposites"));
    //}

    //private static LocalizableString L(string name)
    //{
    //    return LocalizableString.Create<ContentCompositesResource>(name);
    //}
}
