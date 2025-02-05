﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeautyStore.Models;

namespace BeautyStore.Areas.Admin.Controllers
{
    public class AdminBrandsController : Controller
    {
        private BeautyStoreEntities1 db = new BeautyStoreEntities1();

        // GET: Admin/AdminBrands
        public ActionResult Index()
        {
            return View(db.Brands.ToList());
        }

        // GET: Admin/AdminBrands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: Admin/AdminBrands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminBrands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrandID,BrandName,BrandImage")] Brand brand, HttpPostedFileBase ImgBrand)
        {
            if (ModelState.IsValid)
            {
                if (ImgBrand != null)
                {
                    var fileName = Path.GetFileName(ImgBrand.FileName);
                    var path = Path.Combine(Server.MapPath("~/image"), fileName);
                    brand.BrandImage = fileName;
                    ImgBrand.SaveAs(path);
                }
                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brand);
        }

        // GET: Admin/AdminBrands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Admin/AdminBrands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrandID,BrandName,BrandImage")] Brand brand, HttpPostedFileBase ImgBrand)
        {
            if (ModelState.IsValid)
            {
                if (ImgBrand != null)
                {
                    var fileName = Path.GetFileName(ImgBrand.FileName);
                    var path = Path.Combine(Server.MapPath("~/image"), fileName);
                    brand.BrandImage = fileName;
                    ImgBrand.SaveAs(path);
                }
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brand);
        }

        // GET: Admin/AdminBrands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Admin/AdminBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand brand = db.Brands.Find(id);
            db.Brands.Remove(brand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
