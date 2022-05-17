using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace FS.CmsKit.ContentDefinitions
{
    public class DuplicateContentDefinitionVersionException : BusinessException
    {
        public DuplicateContentDefinitionVersionException(string version)
            : base(ContentDefinitionsErrorCodes.DuplicateContentDefinitionVersion)
        {
            WithData(nameof(version), version);
        }
    }

    public class PublishedContentCantModifyException : BusinessException
    {
        public PublishedContentCantModifyException(string version)
            : base(ContentDefinitionsErrorCodes.PublishedContentCantModify)
        {
            WithData(nameof(version), version);
        }
    }

    public class TemplateDefinitionNotExistException : BusinessException
    {
        public TemplateDefinitionNotExistException(string templateDefinitionName)
            : base(ContentDefinitionsErrorCodes.TemplateDefinitionNotExist)
        {
            WithData(nameof(templateDefinitionName), templateDefinitionName);
        }
    }
}
