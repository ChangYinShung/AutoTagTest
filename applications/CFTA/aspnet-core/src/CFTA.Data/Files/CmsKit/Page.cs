using FS.Abp.Npoi.Mapper.Attributes;
using Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTA.Files.CmsKit
{
    [MapToVirtualFile(FilePath = "Files/CmsKit/CmsKit.xlsx", SheetName = "Page")]
    public class Page
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
    }
}
