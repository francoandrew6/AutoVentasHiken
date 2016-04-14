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
    public class TipoVehiculoController : Controller
    {
        private DB_AutoHiken db = new DB_AutoHiken();

        // GET: /TipoVehiculo/
        public ActionResult Index()
        {
            return View(db.tipoVehiculo.ToList());
        }

        // GET: /TipoVehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVehiculo tipovehiculo = db.tipoVehiculo.Find(id);
            if (tipovehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipovehiculo);
        }

        // GET: /TipoVehiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoVehiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_TipoVehiculo,nombre,descripcion")] TipoVehiculo tipovehiculo)
        {
            if (ModelState.IsValid)
            {
                db.tipoVehiculo.Add(tipovehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipovehiculo);
        }

        // GET: /TipoVehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVehiculo tipovehiculo = db.tipoVehiculo.Find(id);
            if (tipovehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipovehiculo);
        }

        // POST: /TipoVehiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_TipoVehiculo,nombre,descripcion")] TipoVehiculo tipovehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipovehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipovehiculo);
        }

        // GET: /TipoVehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVehiculo tipovehiculo = db.tipoVehiculo.Find(id);
            if (tipovehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipovehiculo);
        }

        // POST: /TipoVehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoVehiculo tipovehiculo = db.tipoVehiculo.Find(id);
            db.tipoVehiculo.Remove(tipovehiculo);
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
