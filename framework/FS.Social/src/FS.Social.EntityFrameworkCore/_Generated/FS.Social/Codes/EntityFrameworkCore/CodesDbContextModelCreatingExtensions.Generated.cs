﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// 4.4.4
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace FS.Social.Codes.EntityFrameworkCore
{
    public static partial class CodesDbContextModelCreatingExtensions
    {
        public static void ConfigureCodes(
            this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            CustomizeMapping(ref builder);

            builder.ApplyConfiguration<FS.Social.Codes.Code>(new FS.Social.Codes.EntityFrameworkCore.CodeConfiguration(SocialDbProperties.DbTablePrefix,SocialDbProperties.DbSchema));
        }
        static partial void CustomizeMapping(ref ModelBuilder modelBuilder);
    }
}
