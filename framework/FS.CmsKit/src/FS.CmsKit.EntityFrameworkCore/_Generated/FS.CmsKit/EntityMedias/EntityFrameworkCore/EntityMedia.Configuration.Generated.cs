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

namespace FS.CmsKit.EntityMedias.EntityFrameworkCore
{
    public partial class EntityMediaConfiguration : IEntityTypeConfiguration<EntityMedia> //auto-generated
    {
        private string tablePrefix;
        private string schema;
        public EntityMediaConfiguration(string tablePrefix, string schema)
        {
            this.tablePrefix = tablePrefix;
            this.schema = schema;
        }
        public void Configure(EntityTypeBuilder<EntityMedia> builder)
        {
            builder.ToTable(tablePrefix + @"EntityMedia", schema);
            builder.Property<Guid>(@"Id").HasColumnName(@"Id").HasColumnType(@"uniqueidentifier").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.EntityType).HasColumnName(@"EntityType").HasColumnType(@"nvarchar").IsRequired().ValueGeneratedNever().HasMaxLength(64);
            builder.Property(x => x.TenantId).HasColumnName(@"TenantId").ValueGeneratedNever();
            builder.HasKey(@"Id");

            builder.ConfigureAuditedAggregateRoot();
            builder.HasIndex(x => x.CreationTime);

            CustomizeConfiguration(builder);
        }

        partial void CustomizeConfiguration(EntityTypeBuilder<EntityMedia> builder);
    }
    public static partial class EntityMediaQueryableExtensions //auto-generated
    {
        public static IQueryable<EntityMedia> IncludeDetails(this IQueryable<EntityMedia> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            IQueryable<EntityMedia> result = queryable
                .Include(x => x.EntityMediaGroups);

            CustomizeIncludeDetails(ref result);

            return result;
        }

        static partial void CustomizeIncludeDetails(ref IQueryable<EntityMedia> query);
    }
}
