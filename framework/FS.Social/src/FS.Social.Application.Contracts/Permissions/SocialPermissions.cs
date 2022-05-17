using Volo.Abp.Reflection;

namespace FS.Social.Permissions;

public class SocialPermissions
{
    public const string GroupName = "SocialManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(SocialPermissions));
    }
}
