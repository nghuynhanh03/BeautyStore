using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeautyStore.Models;

namespace BeautyStore.Controllers
{
    public class FiltProductController : Controller
    {
        BeautyStoreEntities1 db = new BeautyStoreEntities1();
        // GET: FiltProduct
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Under200lAllProduct(int id)
        {
            if (id == 0)
            {
                var products = (from item in db.Products orderby item.ProductID descending where item.Price <= 200000 select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
            else
            {
                var products = (from item in db.Products orderby item.ProductID descending where item.Price <= 200000 && item.CategoryID == id select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
        }

        //từ 4 củ tới 8 củ
        public ActionResult From200To400AllProduct(int id)
        {
            if (id == 0)
            {
                var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 200000 && item.Price <= 400000 select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);

                ViewBag.IdCategory = id;

                return View(products);
            }
            else
            {
                var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 200000 && item.Price <= 400000 && item.CategoryID == id select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);

                ViewBag.IdCategory = id;

                return View(products);
            }
        }
        //từ 8 củ tới 12 củ
        public ActionResult From400To600AllProduct(int id)
        {
            if (id == 0)
            {
                var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 400000 && item.Price <= 600000 select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
            else
            {
                var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 400000 && item.Price <= 600000 && item.CategoryID == id select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
        }
        //trên 12 củ
        public ActionResult Over600AllProduct(int id)
        {
            if (id == 0)
            {
                var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 600000 select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
            else
            {
                var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 600000 && item.CategoryID == id select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
        }


        //giá thấp -> cao
        public ActionResult IncreaseWithPrice(int id)
        {
            if (id == 0)
            {
                var products = (from item in db.Products orderby item.Price ascending select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
            else
            {
                var products = (from item in db.Products orderby item.Price ascending where item.CategoryID == id select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
        }


        //giá cao -> thấp
        public ActionResult DescreaseWithPrice(int id)
        {
            if (id == 0)
            {
                var products = (from item in db.Products orderby item.Price descending select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
            else
            {
                var products = (from item in db.Products orderby item.Price descending where item.CategoryID == id select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
        }

    }
}