using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoVentasHiken.Models;

namespace AutoVentasHiken.Controllers
{
    public class VehiculoController : Controller
    {
        private DB_AutoHiken db = new DB_AutoHiken();

        // GET: /Vehiculo/
        public ActionResult Index()
        {
            var vehiculo = db.vehiculo.Include(v => v.combustible).Include(v => v.marca).Include(v => v.Stockvehiculo).Include(v => v.tipoVehiculo);
            return View(vehiculo.ToList());
        }

        // GET: /Vehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // GET: /Vehiculo/Create
        public ActionResult Create()
        {
            ViewBag.id_Combustible = new SelectList(db.combustible, "id_Combustible", "nombre");
            ViewBag.id_Marca = new SelectList(db.marca, "id_Marca", "nombre");
            ViewBag.id_StockVehiculo = new SelectList(db.stockVehiculo, "id_StockVehiculo", "disponible");
            ViewBag.id_TipoVehiculo = new SelectList(db.tipoVehiculo, "id_TipoVehiculo", "nombre");
            return View();
        }

        // POST: /Vehiculo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_Vehiculo,nombre,precio,descripcion,cantidad,id_Combustible,id_Marca,id_TipoVehiculo,id_StockVehiculo")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.vehiculo.Add(vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Combustible = new SelectList(db.combustible, "id_Combustible", "nombre", vehiculo.id_Combustible);
            ViewBag.id_Marca = new SelectList(db.marca, "id_Marca", "nombre", vehiculo.id_Marca);
            ViewBag.id_StockVehiculo = new SelectList(db.stockVehiculo, "id_StockVehiculo", "disponible", vehiculo.id_StockVehiculo);
            ViewBag.id_TipoVehiculo = new SelectList(db.tipoVehiculo, "id_TipoVehiculo", "nombre", vehiculo.id_TipoVehiculo);
            return View(vehiculo);
        }

        // GET: /Vehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Combustible = new SelectList(db.combustible, "id_Combustible", "nombre", vehiculo.id_Combustible);
            ViewBag.id_Marca = new SelectList(db.marca, "id_Marca", "nombre", vehiculo.id_Marca);
            ViewBag.id_StockVehiculo = new SelectList(db.stockVehiculo, "id_StockVehiculo", "disponible", vehiculo.id_StockVehiculo);
            ViewBag.id_TipoVehiculo = new SelectList(db.tipoVehiculo, "id_TipoVehiculo", "nombre", vehiculo.id_TipoVehiculo);
            return View(vehiculo);
        }

        // POST: /Vehiculo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_Vehiculo,nombre,precio,descripcion,cantidad,id_Combustible,id_Marca,id_TipoVehiculo,id_StockVehiculo")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Combustible = new SelectList(db.combustible, "id_Combustible", "nombre", vehiculo.id_Combustible);
            ViewBag.id_Marca = new SelectList(db.marca, "id_Marca", "nombre", vehiculo.id_Marca);
            ViewBag.id_StockVehiculo = new SelectList(db.stockVehiculo, "id_StockVehiculo", "modelo", vehiculo.id_StockVehiculo);
            ViewBag.id_TipoVehiculo = new SelectList(db.tipoVehiculo, "id_TipoVehiculo", "nombre", vehiculo.id_TipoVehiculo);
            return View(vehiculo);
        }

        // GET: /Vehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: /Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehiculo vehiculo = db.vehiculo.Find(id);
            db.vehiculo.Remove(vehiculo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
