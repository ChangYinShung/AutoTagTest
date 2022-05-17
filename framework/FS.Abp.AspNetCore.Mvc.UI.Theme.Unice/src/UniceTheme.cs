using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace FS.Abp.AspNetCore.Mvc.UI.Theme.Unice;

[ThemeName(Name)]
public class UniceTheme : ITheme, ITransientDependency
{
    public const string Name = "Unice";

    public virtual string GetLayout(string name, bool fallbackToDefault = true)
    {
        switch (name)
        {
            case StandardLayouts.Application:
                return "~/Themes/Unice/Layouts/Application.cshtml";
            case StandardLayouts.Account:
                return "~/Themes/Unice/Layouts/Account.cshtml";
            case StandardLayouts.Empty:
                return "~/Themes/Unice/Layouts/Empty.cshtml";
            case StandardLayouts.Public:
                return "~/Themes/Unice/Layouts/Public.cshtml";
            default:
                return fallbackToDefault ? "~/Themes/Unice/Layouts/Unice.cshtml" : null;
        }
    }
}
