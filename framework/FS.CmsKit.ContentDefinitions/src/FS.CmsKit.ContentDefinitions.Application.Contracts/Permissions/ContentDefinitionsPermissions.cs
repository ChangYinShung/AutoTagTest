using Volo.Abp.Reflection;

namespace FS.CmsKit.ContentDefinitions.Permissions;

public class ContentDefinitionsPermissions
{
    public const string GroupName = "ContentDefinitions";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ContentDefinitionsPermissions));
    }
}
