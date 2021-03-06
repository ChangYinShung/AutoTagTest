//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by YinChang.
// 5.1.3
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Data;

namespace FS.CmsKit.EntityMedias
{
    public partial class EntityMedia : 
        Volo.Abp.Domain.Entities.Auditing.AuditedAggregateRoot<Guid>,
        Volo.Abp.MultiTenancy.IMultiTenant
    {

        public EntityMedia()
        {
            this.EntityMediaGroups = new List<EntityMediaGroup>();
            OnCreated();
        }

        public EntityMedia(System.Guid id) : this()
        {
            this.Id = id;
        }

        public virtual string EntityType
        {
            get;
            set;
        }

        public virtual System.Guid? TenantId
        {
            get;
            set;
        }

        public virtual IList<EntityMediaGroup> EntityMediaGroups
        {
            get;
            set;
        }


        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
