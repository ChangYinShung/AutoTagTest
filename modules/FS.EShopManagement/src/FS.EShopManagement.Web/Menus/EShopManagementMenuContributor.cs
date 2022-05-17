using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace FS.EShopManagement.Web.Menus;

public class EShopManagementMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(EShopManagementMenus.Prefix, displayName: "EShopManagement", "~/EShopManagement", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
