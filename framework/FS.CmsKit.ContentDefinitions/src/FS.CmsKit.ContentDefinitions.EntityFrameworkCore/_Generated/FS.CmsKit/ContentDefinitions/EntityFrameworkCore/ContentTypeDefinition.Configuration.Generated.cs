//------------------------------------------------------------------------------
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

namespace FS.CmsKit.ContentDefinitions.EntityFrameworkCore
{
    public partial class ContentTypeDefinitionConfiguration : IEntityTypeConfiguration<ContentTypeDefinition> //auto-generated
    {
        private string tablePrefix;
        private string schema;
        public ContentTypeDefinitionConfiguration(string tablePrefix, string schema)
        {
            this.tablePrefix = tablePrefix;
            this.schema = schema;
        }
        public void Configure(EntityTypeBuilder<ContentTypeDefinition> builder)
        {
            builder.ToTable(tablePrefix + @"ContentTypeDefinitions", schema);
            builder.Property<Guid>(@"Id").HasColumnName(@"Id").HasColumnType(@"uniqueidentifier").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.TenantId).HasColumnName(@"TenantId").ValueGeneratedNever();
            builder.Property(x => x.ContentDefinitionId).HasColumnName(@"ContentDefinitionId").HasColumnType(@"uniqueidentifier").ValueGeneratedNever();
            builder.Property(x => x.EntityType).HasColumnName(@"EntityType").HasColumnType(@"nvarchar").IsRequired().ValueGeneratedNever().HasMaxLength(64);
            builder.Property(x => x.EntityId).HasColumnName(@"EntityId").HasColumnType(@"nvarchar").IsRequired().ValueGeneratedNever().HasMaxLength(64);
            builder.HasKey(@"Id");

            builder.ConfigureAuditedAggregateRoot();
            builder.HasIndex(x => x.CreationTime);

            CustomizeConfiguration(builder);
        }

        partial void CustomizeConfiguration(EntityTypeBuilder<ContentTypeDefinition> builder);
    }
    public static partial class ContentTypeDefinitionQueryableExtensions //auto-generated
    {
        public static IQueryable<ContentTypeDefinition> IncludeDetails(this IQueryable<ContentTypeDefinition> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            IQueryable<ContentTypeDefinition> result = queryable
                .Include(x => x.ContentTypePartDefinitions);

            CustomizeIncludeDetails(ref result);

            return result;
        }

        static partial void CustomizeIncludeDetails(ref IQueryable<ContentTypeDefinition> query);
    }
}
