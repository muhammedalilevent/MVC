using _13_MVC_Session.Cart;
using _13_MVC_Session.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _13_MVC_Session.Controllers
{
    public class CartController : Controller
    {
        Entities db;
        public CartController()
        {
            db = new Entities();
        }
        public ActionResult Index()
        {
            return View();
        }

        #region Sepet Listesi
        public JsonResult List()
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                List<ProductVM> productList = cart.CartProductList.Select(x => new ProductVM
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    UnitsInStock = x.UnitsInStock,
                    Quantity = x.Quantity
                }).ToList();

                return Json(productList, JsonRequestBehavior.AllowGet);
            }
            return Json("Empty", JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Sepet Ekleme
        [HttpPost]
        public JsonResult Add(int id)
        {
            Product product = db.Products.Find(id);
            ProductVM vm = new ProductVM
            {
                Id = product.ProductID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                Quantity = 1
            };
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.AddCart(vm);
                Session["sepet"] = cart;
            }
            else
            {
                ProductCart cart = new ProductCart();
                cart.AddCart(vm);
                Session.Add("sepet", cart);
            }
            return Json("");

        }
        #endregion

        #region Ürün Azaltma
        public JsonResult DeCreaseCart(int id)
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.DeCreaseCart(id);
                Session["sepet"] = cart;
            }
            return Json("");
        }
        #endregion

        #region Ürün Arttırma
        public JsonResult InCreaseCart(int id)
        {
            ProductCart cart = Session["sepet"] as ProductCart;
            cart.InCreaseCart(id);
            Session["sepet"] = cart;
            return Json("");
        }
        #endregion

        #region Sepetten Ürün Silme
        public JsonResult Remove(int id)
        {
            ProductCart cart = Session["sepet"] as ProductCart;
            cart.RemoveCart(id);
            Session["sepet"] = cart;
            return Json("");
        }
        #endregion
    }
}