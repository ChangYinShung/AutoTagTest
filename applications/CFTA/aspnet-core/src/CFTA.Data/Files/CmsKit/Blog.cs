using FS.Abp.Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTA.Files.CmsKit
{
    [MapToVirtualFile(FilePath = "Files/CmsKit/CmsKit.xlsx", SheetName = "Blog")]
    public class Blog
    {
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
