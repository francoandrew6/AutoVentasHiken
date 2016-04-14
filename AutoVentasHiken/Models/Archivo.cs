using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AutoVentasHiken.Models
{
    public class Archivo
    {
        [Key]
        public int id_Archivo { get; set; }
        public String nombre { get; set; }
        public String contentType { get; set; }
        public FileType tipo { get; set; }
        public byte[] contenido { get; set; }

        public int? id_Vehiculo { get; set; }
        public virtual Vehiculo vehiculos { get; set; }
        public int? id_Usuario{ get; set; }
        public virtual Usuario usuarios { get; set; }
    }
}