﻿//------------------------------------------------------------------------------
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

namespace FS.Entity.MultiLinguals
{
    public partial class MultiLingualTranslation : 
        Volo.Abp.Domain.Entities.Auditing.AuditedAggregateRoot<Guid>,
        Volo.Abp.MultiTenancy.IMultiTenant
    {

        public MultiLingualTranslation()
        {
            OnCreated();
        }

        public MultiLingualTranslation(System.Guid id) : this()
        {
            this.Id = id;
        }

        public virtual string Culture
        {
            get;
            set;
        }
        public virtual List<Volo.Abp.NameValue> Properties 
        {

            get
            {
                return this.GetExtraProperty<List<Volo.Abp.NameValue>>(nameof(Properties));
            }
            set
            {
                this.SetProperty(nameof(Properties), value);
            }
        } 

        public virtual System.Guid MultiLingualId
        {
            get;
            set;
        }

        public virtual System.Guid? TenantId
        {
            get;
            set;
        }

        public virtual MultiLingual MultiLingual
        {
            get;
            set;
        }


        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
