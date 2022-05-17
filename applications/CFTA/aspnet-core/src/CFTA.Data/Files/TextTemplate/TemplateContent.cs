using FS.Abp.Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTA.Files.TextTemplate
{
    [MapToVirtualFile(FilePath = "Files/TextTemplate/TextTemplate.xlsx", SheetName = "TemplateContent")]
    public class TemplateContent
    {
        public string Content { get; set; }
        public string TemplateName { get; set; }

        public string CultureName { get; set; }
    }
}
