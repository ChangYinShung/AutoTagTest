using Volo.Abp.Reflection;

namespace FS.Social.LineNotify.Permissions;

public class LineNotifyPermissions
{
    public const string GroupName = "LineNotify";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(LineNotifyPermissions));
    }
}
