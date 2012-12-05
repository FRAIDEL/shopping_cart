using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Store_Sale_MovilPhone.Models;

namespace Store_Sale_MovilPhone.Models
{
    
    public class ShoppingCart
    {
        AccessData db = new AccessData();

        public const string CartSessionKey = "idSession";

        // almacena el identificador de carrito actual
        // me permite identificar los elementos dentro del carrito
        string ShoppingCartId { get; set; }

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();

                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }

        // Agregar items al carrito
        public void addCart(MovilPhone telefono) {
            // Obtengo la instancia de este telefono(parametro) esta en el carrito
            var countItemsCart = db.cart.SingleOrDefault
                (c => c.idCart == ShoppingCartId 
                 && c.MovilPhoneID == telefono.MovilPhoneID);
            
            // si no esta este Telefono en el cart
            if (countItemsCart == null)
            {
                // lo creo (lo coloco en el carrito)
                countItemsCart = new Cart
                {
                    idCart = ShoppingCartId,
                    MovilPhoneID = telefono.MovilPhoneID,
                    Cantidad = 1,
                    PrecioUnidad = telefono.PrecioUnidad
                };
                db.cart.Add(countItemsCart);

            } // si se encuentra este telefono en el cart le sumo 1 a la cantidad actual
            else {
                countItemsCart.Cantidad++;
            }
            //guardo en cart
            db.SaveChanges();
        }

        //remover un telefono del cart y debuelvo la cantidad de telefonos q quedan
        public int RemoveFromCart(int id) { 
            //obtengo la instrancia de este telefono del cart
            var telefono = db.cart.Single
            (c => c.idCart == ShoppingCartId 
            &&  c.MovilPhoneID == id);
            
            int countItems = 0;

            if(telefono != null){
                // si la cantidad del obj telefono es > 1 le quito 1 a la cantidad actual
                if (telefono.Cantidad > 1)
                {
                    telefono.Cantidad--;
                    countItems = telefono.Cantidad;
                } // si lantidad de este obj no es > 1 lo elimino del cart
                else
                {
                    db.cart.Remove(telefono);
                }

                //***
                if(telefono == null){
                    countItems = 17;
                }
                //***
                // guardo los cambios
                db.SaveChanges();
            }         
            return countItems;
        }

        // vaciar el cart
        public void EmptyCart() {
            // obtengo los items del carrito current
            var itemsCurrentCart = db.cart.Where(c => c.idCart == ShoppingCartId );
            
            // elimino cada items del cart
            foreach(var items in itemsCurrentCart){
                db.cart.Remove(items);
            }
        }

        // obtengo los items del cart
        public List<Cart> GetCartItems() {
            return db.cart.Where(c => c.idCart == ShoppingCartId).ToList();
        } 

        // obtengo la suma total de todos los telefonos en el cart
        public int GetCountItemsTotal() {
            int? count = (from items in db.cart 
                         where items.idCart == ShoppingCartId
                         select (int?)items.Cantidad).Sum();

            return count ?? 0;
        }

        // valor total de la compra
        public decimal GetTotal() {
            decimal? count = (
                    from items in db.cart
                    where items.idCart == ShoppingCartId
                    select (int?)items.Cantidad * items.movilPhone.PrecioUnidad).Sum();
            return count ?? 0;
        }

        //************************* FACTURA *****************************************
        //[HttpPost]
        public void SaveFactura(int Id)
        {
            // recibe el id del User
            var objCart = new ShoppingCart();

            // obtengo todo del carrito actual
            var cartAll = db.cart.Where(c => c.idCart == ShoppingCartId);
            // guardo cada items el factura
            foreach (var cart in cartAll)
            {
                var ft = new Factura
                {
                    IdentificatedFactura = ShoppingCartId,
                    ClienteID = Id,
                    Items = new Cart {
                        idCart = ShoppingCartId,
                        MovilPhoneID = cart.MovilPhoneID,
                        Cantidad = cart.Cantidad,
                        PrecioUnidad = cart.PrecioUnidad
                    }
                };


                //Factura f = new Factura();
                //f.IdentificatedFactura = ShoppingCartId;
                //f.ClienteID = Id;
                //f.Items = new Cart
                //{
                //    idCart = ShoppingCartId,
                //    MovilPhoneID = cart.MovilPhoneID,
                //    Cantidad = cart.Cantidad,
                //    PrecioUnidad = cart.PrecioUnidad
                //};

                //saverd factura
                db.facturas.Add(ft);
            }
            db.SaveChanges();
        }

        // dame los info de facturas con el identificadorFactura = 
        //public List<Factura> ShowFactura() {
        public List<Factura> ShowFactura()
        {
            //List<Factura> facturaToShow = db.facturas.Include("Cart").Where(f => f.IdentificatedFactura == ShoppingCartId).ToList();
            var facturaToShow = db.facturas.Include("Cart").ToList();
            return facturaToShow;
        }
        

    }
}