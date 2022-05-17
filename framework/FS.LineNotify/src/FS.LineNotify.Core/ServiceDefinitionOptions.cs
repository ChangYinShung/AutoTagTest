using System;
using System.Collections.Generic;
using System.Text;

namespace FS.LineNotify
{
    public class ServiceDefinitionOptions
    {
        public string AppName { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string NotifyBotUrl { get; set; }
        public string NotifyApiUrl { get; set; }
        public string RedirectUrl { get; set; }
        public bool EnableLogger { get; set; }
        //Default Value
        public ServiceDefinitionOptions()
        {
            //AppName = "LineNotifyApp";
            ClientId = "7JRPbztwQwQh6BFKpZUVho";
            ClientSecret = "z4fLmI2cIafKyuFvFkvxGL15hH3JmW3OoUo5JfCOFxe";
            NotifyBotUrl="https://notify-bot.line.me/oauth";
            NotifyApiUrl="https://notify-api.line.me/api";
            RedirectUrl = "https://msg.stage.furthersoftware.com.tw/webhook/line-notify/call-back";
            EnableLogger=false;
        }
    }
}
