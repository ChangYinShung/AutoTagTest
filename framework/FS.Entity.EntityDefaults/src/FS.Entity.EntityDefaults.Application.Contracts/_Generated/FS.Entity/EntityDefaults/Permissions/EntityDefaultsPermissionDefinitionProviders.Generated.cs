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
using FS.Entity.Localization;
using FS.Entity.Permissions;

namespace FS.Entity.EntityDefaults.Permissions
{
    public partial class EntityDefaultsPermissionDefinitionProvider : Volo.Abp.Authorization.Permissions.PermissionDefinitionProvider
    {
        public override void Define(Volo.Abp.Authorization.Permissions.IPermissionDefinitionContext context)
        {
            var group = context.GetGroup(EntityPermissions.GroupName);

            var EntityDefault = group.AddPermission(EntityDefaultsPermissionNames.EntityDefault.Default,L(EntityDefaultsPermissionNames.EntityDefault.Default));
            EntityDefault.AddChild(EntityDefaultsPermissionNames.EntityDefault.Create , L("DisplayName:EntityDefault.Create"));
            EntityDefault.AddChild(EntityDefaultsPermissionNames.EntityDefault.Update , L("DisplayName:EntityDefault.Update"));
            EntityDefault.AddChild(EntityDefaultsPermissionNames.EntityDefault.Delete , L("DisplayName:EntityDefault.Delete"));

            var EntityDefaultItem = group.AddPermission(EntityDefaultsPermissionNames.EntityDefaultItem.Default,L(EntityDefaultsPermissionNames.EntityDefaultItem.Default));
            EntityDefaultItem.AddChild(EntityDefaultsPermissionNames.EntityDefaultItem.Create , L("DisplayName:EntityDefaultItem.Create"));
            EntityDefaultItem.AddChild(EntityDefaultsPermissionNames.EntityDefaultItem.Update , L("DisplayName:EntityDefaultItem.Update"));
            EntityDefaultItem.AddChild(EntityDefaultsPermissionNames.EntityDefaultItem.Delete , L("DisplayName:EntityDefaultItem.Delete"));

            CustomizeDefine(context);
        }

        partial void CustomizeDefine(Volo.Abp.Authorization.Permissions.IPermissionDefinitionContext context);

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<EntityResource>(name);
        }
    }
}
