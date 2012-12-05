using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store_Sale_MovilPhone.Models;
using Store_Sale_MovilPhone.Complementos;

namespace Store_Sale_MovilPhone.Controllers
{
    public class ShoppingCartController : Controller
    {
        AccessData db = new AccessData();

        //
        // GET: /ShoppingCart/

        // me muestra lie items q he comprado
        public ActionResult Index() {   
            //obtengo la instancia del carrito
            var cart = ShoppingCart.GetCart(this.HttpContext);
            //creo un InformeItemssHoppingCart (informacion del carrito)
            var infoCart = new InformeShoppingCart
            {
                CartItems = cart.GetCartItems(), // lista de items del cart
                CartTotal = cart.GetTotal() // suma total de los elements de cart
            };
            
            return View(infoCart);
        }

        public ActionResult AddToCart(int id) {
            // obtengo el tel q se va a agregar
            var tel = db.movilPhone.Single(t => t.MovilPhoneID == id);
            /* instancia del modelo shoppingCart q tiene el metodo addToCart
            q me agrega el telf de la manera correspondiente */
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.addCart(tel); // lo agrega i guarda en la db

            return RedirectToAction("Index");
        }

        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        //[HttpPost]
        public ActionResult RemoveToItems(int id) {
            // primero como siempre es reconocer el carrito del q se esta tratando
            var cart = ShoppingCart.GetCart(this.HttpContext);
            // obtengo el modelo del telefono q quiero eliminar
            string modeloTel = db.cart.Single(t => t.recardID == id).movilPhone.Modelo;

            // quito el elemento del cart
            int countTelCurrent = cart.RemoveFromCart(id);
            //int countTelCurrent = 1;

            var reslt = new RemoveItemsShoppingCart
            {
                Message = Server.HtmlEncode(modeloTel) + " ha sido removido de tu Carrito..!",
                CountTotal = cart.GetTotal(),
                CountItmes = countTelCurrent, // cuantos items del q estoy eliminando me quedan
                CountCart = cart.GetCountItemsTotal(),// obtengo la suma total de todos los telefonos en el cart
                DeletedId = id
            };
            
            return RedirectToAction("Index");
            //return Json(reslt);
        }

        ////************************* FACTURA *****************************************
        ////[HttpPost]
        public ActionResult SaveFactura(int Id)
        {
            var cart = new ShoppingCart();
            //llamo al metodo q guarda la factura
            cart.SaveFactura(Id); // ojo el Id es de User y es arvitrario
            return RedirectToAction("ShowToFactura");
        }

        public ActionResult ShowToFactura()
        {
            //var objCart = new ShoppingCart();
            //string cartCurrent = objCart.GetCartId(this.HttpContext);
            //// obtengo los datos de factura q se han guardado
            //var listElementsFactura = db.facturas.Where(f => f.IdentificatedFactura == cartCurrent);
            //return View(listElementsFactura);

            string textError = null;
            var car = new ShoppingCart();
            try {
                if (car.ShowFactura() == null)
                {
                    ViewBag.error = "si es null";
                }
                else
                {
                    ViewBag.error = "no es null es => " + car.ShowFactura();
                }
            }catch(Exception er){
                textError = er.ToString();
            }

            ViewBag.error = textError;
            return View(car.ShowFactura());
        }


       

    }
}