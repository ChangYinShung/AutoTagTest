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

namespace FS.CmsKit.ContentDefinitions
{
    public partial class ContentTypePartDefinition : 
        Volo.Abp.Domain.Entities.Auditing.AuditedEntity<Guid>,
        Volo.Abp.MultiTenancy.IMultiTenant
    {

        public ContentTypePartDefinition()
        {
            OnCreated();
        }

        public ContentTypePartDefinition(System.Guid id) : this()
        {
            this.Id = id;
        }

        public virtual System.Guid? TenantId
        {
            get;
            set;
        }

        public virtual System.Guid ContentTypeDefinitionId
        {
            get;
            set;
        }

        public virtual System.Guid ContentPartDefinitionId
        {
            get;
            set;
        }


        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}