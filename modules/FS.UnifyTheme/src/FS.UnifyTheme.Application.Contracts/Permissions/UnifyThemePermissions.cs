using Volo.Abp.Reflection;

namespace FS.UnifyTheme.Permissions
{
    public class UnifyThemePermissions
    {
        public const string GroupName = "UnifyTheme";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(UnifyThemePermissions));
        }
    }
}