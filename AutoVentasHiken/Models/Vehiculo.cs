using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AutoVentasHiken.Models
{
    public class Vehiculo
    {
        [Key]
        public int id_Vehiculo { get; set; }
        
        [Display(Name = "Nombre"), Required(ErrorMessage = "Nombre")]
        public String nombre { get; set; }
        [Display(Name = "Precio"), Required(ErrorMessage = "Precio")]
        public Decimal precio { get; set; }
        [Display(Name = "Descripcion"), DataType(DataType.Text)]
        public string descripcion { get; set; }
        [Display(Name = "Cantidad"), Required(ErrorMessage = "Ingrese la cantidad de carros que desea comprar")]
        public String cantidad { get; set; }
        //ID de los que hereda
        [Display(Name = "Tipo de Combustible")]
        public int id_Combustible { get; set; }
        [Display(Name = "Marca")]
        public int id_Marca { get; set; }
        [Display(Name = "Tipo de Vehiculo")]
        public int id_TipoVehiculo { get; set; }
        [Display(Name="Estado"), Required(ErrorMessage="Ingrese el estado")]
        public int id_StockVehiculo { get; set; }
        //Da
        public virtual List<Archivo> archivos { get; set; }
        public virtual List<Compra> compras { get; set; }
        //Pide
        public virtual StockVehiculo Stockvehiculo { get; set; }
        public virtual Combustible combustible { get; set; }
        public virtual Marca marca { get; set; }
        public virtual TipoVehiculo tipoVehiculo { get; set; } 
    }
}