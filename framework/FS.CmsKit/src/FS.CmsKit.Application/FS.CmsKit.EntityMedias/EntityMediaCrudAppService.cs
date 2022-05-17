using FS.CmsKit.EntityMedias.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFilterer.Extensions;

namespace FS.CmsKit.EntityMedias
{
    [Volo.Abp.RemoteService(false)]
    public partial class EntityMediaCrudAppService { }

    namespace V1
    {
        public partial class EntityMediaCrudAppService :
           Volo.Abp.Application.Services.ReadOnlyAppService<
               FS.CmsKit.EntityMedias.EntityMedia,
               FS.CmsKit.EntityMedias.Dtos.EntityMediaWithDetailsDto,
               FS.CmsKit.EntityMedias.Dtos.EntityMediaDto,
               Guid,
               FS.CmsKit.EntityMedias.Dtos.EntityMediaGetListDto>,
           IEntityMediaCrudAppService
        {

            private readonly IEntityMediaRepository _repository;

            public EntityMediaCrudAppService(IEntityMediaRepository repository) : base(repository)
            {
                this._repository = repository;
            }

            public async Task<Dtos.EntityMediaWithDetailsDto> GetFindByEntityTypeAsync(string entityType)
            {
                //todo:check option

                var filter = new FS.CmsKit.EntityMedias.EntityMediaAutoFilter(entityType);

                var query = await _repository.WithDetailsAsync();

                var entity = await this.AsyncExecuter.SingleOrDefaultAsync(query.ApplyFilter(filter));

                return await MapToGetOutputDtoAsync(entity);
            }
        }
    }
   
}
