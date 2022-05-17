using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace FS.Entity.Web.Menus;

public class EntityMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(EntityMenus.Prefix, displayName: "Entity", "~/Entity", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
