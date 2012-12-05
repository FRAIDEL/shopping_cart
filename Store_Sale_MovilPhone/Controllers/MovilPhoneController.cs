using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store_Sale_MovilPhone.Models;

namespace Store_Sale_MovilPhone.Controllers
{ 
    public class MovilPhoneController : Controller
    {
        private AccessData db = new AccessData();

        //
        // GET: /MovilPhone/

        public ViewResult Index()
        {
            var movilphone = db.movilPhone.Include(m => m.Marca);
            return View(movilphone.ToList());
        }

        //
        // GET: /MovilPhone/Details/5

        public ViewResult Details(int id)
        {
            MovilPhone movilphone = db.movilPhone.Find(id);
            return View(movilphone);
        }

        //
        // GET: /MovilPhone/Create

        public ActionResult Create()
        {
            ViewBag.MarcaID = new SelectList(db.Marca, "MarcaID", "Nombre");
            return View();
        } 

        //
        // POST: /MovilPhone/Create

        [HttpPost]
        public ActionResult Create(MovilPhone movilphone)
        {
            if (ModelState.IsValid)
            {
                db.movilPhone.Add(movilphone);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.MarcaID = new SelectList(db.Marca, "MarcaID", "Nombre", movilphone.MarcaID);
            return View(movilphone);
        }
        
        //
        // GET: /MovilPhone/Edit/5
 
        public ActionResult Edit(int id)
        {
            MovilPhone movilphone = db.movilPhone.Find(id);
            ViewBag.MarcaID = new SelectList(db.Marca, "MarcaID", "Nombre", movilphone.MarcaID);
            return View(movilphone);
        }

        //
        // POST: /MovilPhone/Edit/5

        [HttpPost]
        public ActionResult Edit(MovilPhone movilphone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movilphone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarcaID = new SelectList(db.Marca, "MarcaID", "Nombre", movilphone.MarcaID);
            return View(movilphone);
        }

        //
        // GET: /MovilPhone/Delete/5
 
        public ActionResult Delete(int id)
        {
            MovilPhone movilphone = db.movilPhone.Find(id);
            return View(movilphone);
        }

        //
        // POST: /MovilPhone/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            MovilPhone movilphone = db.movilPhone.Find(id);
            db.movilPhone.Remove(movilphone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}