﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by YinChang.
// 5.1.3
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Services;

namespace FS.CmsKit.EntityMedias
{
    public partial class EntityMediasStore : DomainService, IEntityMediasStore //auto-generated
    {
        public IEntityMediaRepository EntityMedia => this.LazyServiceProvider.LazyGetRequiredService<IEntityMediaRepository>();
        public IEntityMediaGroupRepository EntityMediaGroup => this.LazyServiceProvider.LazyGetRequiredService<IEntityMediaGroupRepository>();
        public IEntityMediaItemRepository EntityMediaItem => this.LazyServiceProvider.LazyGetRequiredService<IEntityMediaItemRepository>();
    }
}
