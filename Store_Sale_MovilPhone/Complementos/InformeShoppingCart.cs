using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store_Sale_MovilPhone.Models;

namespace Store_Sale_MovilPhone.Complementos
{
    public class InformeShoppingCart
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}