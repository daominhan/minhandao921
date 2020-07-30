using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bangaubong
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SanPhamAll",
                url: "san-pham",
                defaults: new { controller = "Sanpham", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SanPhamCat",
                url: "san-pham/{slugcat}",
                defaults: new { controller = "Sanpham", action = "Category", id = UrlParameter.Optional }
            );
            routes.MapRoute(
             name: "ProductDetail",
             url: "san-pham/{slugcat}/{slug}",
             defaults: new { controller = "Sanpham", action = "ProductDetail", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Lienhe",
              url: "lien-he",
              defaults: new { controller = "Lienhe", action = "Index", id = UrlParameter.Optional }
          );
                        routes.MapRoute(
            name: "xoa gio hang",
            url: "xoa-gio-hang",
            defaults: new { controller = "Cart", action = "deleteitem", id = UrlParameter.Optional }
            );
            routes.MapRoute(
    name: "capnhat",
    url: "cap-nhat",
    defaults: new { controller = "Cart", action = "updateitem", id = UrlParameter.Optional }
    );
            routes.MapRoute(
        name: "them vao gio hang",
        url: "them-sp-giohang",
        defaults: new { controller = "Cart", action = "Additem", id = UrlParameter.Optional }
        );
            routes.MapRoute(
          name: "gio hang",
          url: "gio-hang",
          defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
           name: "Gioithieu",
           url: "gioi-thieu",
           defaults: new { controller = "Gioithieu", action = "Index", id = UrlParameter.Optional }
       );
            routes.MapRoute(
        name: "Tintuc",
        url: "tin-tuc",
        defaults: new { controller = "Tintuc", action = "Index", id = UrlParameter.Optional }
    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Trangchu", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}