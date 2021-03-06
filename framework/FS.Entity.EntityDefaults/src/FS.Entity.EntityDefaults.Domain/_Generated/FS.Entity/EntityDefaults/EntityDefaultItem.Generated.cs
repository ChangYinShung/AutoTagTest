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

namespace FS.Entity.EntityDefaults
{
    public partial class EntityDefaultItem : 
        Volo.Abp.Domain.Entities.Auditing.AuditedAggregateRoot<Guid>
    {

        public EntityDefaultItem()
        {
            OnCreated();
        }
        public virtual List<FS.Entity.EntityDefaults.EntityProperty> EntityProperties 
        {

            get
            {
                return this.GetExtraProperty<List<FS.Entity.EntityDefaults.EntityProperty>>(nameof(EntityProperties));
            }
            set
            {
                this.SetProperty(nameof(EntityProperties), value);
            }
        } 

        public virtual System.Guid EntityDefaultId
        {
            get;
            set;
        }

        public virtual EntityDefault EntityDefault
        {
            get;
            set;
        }


        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
