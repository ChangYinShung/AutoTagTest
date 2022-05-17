using Volo.Abp.Reflection;

namespace FS.CmsKit.ContentComposites.Permissions;

public class ContentCompositesPermissions
{
    public const string GroupName = "ContentComposites";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ContentCompositesPermissions));
    }
}
