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
    public class MarcaController : Controller
    {
        private AccessData db = new AccessData();

        //
        // GET: /Marca/

        public ViewResult Index()
        {
            return View(db.Marca.ToList());
        }

        // vista para mostrar las diferentes marcas
        public ViewResult ShowMarcas() {
            var marca = db.Marca.Include("MovilPhone_Marca").ToList();
            return View(marca);
        }

        // mostrar los telefonos de esta Marca
        public ViewResult showPhoneForMarca(string  nombreMarca) {
            // traigo todos los tel cuya marca sea "nombreMarca"
            var marcaCurrent = db.Marca.Include("MovilPhone_Marca").Single(m => m.Nombre == nombreMarca);
            ViewBag.nameMarca = nombreMarca.ToUpper();
            return View(marcaCurrent);
        }

        //
        // GET: /Marca/Details/5

        public ViewResult Details(int id)
        {
            Marca marca = db.Marca.Find(id);
            return View(marca);
        }

        //
        // GET: /Marca/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Marca/Create

        [HttpPost]
        public ActionResult Create(Marca marca)
        {
            if (ModelState.IsValid)
            {
                db.Marca.Add(marca);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(marca);
        }
        
        //
        // GET: /Marca/Edit/5
 
        public ActionResult Edit(int id)
        {
            Marca marca = db.Marca.Find(id);
            return View(marca);
        }

        //
        // POST: /Marca/Edit/5

        [HttpPost]
        public ActionResult Edit(Marca marca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marca);
        }

        //
        // GET: /Marca/Delete/5
 
        public ActionResult Delete(int id)
        {
            Marca marca = db.Marca.Find(id);
            return View(marca);
        }

        //
        // POST: /Marca/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Marca marca = db.Marca.Find(id);
            db.Marca.Remove(marca);
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