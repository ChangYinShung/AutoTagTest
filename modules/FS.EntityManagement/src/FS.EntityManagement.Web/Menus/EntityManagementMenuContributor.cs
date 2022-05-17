using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace FS.EntityManagement.Web.Menus;

public class EntityManagementMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(EntityManagementMenus.Prefix, displayName: "EntityManagement", "~/EntityManagement", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
