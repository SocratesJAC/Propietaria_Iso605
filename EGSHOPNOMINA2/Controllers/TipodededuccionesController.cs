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
    public class TipodededuccionesController : Controller
    {
        private EGSHOPEntities db = new EGSHOPEntities();

        // GET: Tipodededucciones
        public ActionResult Index()
        {
            //return View(db.Tipodededucciones.ToList());
            return View();
        }

        // GET: Tipodededucciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipodededucciones tipodededucciones = db.Tipodededucciones.Find(id);
            if (tipodededucciones == null)
            {
                return HttpNotFound();
            }
            return View(tipodededucciones);
        }

        // GET: Tipodededucciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipodededucciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDtipodededucciones,Nombre,Dependeelsalario,Estado")] Tipodededucciones tipodededucciones)
        {
            if (ModelState.IsValid)
            {
                db.Tipodededucciones.Add(tipodededucciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipodededucciones);
        }

        // GET: Tipodededucciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipodededucciones tipodededucciones = db.Tipodededucciones.Find(id);
            if (tipodededucciones == null)
            {
                return HttpNotFound();
            }
            return View(tipodededucciones);
        }

        // POST: Tipodededucciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDtipodededucciones,Nombre,Dependeelsalario,Estado")] Tipodededucciones tipodededucciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipodededucciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipodededucciones);
        }

        // GET: Tipodededucciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipodededucciones tipodededucciones = db.Tipodededucciones.Find(id);
            if (tipodededucciones == null)
            {
                return HttpNotFound();
            }
            return View(tipodededucciones);
        }

        // POST: Tipodededucciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipodededucciones tipodededucciones = db.Tipodededucciones.Find(id);
            db.Tipodededucciones.Remove(tipodededucciones);
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
