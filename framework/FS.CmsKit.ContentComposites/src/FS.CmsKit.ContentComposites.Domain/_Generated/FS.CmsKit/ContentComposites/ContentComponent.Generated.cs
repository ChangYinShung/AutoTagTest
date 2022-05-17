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

namespace FS.CmsKit.ContentComposites
{
    public partial class ContentComponent : 
        Volo.Abp.Domain.Entities.Auditing.AuditedAggregateRoot<Guid>,
        Volo.Abp.MultiTenancy.IMultiTenant,
        EasyAbp.Abp.Trees.ITree<ContentComponent>
    {

        public ContentComponent()
        {
            this.Children = new List<ContentComponent>();
            OnCreated();
        }

        public ContentComponent(System.Guid id) : this()
        {
            this.Id = id;
        }

        public virtual System.Guid? TenantId
        {
            get;
            set;
        }

        public virtual System.Guid? ContentEntityId
        {
            get;
            set;
        }

        public virtual string Code
        {
            get;
            set;
        }

        public virtual System.Guid? ParentId
        {
            get;
            set;
        }

        public virtual int Level
        {
            get;
            set;
        }

        public virtual string DisplayName
        {
            get;
            set;
        }

        public virtual string ContentComponentDiscriminator
        {
            get;
            set;
        }

        public virtual ICollection<ContentComponent> Children
        {
            get;
            set;
        }

        public virtual ContentComponent Parent
        {
            get;
            set;
        }


        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
