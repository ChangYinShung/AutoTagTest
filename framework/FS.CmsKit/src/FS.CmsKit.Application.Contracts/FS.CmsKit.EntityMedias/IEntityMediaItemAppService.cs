using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FS.CmsKit.EntityMedias
{
    public interface IEntityMediaItemAppService : Volo.Abp.DependencyInjection.ITransientDependency
    {
        Task<List<Dtos.EntityMediaItemDto>> GetAsync(Dtos.GetListByEntityMediaGroup input);
        Task PatchAsync(Dtos.PatchEntityMediaItems input);
    }
}
