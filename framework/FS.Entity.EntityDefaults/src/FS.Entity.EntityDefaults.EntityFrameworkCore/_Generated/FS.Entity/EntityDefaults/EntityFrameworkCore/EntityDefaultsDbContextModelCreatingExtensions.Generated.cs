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
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace FS.Entity.EntityDefaults.EntityFrameworkCore
{
    public static partial class EntityDefaultsDbContextModelCreatingExtensions
    {
        public static void ConfigureEntityDefaults(
            this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            CustomizeMapping(ref builder);

            builder.ApplyConfiguration<FS.Entity.EntityDefaults.EntityDefault>(new FS.Entity.EntityDefaults.EntityFrameworkCore.EntityDefaultConfiguration(EntityDbProperties.DbTablePrefix,EntityDbProperties.DbSchema));
            builder.ApplyConfiguration<FS.Entity.EntityDefaults.EntityDefaultItem>(new FS.Entity.EntityDefaults.EntityFrameworkCore.EntityDefaultItemConfiguration(EntityDbProperties.DbTablePrefix,EntityDbProperties.DbSchema));
        }
        static partial void CustomizeMapping(ref ModelBuilder modelBuilder);
    }
}