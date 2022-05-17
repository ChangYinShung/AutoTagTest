using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FS.CmsKit.ContentDefinitions
{
    public partial interface IContentTypeDefinitionRepository
    {
        Task PatchAsync(ContentTypeDefinition entity, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken));
    }
}
