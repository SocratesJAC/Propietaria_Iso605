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
    public class EmpleadosController : Controller
    {
        private EGSHOPEntities db = new EGSHOPEntities();

        // GET: Empleados
        public ActionResult Index()
        {
            //var empleados = db.Empleados.Include(e => e.Departamento).Include(e => e.Puesto);
           // return View(empleados.ToList());
           return View();
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.IDdepartamento = new SelectList(db.Departamento, "IDdepartamento", "Cargo");
            ViewBag.IDPuesto = new SelectList(db.Puesto, "IDpuesto", "Nombre");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDempleados,Nombre,Cedula,IDdepartamento,IDPuesto,SalarioMensual,IDnomina,Estado")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDdepartamento = new SelectList(db.Departamento, "IDdepartamento", "Cargo", empleados.IDdepartamento);
            ViewBag.IDPuesto = new SelectList(db.Puesto, "IDpuesto", "Nombre", empleados.IDPuesto);
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDdepartamento = new SelectList(db.Departamento, "IDdepartamento", "Cargo", empleados.IDdepartamento);
            ViewBag.IDPuesto = new SelectList(db.Puesto, "IDpuesto", "Nombre", empleados.IDPuesto);
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDempleados,Nombre,Cedula,IDdepartamento,IDPuesto,SalarioMensual,IDnomina,Estado")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDdepartamento = new SelectList(db.Departamento, "IDdepartamento", "Cargo", empleados.IDdepartamento);
            ViewBag.IDPuesto = new SelectList(db.Puesto, "IDpuesto", "Nombre", empleados.IDPuesto);
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleados empleados = db.Empleados.Find(id);
            db.Empleados.Remove(empleados);
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
