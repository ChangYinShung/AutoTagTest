﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by YinChang.
// 5.1.3
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using Volo.Abp.Reflection;

namespace FS.CmsKit.EntityMedias.Permissions
{
    public class EntityMediasPermissionNames
    {
        public const string ModuleName = "FS.CmsKit.EntityMedias";
        public static class EntityMedia
        {
            public const string Default = ModuleName + ".EntityMedia";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }
        public static class EntityMediaGroup
        {
            public const string Default = ModuleName + ".EntityMediaGroup";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }
        public static class EntityMediaItem
        {
            public const string Default = ModuleName + ".EntityMediaItem";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }
        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(EntityMediasPermissionNames));
        }
    }
}