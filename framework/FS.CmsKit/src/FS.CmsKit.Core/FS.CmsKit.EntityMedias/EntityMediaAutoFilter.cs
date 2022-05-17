using System;
using System.Collections.Generic;
using System.Text;

namespace FS.CmsKit.EntityMedias
{
    public class EntityMediaAutoFilter : AutoFilterer.Types.FilterBase
    {
        public string EntityType { get; set; }

        public EntityMediaAutoFilter(string entityType)
        {
            EntityType = entityType;
        }
    }
}
