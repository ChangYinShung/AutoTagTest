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

namespace FS.CmsKit.EntityMedias.EntityFrameworkCore
{
    public partial class EntityMediasDbContext : AbpDbContext<EntityMediasDbContext>, IEntityMediasDbContext
    {
        public DbSet<FS.CmsKit.EntityMedias.EntityMedia> EntityMedia { get; set; }

        public DbSet<FS.CmsKit.EntityMedias.EntityMediaGroup> EntityMediaGroups { get; set; }

        public DbSet<FS.CmsKit.EntityMedias.EntityMediaItem> EntityMediaItems { get; set; }

        public EntityMediasDbContext(DbContextOptions<EntityMediasDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureEntityMedias();

            CustomizeMapping(ref builder);

            base.OnModelCreating(builder);
        }

        partial void CustomizeMapping(ref ModelBuilder modelBuilder);

        partial void OnCreated();
    }
}
