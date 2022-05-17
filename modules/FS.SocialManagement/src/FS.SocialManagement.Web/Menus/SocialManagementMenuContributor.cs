using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace FS.SocialManagement.Web.Menus;

public class SocialManagementMenuContributor : IMenuContributor
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
        //context.Menu.AddItem(new ApplicationMenuItem(SocialManagementMenus.Prefix, displayName: "SocialManagement", "~/SocialManagement", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
