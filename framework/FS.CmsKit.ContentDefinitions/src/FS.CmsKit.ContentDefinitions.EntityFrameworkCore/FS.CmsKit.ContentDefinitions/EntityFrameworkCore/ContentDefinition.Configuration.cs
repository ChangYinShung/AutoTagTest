using System;
using System.Data;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace FS.CmsKit.ContentDefinitions.EntityFrameworkCore
{

    public static partial class ContentDefinitionQueryableExtensions //auto-generated
    {
        static partial void CustomizeIncludeDetails(ref IQueryable<ContentDefinition> query)
        {
            query=query.Include(x => x.ContentTypeDefinitions).ThenInclude(y => y.ContentTypePartDefinitions)
                .Include(x => x.ContentPartDefinitions).ThenInclude(y => y.ContentPartFieldDefinitions);
        }
    }
}
