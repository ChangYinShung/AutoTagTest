using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FS.CmsKitManagement.MediaDescriptors.Dtos
{
    public class MediaDescriptorGetListDto
    {
        public string EntityType { get; set; }

        public string Prefix { get; set; }
    }
}
