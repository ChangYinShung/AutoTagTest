//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by YinChang.
// 4.4.4
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Services;

namespace FS.Social.Codes
{
    public partial class CodesStore : DomainService, ICodesStore //auto-generated
    {
        public ICodeRepository Code => this.LazyServiceProvider.LazyGetRequiredService<ICodeRepository>();
    }
}
