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
    public class CompraController : Controller
    {
        private DB_AutoHiken db = new DB_AutoHiken();

        // GET: /Compra/
        public ActionResult Index()
        {
            var compra = db.compra.Include(c => c.Usuario).Include(c => c.Vehiculo);
            return View(compra.ToList());
        }

        // GET: /Compra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: /Compra/Create
        public ActionResult Create()
        {
            ViewBag.id_Usuario = new SelectList(db.usuario, "id_Usuario", "nombre");
            ViewBag.id_Vehiculo = new SelectList(db.vehiculo, "id_Vehiculo", "nombre");
            return View();
        }

        // POST: /Compra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_Compra,id_Vehiculo,id_Usuario,fechaCompra")] Compra compra)
        {
            DateTime date = DateTime.Now;
            compra.fechaCompra = date;
            compra.id_Usuario = CuentaController.AlmacenarId;
            compra.Usuario = db.usuario.FirstOrDefault(u => u.id_Usuario == CuentaController.AlmacenarId);
            if (ModelState.IsValid)
            {
                db.compra.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Usuario = new SelectList(db.usuario, "id_Usuario", "nombre", compra.id_Usuario);
            ViewBag.id_Vehiculo = new SelectList(db.vehiculo, "id_Vehiculo", "nombre", compra.id_Vehiculo);
            return View(compra);
        }

        // GET: /Compra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Usuario = new SelectList(db.usuario, "id_Usuario", "nombre", compra.id_Usuario);
            ViewBag.id_Vehiculo = new SelectList(db.vehiculo, "id_Vehiculo", "nombre", compra.id_Vehiculo);
            return View(compra);
        }

        // POST: /Compra/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_Compra,id_Vehiculo,id_Usuario,fechaCompra")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Usuario = new SelectList(db.usuario, "id_Usuario", "nombre", compra.id_Usuario);
            ViewBag.id_Vehiculo = new SelectList(db.vehiculo, "id_Vehiculo", "nombre", compra.id_Vehiculo);
            return View(compra);
        }

        // GET: /Compra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: /Compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra compra = db.compra.Find(id);
            db.compra.Remove(compra);
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
