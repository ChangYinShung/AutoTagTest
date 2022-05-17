using Volo.Abp.Reflection;

namespace FS.CmsKit.Permissions;

public class CmsKitPermissions
{
    public const string GroupName = "CmsKitManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CmsKitPermissions));
    }
}
