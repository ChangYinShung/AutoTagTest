//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by YinChang.
// 5.1.3
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace FS.CmsKit.ContentComposites.Dtos
{

    public partial class ContentComponentDto : Volo.Abp.Application.Dtos.ExtensibleAuditedEntityDto<Guid>
    {
        public virtual System.Guid? ContentEntityId { get; set; }

        public virtual string Code { get; set; }

        public virtual System.Guid? ParentId { get; set; }

        public virtual int Level { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual string ContentComponentDiscriminator { get; set; }

    }

    public partial class ContentComponentCreateDto
    {
        public virtual System.Guid? ContentEntityId { get; set; }

        public virtual string Code { get; set; }

        public virtual System.Guid? ParentId { get; set; }

        public virtual int Level { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual string ContentComponentDiscriminator { get; set; }

    }

    public partial class ContentComponentUpdateDto
    {
        public virtual System.Guid? ContentEntityId { get; set; }

        public virtual string Code { get; set; }

        public virtual System.Guid? ParentId { get; set; }

        public virtual int Level { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual string ContentComponentDiscriminator { get; set; }

    }

    public partial class ContentComponentGetListDto : PagedAndSortedResultRequestDto
    {
        public virtual string ContentComponentDiscriminator { get; set; }

    }

    public partial class ContentComponentWithDetailsDto : ContentComponentDto
    {
        public List<ContentComponentDto> Children { get; set; }

        public ContentComponentDto Parent { get; set; }

    }
}
