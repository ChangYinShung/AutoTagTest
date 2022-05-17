using System.Collections.Generic;
using System.Threading.Tasks;

namespace FS.Abp.TextTemplating
{
    public interface ITemplateDefinitionAppService
    {
        Task<List<string>> GetListAsync();
    }
}