
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace FS.Abp.Emailing
{
    public partial interface IEmailingStore
    {
        Task<object> GetAsync(string no, string key);

        Task SetAsync(string no, string key, object item);
    }
}
