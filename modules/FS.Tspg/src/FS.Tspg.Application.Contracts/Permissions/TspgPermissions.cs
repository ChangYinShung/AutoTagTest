using Volo.Abp.Reflection;

namespace FS.Tspg.Permissions;

public class TspgPermissions
{
    public const string GroupName = "Tspg";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(TspgPermissions));
    }
}
