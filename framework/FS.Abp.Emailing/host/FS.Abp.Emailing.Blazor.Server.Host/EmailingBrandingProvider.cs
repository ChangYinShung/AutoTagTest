using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FS.Abp.Emailing.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class EmailingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Emailing";
}
