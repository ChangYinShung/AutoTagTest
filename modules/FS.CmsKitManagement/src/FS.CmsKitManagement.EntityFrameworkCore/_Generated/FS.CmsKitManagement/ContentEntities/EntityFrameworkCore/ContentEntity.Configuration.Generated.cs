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
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace FS.CmsKit.ContentEntities.EntityFrameworkCore
{
    public partial class ContentEntityConfiguration : IEntityTypeConfiguration<ContentEntity> //auto-generated
    {
        private string tablePrefix;
        private string schema;
        public ContentEntityConfiguration(string tablePrefix, string schema)
        {
            this.tablePrefix = tablePrefix;
            this.schema = schema;
        }
        public void Configure(EntityTypeBuilder<ContentEntity> builder)
        {
            builder.ToTable(tablePrefix + @"ContentEntities", schema);
            builder.Property<Guid>(@"Id").HasColumnName(@"Id").HasColumnType(@"uniqueidentifier").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.EntityType).HasColumnName(@"EntityType").HasColumnType(@"nvarchar").IsRequired().ValueGeneratedNever().HasMaxLength(64);
            builder.Property(x => x.EntityId).HasColumnName(@"EntityId").HasColumnType(@"nvarchar").IsRequired().ValueGeneratedNever().HasMaxLength(64);
            builder.Property(x => x.TenantId).HasColumnName(@"TenantId").ValueGeneratedNever();
            builder.HasKey(@"Id");

            builder.ConfigureAuditedAggregateRoot();
            builder.HasIndex(x => x.CreationTime);

            CustomizeConfiguration(builder);
        }

        partial void CustomizeConfiguration(EntityTypeBuilder<ContentEntity> builder);
    }
    public static partial class ContentEntityQueryableExtensions //auto-generated
    {
    }
}
