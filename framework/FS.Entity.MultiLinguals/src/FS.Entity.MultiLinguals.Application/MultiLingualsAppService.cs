using FS.Entity.Localization;
using Volo.Abp.Application.Services;

namespace FS.Entity.MultiLinguals
{
    public abstract class MultiLingualsAppService : ApplicationService
    {
        protected MultiLingualsAppService()
        {
            LocalizationResource = typeof(EntityResource);
            ObjectMapperContext = typeof(MultiLingualsApplicationModule);
        }
    }
}


