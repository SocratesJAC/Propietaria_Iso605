using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EGSHOPNOMINA2;

namespace EGSHOPNOMINA2.Controllers
{
    public class TransaccionesController : Controller
    {
        private EGSHOPEntities db = new EGSHOPEntities();

        // GET: Transacciones
        public ActionResult Index()
        {
            var transacciones = db.Transacciones.Include(t => t.Empleados).Include(t => t.Tipodededucciones).Include(t => t.Tiposdeingresos);
            return View(transacciones.ToList());
        }

        // GET: Transacciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones transacciones = db.Transacciones.Find(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            return View(transacciones);
        }

        // GET: Transacciones/Create
        public ActionResult Create()
        {
            ViewBag.IDempleados = new SelectList(db.Empleados, "IDempleados", "Nombre");
            ViewBag.IDtipodeducciones = new SelectList(db.Tipodededucciones, "IDtipodededucciones", "Nombre");
            ViewBag.IDtiposdeingresos = new SelectList(db.Tiposdeingresos, "IDtiposdeingresos", "Nombre");
            return View();
        }

        // POST: Transacciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDtransacciones,IDempleados,Idingresoodeduccion,IDtipodeducciones,IDtiposdeingresos,Fecha,Monto,Estado")] Transacciones transacciones)
        {
            if (ModelState.IsValid)
            {
                db.Transacciones.Add(transacciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDempleados = new SelectList(db.Empleados, "IDempleados", "Nombre", transacciones.IDempleados);
            ViewBag.IDtipodeducciones = new SelectList(db.Tipodededucciones, "IDtipodededucciones", "Nombre", transacciones.IDtipodeducciones);
            ViewBag.IDtiposdeingresos = new SelectList(db.Tiposdeingresos, "IDtiposdeingresos", "Nombre", transacciones.IDtiposdeingresos);
            return View(transacciones);
        }

        // GET: Transacciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones transacciones = db.Transacciones.Find(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDempleados = new SelectList(db.Empleados, "IDempleados", "Nombre", transacciones.IDempleados);
            ViewBag.IDtipodeducciones = new SelectList(db.Tipodededucciones, "IDtipodededucciones", "Nombre", transacciones.IDtipodeducciones);
            ViewBag.IDtiposdeingresos = new SelectList(db.Tiposdeingresos, "IDtiposdeingresos", "Nombre", transacciones.IDtiposdeingresos);
            return View(transacciones);
        }

        // POST: Transacciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDtransacciones,IDempleados,Idingresoodeduccion,IDtipodeducciones,IDtiposdeingresos,Fecha,Monto,Estado")] Transacciones transacciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transacciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDempleados = new SelectList(db.Empleados, "IDempleados", "Nombre", transacciones.IDempleados);
            ViewBag.IDtipodeducciones = new SelectList(db.Tipodededucciones, "IDtipodededucciones", "Nombre", transacciones.IDtipodeducciones);
            ViewBag.IDtiposdeingresos = new SelectList(db.Tiposdeingresos, "IDtiposdeingresos", "Nombre", transacciones.IDtiposdeingresos);
            return View(transacciones);
        }

        // GET: Transacciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones transacciones = db.Transacciones.Find(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            return View(transacciones);
        }

        // POST: Transacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transacciones transacciones = db.Transacciones.Find(id);
            db.Transacciones.Remove(transacciones);
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
