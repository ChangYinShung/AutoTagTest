﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// 5.1.3
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Reflection;
using System.Data.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Volo.Abp.DependencyInjection;

namespace FS.EntityManagement.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(FS.Entity.EntityDefaults.EntityFrameworkCore.IEntityDefaultsDbContext))]
    [ReplaceDbContext(typeof(FS.Entity.MultiLinguals.EntityFrameworkCore.IMultiLingualsDbContext))]
    [ConnectionStringName(EntityManagementDbProperties.ConnectionStringName)]
    public partial class EntityManagementDbContext : AbpDbContext<EntityManagementDbContext>, IEntityManagementDbContext
    {

        public virtual DbSet<FS.Entity.EntityDefaults.EntityDefault> EntityDefaults
        {
            get;
            set;
        }

        public virtual DbSet<FS.Entity.EntityDefaults.EntityDefaultItem> EntityDefaultItems
        {
            get;
            set;
        }

        public virtual DbSet<FS.Entity.MultiLinguals.MultiLingualTranslation> MultiLingualTranslations
        {
            get;
            set;
        }

        public virtual DbSet<FS.Entity.MultiLinguals.MultiLingual> MultiLinguals
        {
            get;
            set;
        }
        public EntityManagementDbContext(DbContextOptions<EntityManagementDbContext> options) :
            base(options)
        {
            OnCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureEntityManagement();

            CustomizeMapping(ref builder);

            base.OnModelCreating(builder);
        }

        partial void CustomizeMapping(ref ModelBuilder modelBuilder);

        partial void OnCreated();
    }
}