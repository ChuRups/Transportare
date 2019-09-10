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

        public ActionResult Details(int? id)
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

        public ActionResult Create()
        {
            try
            {
                using (var db = new TransportareContext())
                {
                    ViewBag.SexoDes = new SelectList(db.TablaGeneral.Where(tg => tg.Grupo == 1).ToList(), "IdTablaGeneral", "Descripcion");
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
        public ActionResult Create(Mensajero m)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new TransportareContext())
                {
                    m.FechaIngreso = DateTime.Now;
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

        // GET: Mensajero/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensajero mensajero = db.Mensajero.Find(id);
            if (mensajero == null)
            {
                return HttpNotFound();
            }
            return View(mensajero);
        }

        // POST: Mensajero/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMensajero,Nombre,Apellidos,Documento,Direccion,FechaIngreso,estado")] Mensajero mensajero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mensajero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mensajero);
        }

        // GET: Mensajero/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensajero mensajero = db.Mensajero.Find(id);
            if (mensajero == null)
            {
                return HttpNotFound();
            }
            return View(mensajero);
        }

        // POST: Mensajero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mensajero mensajero = db.Mensajero.Find(id);
            db.Mensajero.Remove(mensajero);
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
