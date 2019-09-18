using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Transportare.Models;

namespace Transportare.Controllers
{
    public class MensajeroController : Controller
    {
        TransportareContext db = new TransportareContext();

        public ActionResult Index()
        {
            try
            {
                using (var db = new TransportareContext())
                {
                    List<Mensajero> Lista = db.Mensajero.Where(m => m.Estado == true).ToList();
                    return View(Lista);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al listar mensajeros:" + ex.Message);
                return View();
            }
        }

        public ActionResult MensajeroDetalles(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            try
            {
                using (var db = new TransportareContext())
                {
                    Mensajero m = db.Mensajero.Find(id);
                    return View(m);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al encontrar mensajero:" + ex.Message);
                return View();
            }
        }

        public ActionResult MensajeroCrear()
        {
            try
            {
                using (var db = new TransportareContext())
                {
                    ViewBag.IdSexo = new SelectList(db.TablaGeneral.Where(tg => tg.Grupo == 1).ToList(), "IdTablaGeneral", "Descripcion");
                    ViewBag.Departamentos = new SelectList(db.Ubigeo.Where(u => u.Padre == null).ToList(), "IdUbigeo", "Descripcion");
                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al encontrar Lista de Genero:" + ex.Message);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MensajeroCrear(Mensajero m)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new TransportareContext())
                {
                    m.Estado = true;
                    db.Mensajero.Add(m);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al registrar alumno:" + ex.Message);
                return View();
            }
        }

        public ActionResult MensajeroEditar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            try
            {
                using (var db = new TransportareContext())
                {
                    Mensajero mensajero = db.Mensajero.Find(id);
                    if (mensajero == null)
                        return HttpNotFound();
                    ViewBag.TipoGenero = new SelectList(db.TablaGeneral.Where(tg => tg.Grupo == 1).ToList(), "IdTablaGeneral", "Descripcion");
                    ViewBag.Departamentos = new SelectList(db.Ubigeo.Where(u => u.Padre == null).ToList(), "IdUbigeo", "Descripcion");
                    ViewBag.xDistrito = new SelectList(db.Ubigeo.ToList(), "IdUbigeo", "Descripcion");
                    ViewBag.FechaIng = mensajero.FechaIngreso.ToShortDateString();                    
                    return View(mensajero);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MensajeroEditar(Mensajero m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new TransportareContext())
                    {
                        m.Estado = true;
                        db.Entry(m).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                return View(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public ActionResult MensajeroEliminar(int? id)
        {
            if (id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            try
            {
                using (var db = new TransportareContext())
                {
                    Mensajero mensajero = db.Mensajero.Find(id);
                    if (mensajero == null)
                        return HttpNotFound();

                    return View(mensajero);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        [HttpPost, ActionName("MensajeroEliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new TransportareContext())
            {
                Mensajero mensajero = db.Mensajero.Find(id);
                db.Mensajero.Remove(mensajero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult ListarProvincia(string IdDepartamento)
        {
            using (var db = new TransportareContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Ubigeo> ListaProvincias = db.Ubigeo.Where(x => x.Padre == IdDepartamento).ToList();
                return Json(ListaProvincias, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ListarDistrito(string IdProvincia)
        {
            using (var db = new TransportareContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Ubigeo> ListaDistrito = db.Ubigeo.Where(x => x.Padre == IdProvincia).ToList();
                return Json(ListaDistrito, JsonRequestBehavior.AllowGet);
            }
        }


    }
}
