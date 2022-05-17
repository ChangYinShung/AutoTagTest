using FS.Abp.Npoi.Mapper.Attributes;
using Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTA.Files.EShop
{
    [MapToVirtualFile(FilePath = "Files/EShop/EShop.xlsx", SheetName = "ProductAttributeOption")]
    public class ProductAttributeOption
    {
        [Column("ProductAttributeNo")]
        public string ProductAttributeNo { get; set; }

        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}
