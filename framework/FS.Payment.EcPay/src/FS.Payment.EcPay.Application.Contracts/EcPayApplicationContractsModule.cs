﻿using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FS.Payment.EcPay;

[DependsOn(
    typeof(EcPayDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class EcPayApplicationContractsModule : AbpModule
{

}
