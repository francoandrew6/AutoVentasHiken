using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoVentasHiken.Models;
namespace AutoVentasHiken.Controllers
{
    public class ArchivoController : Controller
    {
        public DB_AutoHiken db = new DB_AutoHiken();
        //
        // GET: /Archivo/
        public ActionResult ObtenerArchivo(int id)
        {
            var imagen = db.archivo.Find(id);
            return File(imagen.contenido,imagen.contentType);
        }
	}
}