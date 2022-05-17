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
using FS.CmsKitManagement.Localization;
using FS.CmsKitManagement.Permissions;

namespace FS.CmsKitManagement.ContentRecords.Permissions
{
    public partial class ContentRecordsPermissionDefinitionProvider : Volo.Abp.Authorization.Permissions.PermissionDefinitionProvider
    {
        public override void Define(Volo.Abp.Authorization.Permissions.IPermissionDefinitionContext context)
        {
            var group = context.GetGroup(CmsKitManagementPermissions.GroupName);

            var ContentTypeRecord = group.AddPermission(ContentRecordsPermissionNames.ContentTypeRecord.Default,L(ContentRecordsPermissionNames.ContentTypeRecord.Default));
            ContentTypeRecord.AddChild(ContentRecordsPermissionNames.ContentTypeRecord.Create , L("DisplayName:ContentTypeRecord.Create"));
            ContentTypeRecord.AddChild(ContentRecordsPermissionNames.ContentTypeRecord.Update , L("DisplayName:ContentTypeRecord.Update"));
            ContentTypeRecord.AddChild(ContentRecordsPermissionNames.ContentTypeRecord.Delete , L("DisplayName:ContentTypeRecord.Delete"));

            var ContentPartFieldRecord = group.AddPermission(ContentRecordsPermissionNames.ContentPartFieldRecord.Default,L(ContentRecordsPermissionNames.ContentPartFieldRecord.Default));
            ContentPartFieldRecord.AddChild(ContentRecordsPermissionNames.ContentPartFieldRecord.Create , L("DisplayName:ContentPartFieldRecord.Create"));
            ContentPartFieldRecord.AddChild(ContentRecordsPermissionNames.ContentPartFieldRecord.Update , L("DisplayName:ContentPartFieldRecord.Update"));
            ContentPartFieldRecord.AddChild(ContentRecordsPermissionNames.ContentPartFieldRecord.Delete , L("DisplayName:ContentPartFieldRecord.Delete"));

            var ContentPartRecord = group.AddPermission(ContentRecordsPermissionNames.ContentPartRecord.Default,L(ContentRecordsPermissionNames.ContentPartRecord.Default));
            ContentPartRecord.AddChild(ContentRecordsPermissionNames.ContentPartRecord.Create , L("DisplayName:ContentPartRecord.Create"));
            ContentPartRecord.AddChild(ContentRecordsPermissionNames.ContentPartRecord.Update , L("DisplayName:ContentPartRecord.Update"));
            ContentPartRecord.AddChild(ContentRecordsPermissionNames.ContentPartRecord.Delete , L("DisplayName:ContentPartRecord.Delete"));

            CustomizeDefine(context);
        }

        partial void CustomizeDefine(Volo.Abp.Authorization.Permissions.IPermissionDefinitionContext context);

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CmsKitManagementResource>(name);
        }
    }
}