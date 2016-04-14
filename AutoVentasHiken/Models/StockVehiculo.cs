using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AutoVentasHiken.Models
{
    public class StockVehiculo
    {
        [Key]
        public int id_StockVehiculo { get; set; }
        //ID el cual analiza
        
        //Es alrevez
        //Simon eso me habian dicho hace mucho esque me confundi :(
        //Va arreglalo y te ayudo mas tarede o otro dia si queres 
        //Si queres mñn y ahorita ya con eso me ayudaste un monton chus buena onda vivo (Y) jajajaja

        [Display(Name = "Modelo")]
        public string modelo { get; set; }

        [Display(Name = "Disponible")]
        public string disponible { get; set; }

        //Da
        
        //Pide
        public virtual List<Vehiculo> Vehiculos { get; set; }
    }
}