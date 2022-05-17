using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace FS.UnifyTheme.Web.Menus
{
    public class UnifyThemeMenuContributor : IMenuContributor
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
            context.Menu.AddItem(new ApplicationMenuItem(UnifyThemeMenus.Prefix, displayName: "UnifyTheme", "~/UnifyTheme", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
}