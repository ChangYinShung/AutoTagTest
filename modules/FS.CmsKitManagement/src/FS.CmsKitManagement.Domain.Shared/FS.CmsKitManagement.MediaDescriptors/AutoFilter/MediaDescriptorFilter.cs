using System;
using System.Collections.Generic;
using System.Text;

namespace FS.CmsKitManagement.MediaDescriptors.AutoFilter
{
    public class MediaDescriptorFilter : AutoFilterer.Types.FilterBase
    {
        [AutoFilterer.Attributes.CompareTo("Name")]
        [AutoFilterer.Attributes.StringFilterOptions(AutoFilterer.Enums.StringFilterOption.StartsWith)]
        public string Prefix { get; set; }

        [AutoFilterer.Attributes.CompareTo("EntityType")]
        [AutoFilterer.Attributes.StringFilterOptions(AutoFilterer.Enums.StringFilterOption.Equals)]
        public string EntityType { get; set; }
    }
}
