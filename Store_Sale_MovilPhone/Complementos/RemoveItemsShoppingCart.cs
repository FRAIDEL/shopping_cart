using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store_Sale_MovilPhone.Complementos
{
    // esta clase se utiliza para mostrar informacion del items eliminado
    public class RemoveItemsShoppingCart
    {
        public string Message { get; set; }
        public decimal CountCart { get; set; } // cantidad de elementos del cart
        public decimal CountItmes { get; set; }
        public decimal CountTotal { get; set; }
        public int DeletedId { get; set; }
    }
}