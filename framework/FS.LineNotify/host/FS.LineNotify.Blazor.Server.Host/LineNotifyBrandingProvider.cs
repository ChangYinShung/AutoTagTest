using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FS.LineNotify.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class LineNotifyBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "LineNotify";
}
