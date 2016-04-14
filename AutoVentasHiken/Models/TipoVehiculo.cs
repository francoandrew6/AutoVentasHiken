using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AutoVentasHiken.Models
{
    public class TipoVehiculo
    {
        [Key]
        public int id_TipoVehiculo { get; set; }
        
        [Display(Name = "Nombre")]
        public String nombre { get; set; }

        [Display(Name = "Descripcion")]
        public String descripcion { get; set; }

        //Da
        public virtual List<Vehiculo> vehiculos { get; set; }
    }
}