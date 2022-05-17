using System;

namespace FS.Tspg.HttpClient.Params
{
    public static class ResponseParamValidateExtension
    {
        public static void DefaultValidate(this IResponseParameter param)
        {
            if (param.ReturnCode != "00") throw new Exception($"台新回傳錯誤代碼:{param.ReturnCode},錯誤訊息: {param.ReturnMessage}");
        }
    }
}
