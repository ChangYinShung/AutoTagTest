using FS.Abp.Npoi.Mapper.Attributes;
using Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTA.Files.Frm
{
    [MapToVirtualFile(FilePath = "Files/Frm/Frm.xlsx", SheetName = "Form")]
    public class Form
    {
        [Column("_No")]
        public string No { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
