using FS.Payment.EcPay.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FS.Payment.EcPay.Permissions;

public class EcPayPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(EcPayPermissions.GroupName, L("Permission:EcPay"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EcPayResource>(name);
    }
}
