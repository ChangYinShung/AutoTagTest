using Volo.Abp.Reflection;

namespace FS.CmsKitManagement.Permissions
{
    public class CmsKitManagementPermissions
    {
        public const string GroupName = "CmsKitManagement";
        public static class Menu
        {
            public const string Show = GroupName + ".Show";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CmsKitManagementPermissions));
        }
    }
}