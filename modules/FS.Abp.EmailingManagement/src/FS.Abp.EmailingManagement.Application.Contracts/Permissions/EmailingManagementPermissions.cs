using Volo.Abp.Reflection;

namespace FS.Abp.EmailingManagement.Permissions;

public class EmailingManagementPermissions
{
    public const string GroupName = "EmailingManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(EmailingManagementPermissions));
    }
}
