using FS.Abp.Npoi.Mapper.Attributes;
using Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTA.Files.CmsKit
{
    [MapToVirtualFile(FilePath = "Files/CmsKit/CmsKit.xlsx", SheetName = "BlogPost")]
    public class BlogPost
    {
        [Column("_BlogSlug")]
        public string BlogSlug { get; set; }

        [Column("_CoverImageName")]
        public string CoverImageName { get; set; }

        public string Title { get; set; }
        public string Slug { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
    }
}
