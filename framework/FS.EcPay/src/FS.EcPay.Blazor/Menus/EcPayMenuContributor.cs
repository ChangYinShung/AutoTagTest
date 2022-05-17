using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace FS.EcPay.Blazor.Menus;

public class EcPayMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(EcPayMenus.Prefix, displayName: "EcPay", "/EcPay", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
