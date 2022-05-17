using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FS.Social.LineNotify;

[Dependency(ReplaceServices = true)]
public class LineNotifyBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "LineNotify";
}
