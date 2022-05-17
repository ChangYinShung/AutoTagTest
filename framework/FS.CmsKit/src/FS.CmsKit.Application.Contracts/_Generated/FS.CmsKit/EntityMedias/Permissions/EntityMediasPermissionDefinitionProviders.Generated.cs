﻿//------------------------------------------------------------------------------
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

namespace FS.CmsKit.EntityMedias.Permissions
{
    public partial class EntityMediasPermissionDefinitionProvider : Volo.Abp.Authorization.Permissions.PermissionDefinitionProvider
    {
        public override void Define(Volo.Abp.Authorization.Permissions.IPermissionDefinitionContext context)
        {
            var group = context.GetGroup(CmsKitPermissions.GroupName);

            var EntityMedia = group.AddPermission(EntityMediasPermissionNames.EntityMedia.Default,L(EntityMediasPermissionNames.EntityMedia.Default));
            EntityMedia.AddChild(EntityMediasPermissionNames.EntityMedia.Create , L("DisplayName:EntityMedia.Create"));
            EntityMedia.AddChild(EntityMediasPermissionNames.EntityMedia.Update , L("DisplayName:EntityMedia.Update"));
            EntityMedia.AddChild(EntityMediasPermissionNames.EntityMedia.Delete , L("DisplayName:EntityMedia.Delete"));

            var EntityMediaGroup = group.AddPermission(EntityMediasPermissionNames.EntityMediaGroup.Default,L(EntityMediasPermissionNames.EntityMediaGroup.Default));
            EntityMediaGroup.AddChild(EntityMediasPermissionNames.EntityMediaGroup.Create , L("DisplayName:EntityMediaGroup.Create"));
            EntityMediaGroup.AddChild(EntityMediasPermissionNames.EntityMediaGroup.Update , L("DisplayName:EntityMediaGroup.Update"));
            EntityMediaGroup.AddChild(EntityMediasPermissionNames.EntityMediaGroup.Delete , L("DisplayName:EntityMediaGroup.Delete"));

            var EntityMediaItem = group.AddPermission(EntityMediasPermissionNames.EntityMediaItem.Default,L(EntityMediasPermissionNames.EntityMediaItem.Default));
            EntityMediaItem.AddChild(EntityMediasPermissionNames.EntityMediaItem.Create , L("DisplayName:EntityMediaItem.Create"));
            EntityMediaItem.AddChild(EntityMediasPermissionNames.EntityMediaItem.Update , L("DisplayName:EntityMediaItem.Update"));
            EntityMediaItem.AddChild(EntityMediasPermissionNames.EntityMediaItem.Delete , L("DisplayName:EntityMediaItem.Delete"));

            CustomizeDefine(context);
        }

        partial void CustomizeDefine(Volo.Abp.Authorization.Permissions.IPermissionDefinitionContext context);

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CmsKitResource>(name);
        }
    }
}
