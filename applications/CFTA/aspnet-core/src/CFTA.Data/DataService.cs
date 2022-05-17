using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Security.Claims;
using Volo.Abp.Uow;
using Volo.CmsKit.Admin.MediaDescriptors;

namespace CFTA.Data
{
    public class DataService : Volo.Abp.Domain.Services.DomainService
    {
        private IMediaDescriptorAdminAppService MediaDescriptorAdminAppService => this.LazyServiceProvider.LazyGetRequiredService<IMediaDescriptorAdminAppService>();

        [UnitOfWork]
        public virtual async Task<ClaimsPrincipal> CreateClaimsPrincipalAsync(string userName)
        {
            var userRepository = this.LazyServiceProvider.LazyGetRequiredService<IIdentityUserRepository>();
            var LookupNormalizer = this.LazyServiceProvider.LazyGetRequiredService<ILookupNormalizer>();
            var abpUserClaimsPrincipalFactory = this.LazyServiceProvider.LazyGetRequiredService<AbpUserClaimsPrincipalFactory>();

            ClaimsPrincipal result = null;

            var adminUser = await userRepository.FindByNormalizedUserNameAsync(LookupNormalizer.NormalizeName(userName));

            result = await abpUserClaimsPrincipalFactory.CreateAsync(adminUser);

            return result;
        }

        public virtual async Task ChangeTenantClaimsAsync(Guid? tenantId, Func<Task> action)
        {
            var currentPrincipalAccessor = this.LazyServiceProvider.LazyGetRequiredService<ICurrentPrincipalAccessor>();
            var abpClaimsPrincipalFactory = this.LazyServiceProvider.LazyGetRequiredService<IAbpClaimsPrincipalFactory>();

            try
            {
                using (CurrentTenant.Change(tenantId))
                {

                    const string adminUserName = "admin";

                    ClaimsPrincipal claimsPrincipal = await CreateClaimsPrincipalAsync(adminUserName);

                    using (currentPrincipalAccessor.Change(
                        await abpClaimsPrincipalFactory.CreateAsync(claimsPrincipal)))
                    {

                        await action.Invoke();
                    }

                }
            }
            catch (Exception ex)
            {
            }
        }


        /// <summary>
        /// 建立檔案
        /// </summary>
        public async Task<List<MediaDescriptorDto>> CreateMediaDesciptorsAsync(string entityType, List<IFileInfo> files)
        {
            return (await files.SelectAsync(async (file) =>
            {
                MediaDescriptorDto item;
                using (Stream fs = file.CreateReadStream())
                {
                    item = await this.MediaDescriptorAdminAppService.CreateAsync(
                        entityType,
                        new CreateMediaInputWithStream()
                        {
                            File = new Volo.Abp.Content.RemoteStreamContent(fs),
                            Name = file.Name
                        });
                }
                return item;
            })).ToList();
        }
    }
}
