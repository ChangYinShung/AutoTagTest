using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FS.Social.Codes
{
    public partial interface ICodeRepository
    {
        Task InsertOrUpdateAsync(
            string name,
            string providerName, string providerKey,
            string value);
    }
}
