using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;


namespace FS.CmsKit.EntityMedias
{
    public class EntityMediaItemAppService : CmsKitAppService, IEntityMediaItemAppService
    {
        private IEntityMediaItemRepository EntityMediaItemRepository => this.LazyServiceProvider.LazyGetRequiredService<IEntityMediaItemRepository>();

        public async Task<List<Dtos.EntityMediaItemDto>> GetAsync(Dtos.GetListByEntityMediaGroup input)
        {
            var filter = new EntityMediaItemAutoFilter(input.EntityId, input.EntityType, input.GroupName);
            var query = await this.EntityMediaItemRepository.GetQueryableAsync();
            var result = await this.AsyncExecuter.ToListAsync(filter.ApplyFilterTo(query));

            return ObjectMapper.Map<List<EntityMediaItem>, List<Dtos.EntityMediaItemDto>>(result);
                //await MapToGetListOutputDtosAsync(result);
        }

        public async Task PatchAsync(Dtos.PatchEntityMediaItems input)
        {
            // 刪除現有資料
            var filter = new EntityMediaItemAutoFilter(input.EntityId, input.EntityType, input.GroupName);
            var query = await this.EntityMediaItemRepository.GetQueryableAsync();
            var datas = await this.AsyncExecuter.ToListAsync(filter.ApplyFilterTo(query));

            await this.EntityMediaItemRepository.DeleteManyAsync(datas);

            // 新增資料
            var insertDatas = input.Items
                .Select(x => {
                    var item = new EntityMediaItem()
                    {
                        Name = x.Name,
                        EntityId = input.EntityId,
                        EntityType = input.EntityType,
                        MediaDescriptorId = x.MediaDescriptorId,
                        EntityMediaGroupName = input.GroupName,
                        TenantId = this.CurrentTenant.Id
                    };
                    EntityHelper.TrySetId(item, this.GuidGenerator.Create);
                    return item;
                })
                .ToList();

            await this.EntityMediaItemRepository.InsertManyAsync(insertDatas);
        }
    }
}
