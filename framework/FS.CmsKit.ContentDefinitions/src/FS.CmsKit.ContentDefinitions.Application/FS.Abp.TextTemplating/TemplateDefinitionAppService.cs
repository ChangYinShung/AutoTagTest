using FS.CmsKit.ContentDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.TextTemplating;

namespace FS.Abp.TextTemplating
{
    public class TemplateDefinitionAppService : ContentDefinitionsAppService, ITemplateDefinitionAppService
    {
        private readonly ITemplateDefinitionManager templateDefinitionManager;

        public TemplateDefinitionAppService(
            ITemplateDefinitionManager templateDefinitionManager
            )
        {
            this.templateDefinitionManager=templateDefinitionManager;
        }
        public Task<List<string>> GetListAsync()
        {
            return Task.FromResult(templateDefinitionManager.GetAll().Select(x => x.Name).ToList());
        }
    }
}
