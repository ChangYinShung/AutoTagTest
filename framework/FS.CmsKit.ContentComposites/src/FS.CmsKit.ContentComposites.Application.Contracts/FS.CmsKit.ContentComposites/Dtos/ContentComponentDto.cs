
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace FS.CmsKit.ContentComposites.Dtos
{
    namespace V1 
    {
        public partial class ContentComponentPatchDto
        {
            public virtual System.Guid? ContentEntityId { get; set; }

            public virtual System.Guid? ParentId { get; set; }

            public virtual string DisplayName { get; set; }

            public virtual string ContentComponentDiscriminator { get; set; }

        }
    }
}
