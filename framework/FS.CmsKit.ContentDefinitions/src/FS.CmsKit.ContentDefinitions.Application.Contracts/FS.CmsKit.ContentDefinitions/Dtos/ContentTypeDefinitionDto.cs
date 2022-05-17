using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace FS.CmsKit.ContentDefinitions.Dtos
{
    namespace V1
    {
        public partial class ContentTypeDefinitionPatchDto
        {
            public Guid ContentDefinitionId { get; set; }

            public virtual string EntityType { get; set; }

            public virtual string EntityId { get; set; }

            public virtual List<Guid> ContentPartDefinitionIds { get; set; }

        }

    }
    
}
