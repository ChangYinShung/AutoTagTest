﻿using Volo.Abp.Reflection;

namespace FS.PaymentService.Permissions;

public class PaymentServicePermissions
{
    public const string GroupName = "PaymentService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(PaymentServicePermissions));
    }
}
