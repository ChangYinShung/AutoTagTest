using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FS.CmsKit.EntityMedias.Dtos
{
    public class PatchEntityMediaItems
    {
        [Required]
        public string EntityId { get; set; }

        [Required]
        public string EntityType { get; set; }

        [Required]
        public string GroupName { get; set; }

        public List<PatchEntityMediaItemDto> Items { get; set; } = new List<PatchEntityMediaItemDto>();
    }

    public class PatchEntityMediaItemDto
    {
        public string Name { get; set; }

        public Guid MediaDescriptorId { get; set; }
    }
}
