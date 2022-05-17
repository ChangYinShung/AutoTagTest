using Volo.Abp.Reflection;

namespace FS.Abp.Emailing.Permissions;

public class EmailingPermissions
{
    public const string GroupName = "Emailing";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(EmailingPermissions));
    }
}
