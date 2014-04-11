using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NewVersionLampstore.Service.Factory;
using System.Web.Security;
using NewVersionLampstore.Models;
using NewVersionLampstore.Binders;

namespace NewVersionLampstore
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Manufacturers",
                "manufacturers/{shortname}",
                new { controller = "Manufacturer", action = "GetByShortName", shortname = UrlParameter.Optional } //Хлебные крошки  Виробник
                );
            routes.MapRoute(
                "Products",
                "products/{shortname}",
                new { controller = "Product", action = "GetByShortName", shortname = UrlParameter.Optional }
                );
            routes.MapRoute(
              "ProductInCategoryInManufacturer",
              "catalog/{category}/manufacturers/{manufacturer}/products/{product}",
              new { controller = "Product", action = "GetProductInCatogoryInManufacturer" }
              );


            routes.MapRoute(
                "ProductInManufacturer",
                "manufacturers/{manufacturer}/{product}",
                new { controller = "Product", action = "GetProductInManufacturer" }
                );

           

            routes.MapRoute(
        "Categories",
        "catalog/{shortname}",
        new { controller = "Category", action = "GetByShortName", shortname = UrlParameter.Optional }
        );
            routes.MapRoute(
        "Collections",
        "catalog/{category}/{collection}",
        new { controller = "Collection", action = "GetCollectionInCategory" }
        );
            routes.MapRoute(
                "ProductInCategory",
                "catalog/{category}/products/{product}",
                new { controller = "Product", action = "GetProductInCategory" }
                );
           


            routes.MapRoute(
                "ProductInCollection",
                "catalog/{category}/{collection}/{product}",
                new { controller = "Product", action = "GetProductInCollection" }
                );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }
        public static void AddAdmin()
        {
            // Если нет в системе роли admin, создаём её
            if (!Roles.RoleExists(Constants.ROLE_ADMIN))
               Roles.CreateRole(Constants.ROLE_ADMIN);

            // Если нет в системе пользователя admin, создаём его
            if (Membership.GetUser("admin") == null)
            {
                MembershipCreateStatus status = MembershipCreateStatus.Success;
                
                Membership.CreateUser("admin", "temp_pass", "mato.84@mail.ru", "My favourite writer", "admin mato", true, out status);//password dat1984
                
                
            }

            // Если у пользователя admin нет роли admin, присваиваем ему эту роль
           if (!Roles.IsUserInRole("admin", Constants.ROLE_ADMIN))
                Roles.AddUserToRole("admin", Constants.ROLE_ADMIN);
        }
        

       protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            AddAdmin();
            ModelBinders.Binders.Add(typeof(FilterData), new UserSessionDataBinder());
            ControllerBuilder.Current.SetControllerFactory(new NinjectControlerFactory());
        }
    }
}