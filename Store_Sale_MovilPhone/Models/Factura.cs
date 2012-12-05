using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Store_Sale_MovilPhone.Models
{
    public class Factura
    {
        // se crea un registro por cada items(Elementos)

        public int FacturaID { get; set; }
        public string IdentificatedFactura { get; set; }
        public int ClienteID { get; set; }
        public Cart Items { get; set; } // aqui obtengo los items, la cantidad de cada uno y el precio unitario

        public virtual Cart cart { get; set; }
    }
}