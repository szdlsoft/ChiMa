using System;
using Abp.Application.Navigation;
using Abp.Localization;
using SixMan.ChiMa.Application.Authorization;
using SixMan.ChiMa.Domain;
using SixMan.ChiMa.Domain.Authorization;

namespace SixMan.ChiMa.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class ChiMaNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            var HomeMenu = new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "home",
                        requiresAuthentication: true
                    );
            MenuItemDefinition SysMenu = CreateSysMenu();

            MenuItemDefinition FoodMenu = CreateFooMenu();
            //MenuItemDefinition DishMenu = CreateDisMenu();

            context.Manager.MainMenu
                .AddItem(HomeMenu)
                .AddItem(SysMenu)
                .AddItem(FoodMenu)
                //.AddItem(DishMenu)
                ;

        }

        private static MenuItemDefinition CreateSysMenu()
        {
            return new MenuItemDefinition(
                        PageNames.System,
                        L("System"),
                        icon: "menu"
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Users,
                            L("Users"),
                            url: "Users",
                            icon: "people",
                            requiredPermissionName: PermissionNames.Pages_Users
                            )
                     ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Roles,
                            L("Roles"),
                            url: "Roles",
                            icon: "local_offer",
                            requiredPermissionName: PermissionNames.Pages_Roles
                        )
                    );



        }

        //private MenuItemDefinition CreateDisMenu()
        //{
        //    return
        //        new MenuItemDefinition(
        //                             PageNames.Dish,
        //                                L("Dish"),
        //                                icon: "menu"
        //                        ).AddItem(
        //                    new MenuItemDefinition(
        //                        "AspNetZeroHome",
        //                        new FixedLocalizableString("Home"),
        //                        url: "https://aspnetzero.com?ref=abptmpl"
        //                    )
        //                ).AddItem(
        //                    new MenuItemDefinition(
        //                        "AspNetZeroDescription",
        //                        new FixedLocalizableString("Description"),
        //                        url: "https://aspnetzero.com/?ref=abptmpl#description"
        //                    )
        //                ).AddItem(
        //                    new MenuItemDefinition(
        //                        "AspNetZeroHome",
        //                        new FixedLocalizableString("Home"),
        //                        url: "https://aspnetzero.com?ref=abptmpl"
        //                    )
        //                ).AddItem(
        //                    new MenuItemDefinition(
        //                        "AspNetZeroDescription",
        //                        new FixedLocalizableString("Description"),
        //                        url: "https://aspnetzero.com/?ref=abptmpl#description"
        //                    )
        //                );
        //}

        private MenuItemDefinition CreateFooMenu()
        {
            return
                new MenuItemDefinition(
                        PageNames.DishFood,
                        L("DishFood"),
                        icon: "menu"
                        ).AddItem(
                            new MenuItemDefinition(
                            PageNames.FoodMaterialCategory,
                            L("FoodMaterialCategory"),
                            url: "FoodMaterialCategory"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                            PageNames.FoodMaterial,
                            L("FoodMaterial"),
                            url: "FoodMaterial"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                            PageNames.Dish,
                            L("Dish"),
                            url: "Dish"
                            )
                    );
        }

        //public  void xSetNavigation(INavigationProviderContext context)
        //{
        //    context.Manager.MainMenu
        //        .AddItem(
        //            new MenuItemDefinition(
        //                PageNames.Home,
        //                L("HomePage"),
        //                url: "",
        //                icon: "home",
        //                requiresAuthentication: true
        //            )
        //        ).AddItem(
        //            new MenuItemDefinition(
        //                PageNames.Tenants,
        //                L("Tenants"),
        //                url: "Tenants",
        //                icon: "business",
        //                requiredPermissionName: PermissionNames.Pages_Tenants
        //            )
        //        ).AddItem(
        //            new MenuItemDefinition(
        //                PageNames.Users,
        //                L("Users"),
        //                url: "Users",
        //                icon: "people",
        //                requiredPermissionName: PermissionNames.Pages_Users
        //            )
        //        ).AddItem(
        //            new MenuItemDefinition(
        //                PageNames.Roles,
        //                L("Roles"),
        //                url: "Roles",
        //                icon: "local_offer",
        //                requiredPermissionName: PermissionNames.Pages_Roles
        //            )
        //        )
        //        .AddItem(
        //            new MenuItemDefinition(
        //                PageNames.About,
        //                L("About"),
        //                url: "About",
        //                icon: "info"
        //            )
        //        ).AddItem( //Menu items below is just for demonstration!
        //            new MenuItemDefinition(
        //                PageNames.FoodMaterial,
        //                L("FoodMaterial"),
        //                icon: "menu"
        //            ).AddItem(
        //                new MenuItemDefinition(
        //                    PageNames.FoodMaterialCategory,
        //                    L("FoodMaterialCategory"),
        //                    url: "FoodMaterialCategory"
        //                )
        //            ).AddItem(
        //                    new MenuItemDefinition(
        //                       PageNames.FoodMaterial,
        //                       L("FoodMaterial"),
        //                       url: "FoodMaterial"
        //                    )
        //            )
        //          ).AddItem(
        //                new MenuItemDefinition(
        //                    PageNames.Dish,
        //                    L("Dish"),
        //                    icon:"menu"
        //                ).AddItem(
        //                    new MenuItemDefinition(
        //                        "AspNetZeroHome",
        //                        new FixedLocalizableString("Home"),
        //                        url: "https://aspnetzero.com?ref=abptmpl"
        //                    )
        //                ).AddItem(
        //                    new MenuItemDefinition(
        //                        "AspNetZeroDescription",
        //                        new FixedLocalizableString("Description"),
        //                        url: "https://aspnetzero.com/?ref=abptmpl#description"
        //                    )
        //                )
        //           )
        //    ;
        //}

        private static ILocalizableString L(string name)
        {
            //var source = LocalizationHelper.GetSource("ChiMa");
            //var s1 = source.GetString("HomePage");
            return new LocalizableString(name, ChiMaConsts.LocalizationSourceName);
        }
    }
}
