using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace FS.CmsKit.ContentComposites.Web.Menus;

public class ContentCompositesMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(ContentCompositesMenus.Prefix, displayName: "ContentComposites", "~/ContentComposites", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
