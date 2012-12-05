using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store_Sale_MovilPhone.Models;

namespace Store_Sale_MovilPhone.Controllers
{
    [Authorize]
    public class FacturarController : Controller
    {
        AccessData db = new AccessData();

        //
        // GET: /Facturar/

        //public ActionResult Index()
        //{
        //    return View();
        //}        
        //[HttpPost]
        //public ActionResult SavedFactura (int Id) { // recibe el id del User
        //    var objCart = new ShoppingCart();
        //    string cartCurrent = objCart.GetCartId(this.HttpContext);
            
        //    // obtengo todo del carrito actual
        //    var cartAll = db.cart.Where(c => c.idCart == cartCurrent);
        //    // guardo cada items el factura
        //    foreach(var cart in cartAll){
        //        Factura f = new Factura();
        //        f.IdentificatedFactura = cartCurrent;
        //        f.ClienteID = Id;
        //        f.Items = new Cart { 
        //            idCart = cartCurrent,
        //            MovilPhoneID = cart.MovilPhoneID,
        //            Cantidad = cart.Cantidad,
        //            PrecioUnidad = cart.PrecioUnidad
        //        };
        //        db.SaveChanges();
        //    }
        //    // obtengo los datos de factura q se han guardado
        //    var listElementsFactura = db.facturas.Where(f => f.IdentificatedFactura == cartCurrent);
        //    return View(listElementsFactura);
        //}

    }
}
