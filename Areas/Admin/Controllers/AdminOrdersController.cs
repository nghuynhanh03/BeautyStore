﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeautyStore.Models;

namespace BeautyStore.Areas.Admin.Controllers
{
    public class AdminOrdersController : Controller
    {
        private BeautyStoreEntities1 db = new BeautyStoreEntities1();

        // GET: Admin/AdminOrders
        public ActionResult Index()
        {
            var orders = (from order in db.Orders orderby order.IdOrder descending select order).ToList();
            return View(orders.ToList());
        }

        // GET: Admin/AdminOrders/Details/5
        public ActionResult Details(int? id)
        {
            var listProdOrder = db.OrderDetails.Where(order => order.IdOrder == id).ToList();
            decimal finalPrice = 0;
            foreach (var item in listProdOrder)
            {
                finalPrice += (decimal)item.FinalPrice;
            }
            ViewBag.FinalPrice = finalPrice;
            ViewBag.Address = db.Orders.FirstOrDefault(o => o.IdOrder == id).Address;
            ViewBag.Date = db.Orders.FirstOrDefault(o => o.IdOrder == id).DateOrder;
            ViewBag.Id = db.Orders.FirstOrDefault(o => o.IdOrder == id).IdOrder;
            ViewBag.Status = db.Orders.FirstOrDefault(o => o.IdOrder == id).StatusOrder;

            ViewBag.CusInfor = db.Orders.FirstOrDefault(o => o.IdOrder == id);

            return View(listProdOrder);
        }

        public ActionResult Confirm(int id)
        {
            var prodListOrder = db.OrderDetails.Where(o => o.IdOrder == id).ToList();
            foreach (var item in prodListOrder)
            {
                var product = db.Products.FirstOrDefault(p => p.ProductID == item.ProductID);
                product.amount -= (int)item.Quantity;
                db.SaveChanges();
            }
            var order = db.Orders.FirstOrDefault(o => o.IdOrder == id);
            order.StatusOrder = 2;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CancelOrder(int id)
        {
            var order = db.Orders.FirstOrDefault(o => o.IdOrder == id);
            order.StatusOrder = 3;
            db.SaveChanges();

            int idUser = order.UserID.GetValueOrDefault();
            return RedirectToAction("Index");
        }

    }
}
