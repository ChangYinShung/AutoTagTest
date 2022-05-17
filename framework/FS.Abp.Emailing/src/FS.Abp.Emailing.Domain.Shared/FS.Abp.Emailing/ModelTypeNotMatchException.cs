using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Abp.Emailing
{
    public class ModelTypeNotMatchException : Volo.Abp.BusinessException
    {
        public ModelTypeNotMatchException(string templateName,string templateModelType,string modelType)
            :base(EmailingErrorCodes.ModelTypeNotMatch)
        {
            this.WithData(nameof(templateName), templateName);
            this.WithData(nameof(templateModelType), templateModelType);
            this.WithData(nameof(modelType), modelType);
        }
    }
}
