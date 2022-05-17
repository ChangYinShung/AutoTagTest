using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace FS.CmsKit.ContentDefinitions.Web.Menus;

public class ContentDefinitionsMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(ContentDefinitionsMenus.Prefix, displayName: "ContentDefinitions", "~/ContentDefinitions", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
