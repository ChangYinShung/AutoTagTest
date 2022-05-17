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

namespace FS.CmsKitManagement.ContentRecords.EntityFrameworkCore
{
    public partial class ContentPartRecordConfiguration : IEntityTypeConfiguration<ContentPartRecord> //auto-generated
    {
        private string tablePrefix;
        private string schema;
        public ContentPartRecordConfiguration(string tablePrefix, string schema)
        {
            this.tablePrefix = tablePrefix;
            this.schema = schema;
        }
        public void Configure(EntityTypeBuilder<ContentPartRecord> builder)
        {
            builder.ToTable(tablePrefix + @"ContentPartRecords", schema);
            builder.Property<Guid>(@"Id").HasColumnName(@"Id").HasColumnType(@"uniqueidentifier").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.ContentPartDefinitionId).HasColumnName(@"ContentPartDefinitionId").HasColumnType(@"uniqueidentifier").ValueGeneratedNever();
            builder.Property(x => x.TenantId).HasColumnName(@"TenantId").ValueGeneratedNever();
            builder.Property(x => x.ContentTypeRecordId).HasColumnName(@"ContentTypeRecordId").HasColumnType(@"uniqueidentifier").ValueGeneratedNever();
            builder.HasKey(@"Id");

            builder.ConfigureAudited();

            CustomizeConfiguration(builder);
        }

        partial void CustomizeConfiguration(EntityTypeBuilder<ContentPartRecord> builder);
    }
    public static partial class ContentPartRecordQueryableExtensions //auto-generated
    {
        public static IQueryable<ContentPartRecord> IncludeDetails(this IQueryable<ContentPartRecord> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            IQueryable<ContentPartRecord> result = queryable
                .Include(x => x.ContentPartFieldRecords);

            CustomizeIncludeDetails(ref result);

            return result;
        }

        static partial void CustomizeIncludeDetails(ref IQueryable<ContentPartRecord> query);
    }
}