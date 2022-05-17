using System;
using System.Collections.Generic;
using System.Text;

namespace FS.CmsKit.EntityMedias
{
    public class EntityMediaItemAutoFilter : AutoFilterer.Types.FilterBase
    {
        [AutoFilterer.Attributes.StringFilterOptions(AutoFilterer.Enums.StringFilterOption.Equals)]
        public string EntityId { get; set; }

        [AutoFilterer.Attributes.StringFilterOptions(AutoFilterer.Enums.StringFilterOption.Equals)]
        public string EntityType { get; set; }

        [AutoFilterer.Attributes.StringFilterOptions(AutoFilterer.Enums.StringFilterOption.Equals)]
        public string EntityMediaGroupName { get; set; }

        public EntityMediaItemAutoFilter(
            string entityId,
            string entityType,
            string groupName)
        {
            this.EntityId = entityId;
            this.EntityType = entityType;
            this.EntityMediaGroupName = groupName;
        }
    }
}
