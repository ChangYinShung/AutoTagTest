using FS.Abp.Npoi.Mapper.Attributes;
using FS.CmsKit.EntityMedias;
using Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTA.Files.CmsKit
{
    [MapToVirtualFile(FilePath = "Files/CmsKit/CmsKit.xlsx", SheetName = "EntityMediaGroup")]
    public class EntityMediaGroup
    {
        [Column("_EntityType")]
        public string EntityType { get; set; }

        public string Name { get; set; }

        public MediaType MediaType { get; set; }
    }
}
