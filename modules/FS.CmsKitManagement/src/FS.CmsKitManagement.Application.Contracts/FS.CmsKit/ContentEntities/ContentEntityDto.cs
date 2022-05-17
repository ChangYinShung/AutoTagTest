using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace FS.CmsKit.ContentEntities.Dtos
{
    public partial class ContentEntityGetListDto : PagedAndSortedResultRequestDto
    {
        public string EntityType { get; set; }
    }
}
