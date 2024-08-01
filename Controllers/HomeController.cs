using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeautyStore.DesignPattern;
using BeautyStore.Models;

namespace BeautyStore.Controllers
{

    public class HomeController : Controller
    {
        private BeautyStoreEntities1 db = new BeautyStoreEntities1();

        private BrandFlyweightFactory brandFactory = new BrandFlyweightFactory();

        [SparkleEffect]
        public ActionResult Index()
        {
            //lấy danh sách brand
            var brandsList = db.Brands.Take(8).ToList();
            //duyệt qua từng thương hiệu trong brandsList
            foreach (var brand in brandsList)
            {
                BrandFlyweight brandFlyweight = brandFactory.GetBrandFlyweight(brand.BrandID, brand.BrandImage);
                brandFlyweight.Display();
            }
            //hiển thị thương hiệu
            ViewBag.BrandsList = brandsList;

            //ViewBag.CategoriesList = db.Categories.ToList().Take(8);
            ViewBag.ProductsList = (from item in db.Products orderby item.ProductID descending select item).ToList().Take(10);

            int firstCate = db.Categories.First().CategoryID;
            int secondCate = db.Categories.FirstOrDefault(c => c.CategoryID != firstCate).CategoryID;

            ViewBag.FirstCate = db.Categories.FirstOrDefault(c => c.CategoryID == firstCate);
            ViewBag.SecondCate = db.Categories.FirstOrDefault(c => c.CategoryID == secondCate);

            ViewBag.ProductsList_1 = db.Products.Where(p => p.CategoryID == firstCate).ToList().Take(10);
            ViewBag.ProductsList_2 = db.Products.Where(p => p.CategoryID == secondCate).ToList().Take(10);

            return View();
        }

        public ActionResult ProductCategory(int id)
        {
            var product = (from item in db.Products orderby item.ProductID descending where item.CategoryID == id select item).ToList();
            ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
            ViewBag.IdCategory = id;
            return View(product);
        }
        public ActionResult Introduction()
        {
            return View();
        }
    }
}