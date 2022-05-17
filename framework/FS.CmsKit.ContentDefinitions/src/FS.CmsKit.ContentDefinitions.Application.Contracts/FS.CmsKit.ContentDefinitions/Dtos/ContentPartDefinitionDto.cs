using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace FS.CmsKit.ContentDefinitions.Dtos
{
    namespace V1
    {
        public partial class ContentPartDefinitionPatchDto
        {
            public Guid ContentDefinitionId { get; set; }

            public virtual string Name { get; set; }

            public virtual string Type { get; set; }

            public virtual string TextTemplateContentName { get; set; }

        }

    }
    
}
