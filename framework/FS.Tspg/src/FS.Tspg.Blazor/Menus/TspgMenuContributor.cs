using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace FS.Tspg.Blazor.Menus;

public class TspgMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(TspgMenus.Prefix, displayName: "Tspg", "/Tspg", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
