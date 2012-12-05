using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Store_Sale_MovilPhone.Models
{
    public class MovilPhone
    {
        public int MovilPhoneID { get; set; }

        public int MarcaID { get; set; }

        [Required]
        [Display(Name = "Modelo :")]
        public string Modelo { get; set; }


        [Required]
        [Display(Name = "Fecha de Venta : ")]
        public DateTime FechaVenta { get; set; }//fecha q se vendio

        [Required]
        [Display(Name = "Punto de Venta : ")]
        public string PuntoVenta { get; set; }

        [Required]
        [Display(Name = "Tiempo de Garantia(en Meses) : ")]
        public int TiempoGarantia { get; set; }

        [Required]
        [Display(Name = "Precio por Unidad : ")]
        public Decimal PrecioUnidad { get; set; }

        public virtual List<Cart> cart { get; set; }
        public virtual Marca Marca { get; set; }
    }
}