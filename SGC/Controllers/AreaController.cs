using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SGC.Models;

namespace SGC.Controllers
{
    public class AreaController : Controller
    {
        private SqlModel db = new SqlModel();

        // GET: Area
        public ActionResult Index()
        {
            return View(db.T_Area.ToList());
        }

        // GET: Area/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Area t_Area = db.T_Area.Find(id);
            if (t_Area == null)
            {
                return HttpNotFound();
            }
            return View(t_Area);
        }

        // GET: Area/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Area/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Area,Nombre,Clave_Area,Descripcion")] T_Area t_Area)
        {
            if (ModelState.IsValid)
            {
                db.T_Area.Add(t_Area);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Area);
        }

        // GET: Area/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Area t_Area = db.T_Area.Find(id);
            if (t_Area == null)
            {
                return HttpNotFound();
            }
            return View(t_Area);
        }

        // POST: Area/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Area,Nombre,Clave_Area,Descripcion")] T_Area t_Area)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Area).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Area);
        }

        // GET: Area/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Area t_Area = db.T_Area.Find(id);
            if (t_Area == null)
            {
                return HttpNotFound();
            }
            return View(t_Area);
        }

        // POST: Area/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Area t_Area = db.T_Area.Find(id);
            db.T_Area.Remove(t_Area);
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
