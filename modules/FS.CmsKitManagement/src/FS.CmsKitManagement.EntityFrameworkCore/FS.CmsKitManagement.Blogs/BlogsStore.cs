using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Services;
using Volo.Abp.ObjectMapping;
using Volo.CmsKit.Blogs;

namespace FS.CmsKitManagement.Blogs
{
    public partial class BlogsStore : DomainService, IBlogsStore
    {
        public IBlogPostRepository BlogPost => this.LazyServiceProvider.LazyGetRequiredService<IBlogPostRepository>();

    }
}
