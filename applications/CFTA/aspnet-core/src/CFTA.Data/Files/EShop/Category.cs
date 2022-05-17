using FS.Abp.Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTA.Files.EShop
{
    [LevelStartAt(2)]
    [MapToVirtualFile(FilePath = "Files/EShop/EShop.xlsx", SheetName = "Category")]
    public class Category : FS.Abp.Npoi.Mapper.ITreeNode<Category>
    {
        public List<Category> Children { get; set; }
        public string Code { get; set; }

        public string UniqueName { get; set; }
        public string Name { get; set; }
    }
}
