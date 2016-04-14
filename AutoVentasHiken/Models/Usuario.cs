using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AutoVentasHiken.Models
{
    public class Usuario
    {
        [Key]
        public int id_Usuario { get; set; }
        [Display(Name = "Nombre Completo"), Required(ErrorMessage = "Ingrese el nombre.")]
        public String nombre { get; set; }
        [Display(Name = "Correo"), Required(ErrorMessage = "Ingrese su Correo"), DataType(DataType.EmailAddress)]
        public String correo { get; set; }
        [Display(Name = "Telefono"), Required(ErrorMessage = "Ingrese su numero"), DataType(DataType.PhoneNumber)]
        public int telefono { get; set; }
        [Display(Name = "Direccion"), Required(ErrorMessage = "Ingrese su numero"), DataType(DataType.PhoneNumber)]
        public String direccion { get; set; }
        [Display(Name = "Contrasena"), Required(ErrorMessage = "Ingrese su Contrasena"), DataType(DataType.Password)]
        public String contrasena { get; set; }
        [Display(Name = "Comparar Contrasena"), Required(ErrorMessage = "Contrasena Obligatoria"), DataType(DataType.Password)]
        [Compare("contrasena", ErrorMessage = "Las contrasenas no coinciden.")]
        public String compararContraseña { get; set; }
        [Display(Name = "Rol")]
        public int? id_Rol { get; set; }
        //Da
        public virtual List<Compra> compras { get; set; }
        public virtual List<Archivo> archivos { get; set; }
        //Pide
        public virtual Rol rol { get; set; }
    }
}