using FS.LineNotify;
using FS.LineNotify.HttpClient;
using FS.Social.Codes;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace FS.Social.LineNotify
{
    public class LineNotifyManager : Volo.Abp.DependencyInjection.ITransientDependency
    {
        private readonly ServiceDefinitionOptions options;
        private readonly ICodesStore codesStore;
        private readonly ILineNotifyHttpClient lineNotifyHttpClient;

        public LineNotifyManager(
            IOptions<FS.LineNotify.ServiceDefinitionOptions> options,
            FS.Social.Codes.ICodesStore codesStore,
            FS.LineNotify.HttpClient.ILineNotifyHttpClient lineNotifyHttpClient
            )
        {
            this.options=options.Value;
            this.codesStore=codesStore;
            this.lineNotifyHttpClient=lineNotifyHttpClient;
        }

        public async Task<string> AuthorizeUrlAsync(string providerName = null, string providerKey = null)
        {
            string state = $"name={options.AppName}&provider-name={providerName}&provider-key={providerKey}";

            return await lineNotifyHttpClient.AuthorizeUrlAsync(state);
        }

        public async Task NotifyAsync(string message, string providerName = null, string providerKey = null)
        {
            //var name = options.AppName;

            //FS.Social.Codes.Filters.CodeFilter filter = new Codes.Filters.CodeFilter()
            //{
            //    Name=options.AppName,
            //    ProviderName=providerName,
            //    ProviderKey=providerKey
            //};

            var query = await codesStore.Code.GetQueryableAsync();


            var code = query
                .Where(x => x.Name==options.AppName&&x.ProviderName==providerName&&x.ProviderKey==providerKey)
                .Single();

            await lineNotifyHttpClient.NotifyAsync(code.Value, message);
        }
    }
}
