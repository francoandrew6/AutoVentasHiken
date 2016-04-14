using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoVentasHiken.Models;
namespace AutoVentasHiken.Controllers
{
    public class CuentaController : Controller
    {
        public static int AlmacenarId;
        public DB_AutoHiken db = new DB_AutoHiken();
        //
        // GET: /Cuenta/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario, Rol rol)
        {
            var usr = db.usuario.FirstOrDefault(u=> u.correo==usuario.correo && u.contrasena==usuario.contrasena);
            //var rl = db.rol.FirstOrDefault(o=> o.nombre == rol.nombre);
            
            if (usr != null)
            {
                AlmacenarId = usr.id_Usuario;
                Session["nombreUsuario"] = usr.nombre;
                Session["idUsuario"] = usr.id_Usuario;
                Session["idRol"] = usr.id_Rol;  
                return VerificarSesion();
            }
            else
            {
                ModelState.AddModelError("", "Contraseña o Usuario incorrecto.");
            }
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            if (ModelState.IsValid) {
                Rol rol = db.rol.FirstOrDefault(r=> r.id_Rol==2);
                usuario.rol = rol;
                db.usuario.Add(usuario);
                db.SaveChanges();
                ViewBag.mensaje = "El usuario " + usuario.nombre + " fue registrado con exito.";
                ModelState.Clear();
            }
            return View();
        }

        public ActionResult VerificarSesion()
        {
            if (Session["idUsuario"] != null)
            {
                return RedirectToAction("../Home/Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("idUsuario");
            Session.Remove("nombreUsuario");
            //Session.Remove("idRol");
            return RedirectToAction("Login");
        }
	}
	}