using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FS.CmsKit.EntityMedias.Dtos
{
    public class GetListByEntityMediaGroup
    {
        [Required]
        public string EntityType { get; set; }

        [Required]
        public string EntityId { get; set; }

        public string GroupName { get; set; }
    }
}
