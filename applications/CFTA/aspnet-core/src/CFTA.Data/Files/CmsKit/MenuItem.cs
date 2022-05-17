using FS.Abp.Npoi.Mapper.Attributes;
using Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTA.Files.CmsKit
{
    [LevelStartAt(5)]
    [MapToVirtualFile(FilePath = "Files/CmsKit/CmsKit.xlsx", SheetName = "MenuItem")]
    public class MenuItem : FS.Abp.Npoi.Mapper.ITreeNode<MenuItem>
    {
        public List<MenuItem> Children { get; set; }
        public string Code { get; set; }

        [Column("_PageSlug")]
        public string PageSlug { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string Target { get; set; }
    }
}
