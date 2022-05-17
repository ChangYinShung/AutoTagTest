using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Events.Distributed;

namespace FS.CmsKit.ContentEntities.Events
{
    public class ContentEntityEto 
    {
        public Guid Id { get; set; }

        public Guid TenantId { get; set; }

        public string EntityType { get; set; }

        public string EntityId { get; set; }

    }
}
