using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FS.EcPay.HttpClient
{
    internal static class SHA256Encoder
    {
        public static string Encrypt(string originalString)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(originalString);
            byte[] hash = SHA256Managed.Create().ComputeHash(bytes);

            var builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("X2"));
            }

            return builder.ToString();
        }
    }

    internal static class MD5Encoder
    {
        private readonly static HashAlgorithm Crypto;

        static MD5Encoder()
        {
            MD5Encoder.Crypto = new MD5CryptoServiceProvider();
        }

        public static string Encrypt(string originalString)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(originalString);
            byte[] numArray = MD5Encoder.Crypto.ComputeHash(bytes);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < (int)numArray.Length; i++)
            {
                stringBuilder.Append(numArray[i].ToString("X").PadLeft(2, '0'));
            }
            return stringBuilder.ToString().ToUpper();
        }
    }

    internal abstract class EcPayParameterBase
    {
        public abstract string Query { get; }

        /// <summary>
        /// 檢查碼
        /// </summary>
        protected string CheckMacValue { get; set; }

        /// <summary>
        /// 設定 CheckMac 值
        /// </summary>
        protected void SetCheckMacValue(HttpClientOptions options)
        {
            var objList = this.GetObjectList(this)
                .Where(x => 
                    x.key != nameof(this.CheckMacValue) &&
                    x.key != nameof(this.Query)
                )
                .OrderBy(x => x.key)
                .Select(x => $"{x.key}={x.value}")
                .ToList();

            var parameters = String.Join("&", objList);

            this.CheckMacValue = this.BuildCheckMacValue(options.HashKey, options.HashIV, parameters);
        }

        /// <summary>
        /// 物件屬性與值轉為陣列
        /// </summary>
        protected List<(string key, string value)> GetObjectList(object obj)
        {
            Type objType = obj.GetType();
            List<PropertyInfo> props = objType.GetRuntimeProperties().ToList();

            var datas = new List<(string key, string value)>();
            foreach (var prop in props)
            {
                var value = prop.GetValue(this)?.ToString() ?? "";
                datas.Add(
                    (prop.Name, value)
                );
            }
            return datas;
        }

        /// <summary>
        /// 產生檢查碼。
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// 傳遞 parameters 參數,需要先經過英文字母 A-Z 排序
        private string BuildCheckMacValue(string hashKey, string hashIV, string parameters, int encryptType = 1)
        {
            string szCheckMacValue = String.Empty;
            // 產生檢查碼。
            szCheckMacValue = String.Format("HashKey={0}&{1}&HashIV={2}", hashKey, parameters, hashIV);
            szCheckMacValue = HttpUtility.UrlEncode(szCheckMacValue).ToLower();
            if (encryptType == 1)
            {
                szCheckMacValue = SHA256Encoder.Encrypt(szCheckMacValue);
            }
            else
            {
                szCheckMacValue = MD5Encoder.Encrypt(szCheckMacValue);
            }
            return szCheckMacValue;
        }

        /// <summary>
        /// Object 轉為 Form Post Html
        /// </summary>
        public string GetFormPostHtml(HttpClientOptions options)
        {
            var objList = this.GetObjectList(this)
                .Where(x => x.key != nameof(this.Query))
                .ToList();

            var formInputHtml = String.Join(
                    "",
                    objList.Select(x => $"<input type='hidden' name='{x.key}' value='{x.value}' />")
                );

            return
                "<!DOCTYPE html>" +
                    "<head>" +
                        "<script type='text/javascript'>" +
                            "window.onload = function() {" +
                                "document.forms['form'].submit();" +
                            "}" +
                        "</script>" +
                    "</head>" +
                    "<body>" +
                        $"<form name='form' action='{options.EcPayApiUrl}/{this.Query}/{options.EcPayApiUrlVersion}' method='post'>" +
                            formInputHtml +
                        "</form>" +
                    "</body>" +
                "</html>";
        }

        /// <summary>
        /// 使用 RestCline 送出 api
        /// </summary>
        public async Task<T> ExecuteRestClientAsync<T>(HttpClientOptions options)
        {
            var contentType = "application/x-www-form-urlencoded";
            var client = new RestClient($"{options.EcPayApiUrl}/{this.Query}/{options.EcPayApiUrlVersion}");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", contentType);

            var objList = this.GetObjectList(this)
                .Where(x => x.key != nameof(this.Query))
                .ToList();

            objList.ForEach(data =>
            {
                request.AddParameter(data.key, data.value, ParameterType.GetOrPost);
            });

            var response = await client.ExecuteAsync(request);
            var result = getResponse(options, response);
           

            return result;

            // Content 轉為 Dictionary
            // Content => &Key=Value&Key2=Value2
            T getResponse(HttpClientOptions options, RestResponse response)
            {
                var checkMacKey = nameof(this.CheckMacValue);
                var contents = response.Content
                    .Split("&")
                    .Select(x => x.Split("="))
                    .Where(x => x.Length == 2)
                    .ToList();

                var dic = new ConcurrentDictionary<string, string>();
                contents.ForEach(data =>
                {
                    dic.AddOrUpdate(data[0], data[1], (key, value) => data[1]);
                });

                var parameter = String.Join("&", 
                        dic
                            .Where(x => x.Key != checkMacKey)
                            .OrderBy(x => x.Key)
                            .Select(x => $"{x.Key}={x.Value}")
                    );
                var checkMacValue = this.BuildCheckMacValue(options.HashKey, options.HashIV, parameter);

                var validKey = dic.ContainsKey(checkMacKey) && dic[checkMacKey] == checkMacValue;
                if (!validKey) throw new Exception("驗證碼錯誤");

                var json = JsonConvert.SerializeObject(dic);
                var result = JsonConvert.DeserializeObject<T>(json);

                return result;
            }
        }
    }
}
