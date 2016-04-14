using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace AutoVentasHiken.Models
{
    public partial class DB_AutoHiken:DbContext
    {
        public DB_AutoHiken() : base("name=DB_AutoHiken") { }
        public virtual DbSet<Rol> rol { get; set; }
        public virtual DbSet<Archivo> archivo { get; set; }
        public virtual DbSet<Combustible> combustible { get; set; }
        public virtual DbSet<Compra> compra { get; set; }
        public virtual DbSet<Marca> marca { get; set; }
        public virtual DbSet<StockVehiculo> stockVehiculo { get; set; }
        public virtual DbSet<TipoVehiculo> tipoVehiculo { get; set; }
        public virtual DbSet<Usuario> usuario { get; set; }
        public virtual DbSet<Vehiculo> vehiculo { get; set; }

    }
}