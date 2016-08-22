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
    public class DocumentosController : Controller
    {
        private SqlModel db = new SqlModel();

        // GET: Documentos
        public ActionResult Index()
        {
            var t_Documentos = db.T_Documentos.Include(t => t.T_Area).Include(t => t.T_Departamento);
            return View(t_Documentos.ToList());
        }

        // GET: Documentos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Documentos t_Documentos = db.T_Documentos.Find(id);
            if (t_Documentos == null)
            {
                return HttpNotFound();
            }
            return View(t_Documentos);
        }

        // GET: Documentos/Create
        public ActionResult Create()
        {
            ViewBag.ID_Area = new SelectList(db.T_Area, "ID_Area", "Nombre");
            ViewBag.ID_Depart = new SelectList(db.T_Departamento, "ID_Depart", "Nombre");
            return View();
        }

        // POST: Documentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Doc,Nombre,Codificacion,CodAdicional,NoRevision,ID_Status,ID_TipoDoc,ID_Area,ID_Depart,Descripcion,Fecha_Alta,LinkWeb,Ruta_Archivo,CodificacionCalc")] T_Documentos t_Documentos)
        {
            if (ModelState.IsValid)
            {
                db.T_Documentos.Add(t_Documentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Area = new SelectList(db.T_Area, "ID_Area", "Nombre", t_Documentos.ID_Area);
            ViewBag.ID_Depart = new SelectList(db.T_Departamento, "ID_Depart", "Nombre", t_Documentos.ID_Depart);
            return View(t_Documentos);
        }

        // GET: Documentos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Documentos t_Documentos = db.T_Documentos.Find(id);
            if (t_Documentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Area = new SelectList(db.T_Area, "ID_Area", "Nombre", t_Documentos.ID_Area);
            ViewBag.ID_Depart = new SelectList(db.T_Departamento, "ID_Depart", "Nombre", t_Documentos.ID_Depart);
            return View(t_Documentos);
        }

        // POST: Documentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Doc,Nombre,Codificacion,CodAdicional,NoRevision,ID_Status,ID_TipoDoc,ID_Area,ID_Depart,Descripcion,Fecha_Alta,LinkWeb,Ruta_Archivo,CodificacionCalc")] T_Documentos t_Documentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Documentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Area = new SelectList(db.T_Area, "ID_Area", "Nombre", t_Documentos.ID_Area);
            ViewBag.ID_Depart = new SelectList(db.T_Departamento, "ID_Depart", "Nombre", t_Documentos.ID_Depart);
            return View(t_Documentos);
        }

        // GET: Documentos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Documentos t_Documentos = db.T_Documentos.Find(id);
            if (t_Documentos == null)
            {
                return HttpNotFound();
            }
            return View(t_Documentos);
        }

        // POST: Documentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            T_Documentos t_Documentos = db.T_Documentos.Find(id);
            db.T_Documentos.Remove(t_Documentos);
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
