using System;
using System.Linq;
using System.Collections.Generic;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using System.Threading.Tasks;
using FS.Social.Codes.EntityFrameworkCore;

namespace FS.Social.Codes.EntityFrameworkCore
{
    public partial class EfCoreCodeRepository
    {
        public async Task InsertOrUpdateAsync(
            string name,
            string providerName, string providerKey,
            string value)
        {
            var query = await this.GetQueryableAsync();

            var entity = query
                .Where(x =>
                x.Name==name&&
                x.ProviderName==providerName&&
                x.ProviderKey==providerKey)
                .SingleOrDefault();

            bool isExist = entity!=null;

            if (!isExist)
            {
                entity=new Code(GuidGenerator.Create())
                {
                    Name=name,
                    ProviderKey=providerKey,
                    ProviderName=providerName
                };
            }

            entity.Value=value;

            if (isExist)
            {
                await this.UpdateAsync(entity, true);
            }
            else
            {
                await this.InsertAsync(entity, true);
            }
        }
    }
}
