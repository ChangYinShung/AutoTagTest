using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Abp.Emailing
{
    public class TemplateNoDefinModelTypeException : Volo.Abp.BusinessException
    {
        public TemplateNoDefinModelTypeException(string templateName)
            :base(EmailingErrorCodes.TemplateNoDefinModelType)
        {
            this.WithData(nameof(templateName),templateName);
        }
    }
}
