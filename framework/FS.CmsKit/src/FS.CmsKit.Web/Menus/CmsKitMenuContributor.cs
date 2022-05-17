using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace FS.CmsKit.Web.Menus;

public class CmsKitMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(CmsKitMenus.Prefix, displayName: "CmsKit", "~/CmsKit", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
