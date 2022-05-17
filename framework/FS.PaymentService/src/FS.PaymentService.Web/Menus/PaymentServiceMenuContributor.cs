using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace FS.PaymentService.Web.Menus;

public class PaymentServiceMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(PaymentServiceMenus.Prefix, displayName: "PaymentService", "~/PaymentService", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
