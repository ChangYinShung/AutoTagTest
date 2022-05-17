using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace FS.Social.Blazor.Menus;

public class SocialMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(SocialMenus.Prefix, displayName: "Social", "/Social", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
