﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// 4.4.4
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using System.Threading.Tasks;
using FS.Social.Codes.EntityFrameworkCore;

namespace FS.Social.Codes.EntityFrameworkCore
{
    public partial class EfCoreCodeRepository : 
        EfCoreRepository<ICodesDbContext,FS.Social.Codes.Code,Guid>,
        ICodeRepository
    {
        public EfCoreCodeRepository(IDbContextProvider<ICodesDbContext> dbContextProvider)
            : base(dbContextProvider) { }
    }
}