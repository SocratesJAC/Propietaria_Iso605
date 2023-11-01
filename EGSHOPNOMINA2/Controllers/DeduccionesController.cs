using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EGSHOPNOMINA2.Controllers
{
    public class DeduccionesController : Controller
    {
        // GET: Deducciones
        public ActionResult Index()
        {
            return View();
        }

        // GET: Deducciones/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Deducciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deducciones/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Deducciones/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Deducciones/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Deducciones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Deducciones/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
