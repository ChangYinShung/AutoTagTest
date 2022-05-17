using System;

namespace FS.Abp.Emailing;

[Serializable]
public class BackgroundEmailSendingJobArgs
{
    public string MailMessageTemplateNo { get; set; }
    public string CacheKey { get; set; }
    public string To { get; set; }
}
