using Volo.Abp.Reflection;

namespace FS.EShopManagement.Permissions;

public class EShopManagementPermissions
{
    public const string GroupName = "EShopManagement";

    public static class Menu
    {
        public const string Show = GroupName + ".Show";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(EShopManagementPermissions));
    }
}
