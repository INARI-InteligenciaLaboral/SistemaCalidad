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
    public class DepartamentoController : Controller
    {
        private SqlModel db = new SqlModel();

        // GET: Departamento
        public ActionResult Index()
        {
            return View(db.T_Departamento.ToList());
        }

        // GET: Departamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Departamento t_Departamento = db.T_Departamento.Find(id);
            if (t_Departamento == null)
            {
                return HttpNotFound();
            }
            return View(t_Departamento);
        }

        // GET: Departamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Depart,Nombre,Clave_Depart,Descripcion")] T_Departamento t_Departamento)
        {
            if (ModelState.IsValid)
            {
                db.T_Departamento.Add(t_Departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Departamento);
        }

        // GET: Departamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Departamento t_Departamento = db.T_Departamento.Find(id);
            if (t_Departamento == null)
            {
                return HttpNotFound();
            }
            return View(t_Departamento);
        }

        // POST: Departamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Depart,Nombre,Clave_Depart,Descripcion")] T_Departamento t_Departamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Departamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Departamento);
        }

        // GET: Departamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Departamento t_Departamento = db.T_Departamento.Find(id);
            if (t_Departamento == null)
            {
                return HttpNotFound();
            }
            return View(t_Departamento);
        }

        // POST: Departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Departamento t_Departamento = db.T_Departamento.Find(id);
            db.T_Departamento.Remove(t_Departamento);
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
