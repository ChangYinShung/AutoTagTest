using FS.Abp.Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTA.Files.EShop
{
    [MapToVirtualFile(FilePath = "Files/EShop/EShop.xlsx", SheetName = "Store")]
    public class Store
    {
        public string UniqueName { get; set; }

        public string Name { get; set; }
    }
}
