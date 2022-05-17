using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace FS.Abp.Emailing.Web.Menus;

public class EmailingMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(EmailingMenus.Prefix, displayName: "Emailing", "~/Emailing", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
