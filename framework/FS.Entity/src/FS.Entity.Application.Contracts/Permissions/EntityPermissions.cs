using Volo.Abp.Reflection;

namespace FS.Entity.Permissions;

public class EntityPermissions
{
    public const string GroupName = "EntityManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(EntityPermissions));
    }
}
