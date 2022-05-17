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

namespace FS.Entity.MultiLinguals.EntityFrameworkCore
{
    public partial class MultiLingualsDbContext : AbpDbContext<MultiLingualsDbContext>, IMultiLingualsDbContext
    {
        public DbSet<FS.Entity.MultiLinguals.MultiLingualTranslation> MultiLingualTranslations { get; set; }

        public DbSet<FS.Entity.MultiLinguals.MultiLingual> MultiLinguals { get; set; }

        public MultiLingualsDbContext(DbContextOptions<MultiLingualsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureMultiLinguals();

            CustomizeMapping(ref builder);

            base.OnModelCreating(builder);
        }

        partial void CustomizeMapping(ref ModelBuilder modelBuilder);

        partial void OnCreated();
    }
}
