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
    public class ComunicadosController : Controller
    {
        private SqlModel db = new SqlModel();

        // GET: Comunicados
        public ActionResult Index()
        {
            return View(db.T_Comunicados.ToList());
        }

        // GET: Comunicados/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Comunicados t_Comunicados = db.T_Comunicados.Find(id);
            if (t_Comunicados == null)
            {
                return HttpNotFound();
            }
            return View(t_Comunicados);
        }

        // GET: Comunicados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comunicados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Comunicado,Fecha_Alta,Fecha_Inicio,Fecha_Fin,Ruta_Imagen")] T_Comunicados t_Comunicados)
        {
            if (ModelState.IsValid)
            {
                db.T_Comunicados.Add(t_Comunicados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Comunicados);
        }

        // GET: Comunicados/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Comunicados t_Comunicados = db.T_Comunicados.Find(id);
            if (t_Comunicados == null)
            {
                return HttpNotFound();
            }
            return View(t_Comunicados);
        }

        // POST: Comunicados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Comunicado,Fecha_Alta,Fecha_Inicio,Fecha_Fin,Ruta_Imagen")] T_Comunicados t_Comunicados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Comunicados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Comunicados);
        }

        // GET: Comunicados/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Comunicados t_Comunicados = db.T_Comunicados.Find(id);
            if (t_Comunicados == null)
            {
                return HttpNotFound();
            }
            return View(t_Comunicados);
        }

        // POST: Comunicados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            T_Comunicados t_Comunicados = db.T_Comunicados.Find(id);
            db.T_Comunicados.Remove(t_Comunicados);
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
