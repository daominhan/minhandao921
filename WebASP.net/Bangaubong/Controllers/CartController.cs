using Bangaubong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Bangaubong.Controllers
{
    public class CartController : Controller
    {
        // khởi tạo session:
        private const string SessionCart = "SessionCart";
        // GET: Cart
        BangaubongDBContext db = new BangaubongDBContext();
        public ActionResult Index()
        {
            var cart = Session[SessionCart];
            var list = new List<Cart_item>();
            if (cart != null)
            {
                list = (List<Cart_item>)cart;
            }
            return View(list);
        }
        public ActionResult card_header()
        {
            var cart = Session[SessionCart];
            var list = new List<Cart_item>();
            if (cart != null)
            {
              
                list = (List<Cart_item>)cart;
                int quantytyyy = 0;
                foreach (var item1 in list)
                {
                    quantytyyy += item1.quantity;
                }
                ViewBag.quantity = quantytyyy;
                }
            return View(list);
        }
        public RedirectToRouteResult updateitem(long P_SanPhamID, int P_quantity)
        {
            var cart = Session[SessionCart];
            var list = (List<Cart_item>)cart;
            Cart_item itemSua = list.FirstOrDefault(m => m.product.Id == P_SanPhamID);
            if (itemSua != null)
            {
                itemSua.quantity = P_quantity;
            }
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult deleteitem(long productID)
        {
            var cart = Session[SessionCart];
            var list = (List<Cart_item>)cart;

            Cart_item itemXoa = list.FirstOrDefault(m => m.product.Id == productID);
            if (itemXoa != null)
            {
                list.Remove(itemXoa);
            }
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult Additem(long productID, int quantity)
        {
            var item = new Cart_item();
            Mproduct product = db.Products.Find(productID);
            var cart = Session[SessionCart];
            if (cart != null)
            {
                var list = (List<Cart_item>)cart;
                if (list.Exists(m => m.product.Id == productID))
                {
                    int quantity1 = 0;
                    foreach (var item1 in list)
                    {
                        if (item1.product.Id == productID)
                        {
                            item1.quantity += quantity;
                            quantity1 = item1.quantity;
                        }
                    }
                    int priceTotol = 0;
                    
                    int price = 0;
                    foreach (var item1 in list)
                    {
                        int temp = (int)item1.product.Price * (int)item1.quantity;
                        priceTotol += temp;
                       
                        price = (int)item1.product.Price;
                    }
                    return RedirectToAction("Index");

                }
                else
                {
                    item.product = product;
                    item.quantity = quantity;
                    list.Add(item);
                    item.countCart = list.Count();
                    item.meThod = "cartExist";
                    int priceTotol = 0;
                    foreach (var item1 in list)
                    {
                        int temp =(int)item1.product.Price * (int)item1.quantity;
                        priceTotol += temp;
                    }
                    item.priceTotal = priceTotol;
                    return RedirectToAction("Index");
                }
            }
            else
            {               
                item.product = product;
                item.quantity = quantity;
                item.meThod = "cartEmpty";
                item.countCart = 1;
                item.priceTotal =(int) product.Price;
                var list = new List<Cart_item>();
                list.Add(item);
                Session[SessionCart] = list;
               
            }
            return RedirectToAction("Index");
        }
    }
}