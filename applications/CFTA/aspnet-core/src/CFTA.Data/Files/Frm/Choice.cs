using FS.Abp.Npoi.Mapper.Attributes;
using Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTA.Files.Frm
{
    [MapToVirtualFile(FilePath = "Files/Frm/Frm.xlsx", SheetName = "Choice")]
    public class Choice
    {
        [Column("_QuestionNo")]
        public string QuestionNo { get; set; }

        public string Value { get; set; }
    }
}
