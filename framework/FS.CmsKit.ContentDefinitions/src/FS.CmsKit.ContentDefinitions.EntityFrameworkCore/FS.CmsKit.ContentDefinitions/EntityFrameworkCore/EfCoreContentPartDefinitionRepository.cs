using System;
using System.Linq;
using System.Collections.Generic;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using System.Threading.Tasks;
using FS.CmsKit.ContentDefinitions.EntityFrameworkCore;
using System.Threading;

namespace FS.CmsKit.ContentDefinitions.EntityFrameworkCore
{
    public partial class EfCoreContentPartDefinitionRepository
    {
        public async Task PatchAsync(ContentPartDefinition entity, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            var state = (await this.GetDbContextAsync()).Entry(entity).State;

            if (state==Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                await this.InsertAsync(entity, autoSave, cancellationToken);
            }
        }

    }
}
