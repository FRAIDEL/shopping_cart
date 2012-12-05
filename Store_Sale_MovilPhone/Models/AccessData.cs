using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store_Sale_MovilPhone.Models;
using System.Data.Entity;

namespace Store_Sale_MovilPhone.Models
{
    public class AccessData  : DbContext
    {
        public DbSet<MovilPhone> movilPhone { get; set; }
        public DbSet<Factura> facturas { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Cart> cart { get; set; }
    }
}