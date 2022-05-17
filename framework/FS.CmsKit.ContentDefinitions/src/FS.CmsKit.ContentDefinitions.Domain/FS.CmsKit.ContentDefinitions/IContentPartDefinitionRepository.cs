using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FS.CmsKit.ContentDefinitions
{
    public partial interface IContentPartDefinitionRepository
    {
        Task PatchAsync(ContentPartDefinition entity, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken));
    }
}
