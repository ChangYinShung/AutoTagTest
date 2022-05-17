using FS.Abp.Npoi.Mapper;
using FS.EShopManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Uow;
using Volo.Abp.VirtualFileSystem;
using Volo.CmsKit.Admin.MediaDescriptors;
using IdentityRole = Volo.Abp.Identity.IdentityRole;

namespace CFTA.Data.Identity
{

    public class IdentityDataSeeder : DomainService
    {
        
        
        private ILookupNormalizer LookupNormalizer => this.LazyServiceProvider.LazyGetRequiredService<ILookupNormalizer>();
        private IPermissionManager PermissionManager => this.LazyServiceProvider.LazyGetRequiredService<IPermissionManager>();
        private IIdentityRoleRepository RoleRepository => this.LazyServiceProvider.LazyGetRequiredService<IIdentityRoleRepository>();
        private IOptions<IdentityOptions> IdentityOptions => this.LazyServiceProvider.LazyGetRequiredService<IOptions<IdentityOptions>>();
        const string DefaultRoleName = "Default";

        private IdentityRoleManager RoleManager => this.LazyServiceProvider.LazyGetRequiredService<IdentityRoleManager>();

        [UnitOfWork]
        public virtual async Task<IdentityDataSeedResult> CreateRoleSeedAsync(Guid? tenantId = null)
        {
            using (CurrentTenant.Change(tenantId))
            {
                await IdentityOptions.SetAsync();
                var result = new IdentityDataSeedResult();

                var defaultRole = await RoleRepository.FindByNormalizedNameAsync(LookupNormalizer.NormalizeName(DefaultRoleName));
                if (defaultRole != null)
                {
                    return result;
                }

                //Create Role
                defaultRole = new IdentityRole(GuidGenerator.Create(), DefaultRoleName, tenantId)
                {
                    IsStatic = true,
                    IsPublic = true,
                    IsDefault = true
                    
                };

                (await RoleManager.CreateAsync(defaultRole)).CheckErrors();
                await PermissionManager.SetForRoleAsync(DefaultRoleName, EasyAbp.EShop.Payments.Authorization.PaymentsPermissions.Payments.Manage, true);
                await PermissionManager.SetForRoleAsync(DefaultRoleName, EasyAbp.EShop.Payments.Authorization.PaymentsPermissions.Payments.Default, true);
                await PermissionManager.SetForRoleAsync(DefaultRoleName, EasyAbp.EShop.Payments.Authorization.PaymentsPermissions.Payments.Create, true);
                await PermissionManager.SetForRoleAsync(DefaultRoleName, EasyAbp.EShop.Payments.Authorization.PaymentsPermissions.Refunds.Manage, true);
                await PermissionManager.SetForRoleAsync(DefaultRoleName, EasyAbp.EShop.Payments.Authorization.PaymentsPermissions.Refunds.Default, true);
                await PermissionManager.SetForRoleAsync(DefaultRoleName, EasyAbp.EShop.Payments.Authorization.PaymentsPermissions.Refunds.Create, true);
                await PermissionManager.SetForRoleAsync(DefaultRoleName, EasyAbp.EShop.Orders.Authorization.OrdersPermissions.Orders.Default, true);
                await PermissionManager.SetForRoleAsync(DefaultRoleName, EasyAbp.EShop.Orders.Authorization.OrdersPermissions.Orders.Manage, true);
                await PermissionManager.SetForRoleAsync(DefaultRoleName, EasyAbp.EShop.Orders.Authorization.OrdersPermissions.Orders.CrossStore, true);
                await PermissionManager.SetForRoleAsync(DefaultRoleName, EasyAbp.EShop.Orders.Authorization.OrdersPermissions.Orders.Create, true);
                await PermissionManager.SetForRoleAsync(DefaultRoleName, EasyAbp.EShop.Orders.Authorization.OrdersPermissions.Orders.Cancel, true);
                await PermissionManager.SetForRoleAsync(DefaultRoleName, EasyAbp.PaymentService.Authorization.PaymentServicePermissions.Payments.Manage, true);
                await PermissionManager.SetForRoleAsync(DefaultRoleName, EasyAbp.PaymentService.Authorization.PaymentServicePermissions.Payments.Default, true);
                await PermissionManager.SetForRoleAsync(DefaultRoleName, EasyAbp.PaymentService.Authorization.PaymentServicePermissions.Payments.Create, true);
                result.CreatedAdminRole = false;

                return result;

            }
        }
    }
}
