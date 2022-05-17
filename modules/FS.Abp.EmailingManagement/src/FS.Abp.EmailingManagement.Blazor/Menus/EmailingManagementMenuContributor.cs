using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace FS.Abp.EmailingManagement.Blazor.Menus;

public class EmailingManagementMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(EmailingManagementMenus.Prefix, displayName: "EmailingManagement", "/EmailingManagement", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
