//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by YinChang.
// 5.1.3
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using Volo.Abp.Localization;
using FS.CmsKit.Localization;
using FS.CmsKit.Permissions;

namespace FS.CmsKit.ContentEntities.Permissions
{
    public partial class ContentEntitiesPermissionDefinitionProvider : Volo.Abp.Authorization.Permissions.PermissionDefinitionProvider
    {
        public override void Define(Volo.Abp.Authorization.Permissions.IPermissionDefinitionContext context)
        {
            var group = context.GetGroup(CmsKitPermissions.GroupName);

            var ContentEntity = group.AddPermission(ContentEntitiesPermissionNames.ContentEntity.Default,L(ContentEntitiesPermissionNames.ContentEntity.Default));
            ContentEntity.AddChild(ContentEntitiesPermissionNames.ContentEntity.Create , L("DisplayName:ContentEntity.Create"));
            ContentEntity.AddChild(ContentEntitiesPermissionNames.ContentEntity.Update , L("DisplayName:ContentEntity.Update"));
            ContentEntity.AddChild(ContentEntitiesPermissionNames.ContentEntity.Delete , L("DisplayName:ContentEntity.Delete"));

            CustomizeDefine(context);
        }

        partial void CustomizeDefine(Volo.Abp.Authorization.Permissions.IPermissionDefinitionContext context);

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CmsKitResource>(name);
        }
    }
}
