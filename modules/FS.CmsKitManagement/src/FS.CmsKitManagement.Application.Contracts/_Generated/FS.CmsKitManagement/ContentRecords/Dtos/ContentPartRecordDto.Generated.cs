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

namespace FS.CmsKitManagement.ContentRecords.Dtos
{

    public partial class ContentPartRecordDto : Volo.Abp.Application.Dtos.ExtensibleAuditedEntityDto<Guid>
    {
        public virtual System.Guid ContentPartDefinitionId { get; set; }

        public virtual System.Guid? TenantId { get; set; }

        public virtual System.Guid ContentTypeRecordId { get; set; }

    }

    public partial class ContentPartRecordCreateDto
    {
        public virtual System.Guid ContentPartDefinitionId { get; set; }

        public virtual System.Guid? TenantId { get; set; }

        public virtual System.Guid ContentTypeRecordId { get; set; }

    }

    public partial class ContentPartRecordUpdateDto
    {
        public virtual System.Guid ContentPartDefinitionId { get; set; }

        public virtual System.Guid? TenantId { get; set; }

        public virtual System.Guid ContentTypeRecordId { get; set; }

    }

    public partial class ContentPartRecordGetListDto : PagedAndSortedResultRequestDto
    {
    }

    public partial class ContentPartRecordWithDetailsDto : ContentPartRecordDto
    {
        public List<ContentPartFieldRecordDto> ContentPartFieldRecords { get; set; }

    }
}
