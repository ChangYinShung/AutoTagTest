using FS.Abp.Npoi.Mapper.Attributes;
using Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTA.Files.Frm
{
    [MapToVirtualFile(FilePath = "Files/Frm/Frm.xlsx", SheetName = "Question")]
    public class Question
    {
        [Column("_FormNo")]
        public string FormNo { get; set; }

        [Column("_No")]
        public string No { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public bool HasOtherOption { get; set; }
        public string QuestionType { get; set; }
    }
}
