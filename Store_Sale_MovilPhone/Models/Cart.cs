using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Store_Sale_MovilPhone.Models
{
    public class Cart
    {
        [Key]
        public int recardID { get; set; }
        public string idCart { get; set; } // identifico al carrito (no es key xq se repetira en los records)
        public int MovilPhoneID { get; set; } // lo q se esta comprando
        public int Cantidad { get; set; } // la cantidad de lo q se compra
        public decimal PrecioUnidad { get; set; }

        public virtual MovilPhone movilPhone { get; set; }
    }
}