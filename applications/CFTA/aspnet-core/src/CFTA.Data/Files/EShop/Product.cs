using FS.Abp.Npoi.Mapper.Attributes;
using Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTA.Files.EShop
{
    [MapToVirtualFile(FilePath = "Files/EShop/EShop.xlsx", SheetName = "Product")]
    public class Product
    {
        public string StoreUniqueName { get; set; }
        public string UniqueName { get; set; }
        public string Name { get; set; }
        public string CategoryUniqueName { get; set; }
        public string Description { get; set; }

        [Column("_DefaultPrice")]
        public int DefaultPrice { get; set; }

        [Column("_MediaResourcesName")]
        public string MediaResourcesName { get; set; }
    }
}
