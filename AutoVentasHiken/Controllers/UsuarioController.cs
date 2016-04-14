using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoVentasHiken.Models;
using System.Data.Entity.Infrastructure;

namespace AutoVentasHiken.Controllers
{
    public class UsuarioController : Controller
    {
        private DB_AutoHiken db = new DB_AutoHiken();

        // GET: /Usuario/
        public ActionResult Index()
        {
            var usuario = db.usuario.Include(u => u.rol);
            return View(usuario.ToList());
        }
        public ActionResult Icono()
        {
            var usuario = db.usuario.Include(u => u.rol);
            return View(usuario.ToList());
        }

        // GET: /Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: /Usuario/Create
        public ActionResult Create()
        {
            ViewBag.id_Rol = new SelectList(db.rol, "id_Rol", "nombre");
            return View();
        }

        // POST: /Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Usuario,nombre,correo,telefono,direccion,contrasena,compararContraseña,id_Rol")] Usuario usuario, HttpPostedFileBase archivo)
        {
            if (ModelState.IsValid)
            {
                if (archivo != null && archivo.ContentLength > 0)
                {
                    var imagen = new Archivo
                    {
                        nombre = System.IO.Path.GetFileName(archivo.FileName),
                        tipo = FileType.Imagen,
                        contentType = archivo.ContentType,
                    };
                    using (var reader = new System.IO.BinaryReader(archivo.InputStream))
                    {
                        imagen.contenido = reader.ReadBytes(archivo.ContentLength);
                    };
                    usuario.archivos = new List<Archivo> { imagen };
                }
                db.usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Rol = new SelectList(db.rol, "id_Rol", "nombre", usuario.id_Rol);
            return View(usuario);
        }

        // GET: /Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Rol = new SelectList(db.rol, "id_Rol", "nombre", usuario.id_Rol);
            return View(usuario);
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Rol = new SelectList(db.rol, "id_Rol", "nombre", usuario.id_Rol);
            return View(usuario);
        }

        // POST: /Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "id_Usuario,nombre,correo,telefono,direccion,contrasena,compararContraseña,id_Rol")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Rol = new SelectList(db.rol, "id_Rol", "nombre", usuario.id_Rol);
            return View(usuario);
        }


        //Editar Imagen
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, HttpPostedFileBase archivo)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var usuario = db.usuario.Find(id);
            if (TryUpdateModel(usuario, "", new string[] { "id_Usuario,nombre,correo,telefono,direccion,contrasena,compararContraseña,id_Rol" }))
            {
                try
                {
                    if (archivo != null && archivo.ContentLength > 0)
                    {
                        if (usuario.archivos.Any(f => f.tipo == FileType.Imagen))
                        {
                            db.archivo.Remove(usuario.archivos.First(f => f.tipo == FileType.Imagen));
                        }
                        var imagen = new Archivo
                        {
                            nombre = System.IO.Path.GetFileName(archivo.FileName),
                            tipo = FileType.Imagen,
                            contentType = archivo.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(archivo.InputStream))
                        {
                            imagen.contenido = reader.ReadBytes(archivo.ContentLength);
                        }
                        usuario.archivos = new List<Archivo> { imagen };
                    }
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }catch(RetryLimitExceededException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator");
                }
            }
            return View(usuario);
        }

        // GET: /Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: /Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.usuario.Find(id);
            db.usuario.Remove(usuario);
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
