using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AutoVentasHiken.Models
{
    public class Rol
    {
        [Key]
        public int id_Rol { get; set; }
        [Display(Name="Nombre")]
        public String nombre { get; set; }

        [Display(Name="Descripcion")]
        public String descripcion { get; set; }

        //Da
        public virtual List<Usuario> usuarios { get; set; }
    }
}