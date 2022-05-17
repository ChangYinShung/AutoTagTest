using Volo.Abp.Reflection;

namespace FS.EntityManagement.Permissions
{
    public class EntityManagementPermissions
    {
        public const string GroupName = "EntityManagement";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(EntityManagementPermissions));
        }
    }
}


