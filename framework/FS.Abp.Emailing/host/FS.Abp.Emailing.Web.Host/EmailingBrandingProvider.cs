using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FS.Abp.Emailing;

[Dependency(ReplaceServices = true)]
public class EmailingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Emailing";
}
