using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace FS.CmsKit.ContentDefinitions.Dtos
{
    namespace V1
    {

        public partial class ContentDefinitionWithDetailsDto : Volo.Abp.Application.Dtos.ExtensibleAuditedEntityDto<Guid>
        {
            public virtual string Version { get; set; }

            public virtual bool IsPublish { get; set; }

            public List<ContentTypeDefinitionWithDetailsDto> ContentTypeDefinitions { get; set; }

            public List<ContentPartDefinitionWithDetailsDto> ContentPartDefinitions { get; set; }

        }
    }

}
