using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Store_Sale_MovilPhone.Models
{
    public class Marca
    {
        public int MarcaID { get; set; }
        
        [Required]
        [Display(Name = "Nombre del Fabricante : ")]
        public string Nombre { get; set; }

        
        [Required]
        [Display(Name = "Detalles : ")]
        public string DetallesMarca { get; set; }

        public virtual List<MovilPhone> MovilPhone_Marca { get; set; }
    }
}