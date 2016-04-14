using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AutoVentasHiken.Models
{
    public class Compra
    {
        [Key]
        public int id_Compra { get; set; }

        //ID de donde saca la operacion
        [Display(Name = "Vehiculo")]
        public int id_Vehiculo { get; set; }
        [Display(Name = "Usuario")]
        public int id_Usuario { get; set; }

        [Display(Name="Fecha"), Required(ErrorMessage="Fecha Obligatoria.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaCompra { get; set; }

        //Pide
        public virtual Vehiculo Vehiculo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}