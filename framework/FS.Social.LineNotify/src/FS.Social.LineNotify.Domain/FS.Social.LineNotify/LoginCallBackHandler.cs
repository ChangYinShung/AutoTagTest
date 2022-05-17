using FS.LineNotify.Etos;
using FS.LineNotify.HttpClient;
using FS.Social.Codes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FS.Social.LineNotify
{
    public class LoginCallBackHandler :
        Volo.Abp.EventBus.Distributed.IDistributedEventHandler<FS.LineNotify.Etos.LoginCallBackEto>,
        Volo.Abp.DependencyInjection.ITransientDependency
    {
        private readonly ILineNotifyHttpClient lineNotifyHttpClient;
        private readonly ICodesStore codesStore;

        public LoginCallBackHandler(
            ILineNotifyHttpClient lineNotifyHttpClient,
            FS.Social.Codes.ICodesStore codesStore
            )
        {
            this.lineNotifyHttpClient=lineNotifyHttpClient;
            this.codesStore=codesStore;
        }

        [Volo.Abp.Uow.UnitOfWork]
        public async Task HandleEventAsync(LoginCallBackEto eventData)
        {
            var parameters = HttpUtility.ParseQueryString(eventData.State);

            var name = parameters["name"];
            var providerName = parameters["provider-name"];
            var providerKey = parameters["provider-key"];

            var token = await lineNotifyHttpClient.TokenAsync(eventData.Code);

            await codesStore.Code.InsertOrUpdateAsync(
                name,
                string.IsNullOrEmpty(providerName) ?null: providerName,
                string.IsNullOrEmpty(providerKey) ? null : providerKey,
                token.access_token);

        }
    }
}
