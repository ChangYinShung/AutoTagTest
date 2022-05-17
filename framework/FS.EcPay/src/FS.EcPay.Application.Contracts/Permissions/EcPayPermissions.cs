using Volo.Abp.Reflection;

namespace FS.EcPay.Permissions;

public class EcPayPermissions
{
    public const string GroupName = "EcPay";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(EcPayPermissions));
    }
}
