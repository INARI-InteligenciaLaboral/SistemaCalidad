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
    public class InterfazController : Controller
    {
        private SQLModel db = new SQLModel();

        // GET: Interfaz
        public ActionResult Index()
        {
            return View(db.T_Interfaz.ToList());
        }

        // GET: Interfaz/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Interfaz t_Interfaz = db.T_Interfaz.Find(id);
            if (t_Interfaz == null)
            {
                return HttpNotFound();
            }
            return View(t_Interfaz);
        }

        // GET: Interfaz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Interfaz/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Interfaz,RutaBackground,LogoInari,LogoCalidad,title,Navegacion,NavHover,NavFont,NavFontHover,Piramide,PirFont,PirHover,PirFontHover")] T_Interfaz t_Interfaz)
        {
            if (ModelState.IsValid)
            {
                db.T_Interfaz.Add(t_Interfaz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Interfaz);
        }

        // GET: Interfaz/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Interfaz t_Interfaz = db.T_Interfaz.Find(id);
            if (t_Interfaz == null)
            {
                return HttpNotFound();
            }
            return View(t_Interfaz);
        }

        // POST: Interfaz/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Interfaz,RutaBackground,LogoInari,LogoCalidad,title,Navegacion,NavHover,NavFont,NavFontHover,Piramide,PirFont,PirHover,PirFontHover")] T_Interfaz t_Interfaz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Interfaz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Interfaz);
        }

        // GET: Interfaz/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Interfaz t_Interfaz = db.T_Interfaz.Find(id);
            if (t_Interfaz == null)
            {
                return HttpNotFound();
            }
            return View(t_Interfaz);
        }

        // POST: Interfaz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Interfaz t_Interfaz = db.T_Interfaz.Find(id);
            db.T_Interfaz.Remove(t_Interfaz);
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
