using System.Threading.Tasks;
using School.System.Localization;
using School.System.Permissions;
using School.System.MultiTenancy;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;

namespace School.System.Web.Menus;

public class SystemMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<SystemResource>();

        //Home
        context.Menu.AddItem(
            new ApplicationMenuItem(
                SystemMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fa fa-home",
                order: 1
            )
        );
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "SchoolSystems",
                l["Menu:SchoolSystems"],
                icon: "fa fa-book"
            ).AddItem(
                new ApplicationMenuItem(
                    "SchoolSystems.Roles",
                    l["Menu:Roles"],
                    icon: "fa fa-users",
                    url: "/Roles")
                    .AddItem( 
                        new ApplicationMenuItem(
                            "SchoolSystems.Roles.Students", 
                            l["Menu:Students"], 
                            icon: "fa fa-user-graduate", 
                            url:"/Roles/Students"))
                    .AddItem( 
                        new ApplicationMenuItem(
                            "SchoolSystems.Roles.Teachers", 
                            l["Menu:Teachers"], 
                            icon: "fa fa-user", 
                            url:"/Roles/Teachers"))
                    .AddItem( 
                        new ApplicationMenuItem(
                            "SchoolSystems.Roles.Guardians", 
                            l["Menu:Guardians"], 
                            icon: "fa fa-user", 
                            url:"/Roles/Guardians"))
                )
            );
        


        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 5;

        //Administration->Identity
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);
    
        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }
        
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        //Administration->Settings
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 7);
        
        return Task.CompletedTask;
    }
}
