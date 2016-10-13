using System;
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
        private SQLModel db = new SQLModel();

        // GET: Documentos
        public ActionResult Index()
        {
            var t_Documentos = db.T_Documentos.Include(t => t.T_Area).Include(t => t.T_Departamento).Include(t => t.T_Status).Include(t => t.T_Tipo_Documento);
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
            ViewBag.ID_Status = new SelectList(db.T_Status, "ID_Status", "Nombre");
            ViewBag.ID_TipoDoc = new SelectList(db.T_Tipo_Documento, "ID_TipoDoc", "Nombre");
            return View();
        }

        // POST: Documentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, [Bind(Include = "ID_Doc,Nombre,Codificacion,PriCodAdi,SegCodAdi,NoRevision,ID_Status,ID_TipoDoc,ID_Area,ID_Depart,Descripcion,Fecha_Alta,LinkWeb,Ruta_Archivo,CodificacionCalc")] T_Documentos t_Documentos)
        {
            if (file != null)
            {
                string archivo = (file.FileName).ToLower();

                file.SaveAs(Server.MapPath("~/Archivos/" + archivo));
                t_Documentos.Ruta_Archivo = archivo;
                t_Documentos.Fecha_Alta = DateTime.Now;
                if (t_Documentos.Codificacion != null && t_Documentos.Nombre != null && t_Documentos.NoRevision >= 0)
                {
                    db.T_Documentos.Add(t_Documentos);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    if (ModelState.IsValid)
                        ;
                }
            }
            else
                return View();


            ViewBag.ID_Area = new SelectList(db.T_Area, "ID_Area", "Nombre", t_Documentos.ID_Area);
            ViewBag.ID_Depart = new SelectList(db.T_Departamento, "ID_Depart", "Nombre", t_Documentos.ID_Depart);
            ViewBag.ID_Status = new SelectList(db.T_Status, "ID_Status", "Nombre", t_Documentos.ID_Status);
            ViewBag.ID_TipoDoc = new SelectList(db.T_Tipo_Documento, "ID_TipoDoc", "Nombre", t_Documentos.ID_TipoDoc);
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
            ViewBag.ID_Status = new SelectList(db.T_Status, "ID_Status", "Nombre", t_Documentos.ID_Status);
            ViewBag.ID_TipoDoc = new SelectList(db.T_Tipo_Documento, "ID_TipoDoc", "Nombre", t_Documentos.ID_TipoDoc);
            return View(t_Documentos);
        }

        // POST: Documentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Doc,Nombre,Codificacion,PriCodAdi,SegCodAdi,NoRevision,ID_Status,ID_TipoDoc,ID_Area,ID_Depart,Descripcion,Fecha_Alta,LinkWeb,Ruta_Archivo,CodificacionCalc")] T_Documentos t_Documentos)
        {
            db.Entry(t_Documentos).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            ViewBag.ID_Area = new SelectList(db.T_Area, "ID_Area", "Nombre", t_Documentos.ID_Area);
            ViewBag.ID_Depart = new SelectList(db.T_Departamento, "ID_Depart", "Nombre", t_Documentos.ID_Depart);
            ViewBag.ID_Status = new SelectList(db.T_Status, "ID_Status", "Nombre", t_Documentos.ID_Status);
            ViewBag.ID_TipoDoc = new SelectList(db.T_Tipo_Documento, "ID_TipoDoc", "Nombre", t_Documentos.ID_TipoDoc);
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
        [HttpPost]
        public ActionResult Subir(HttpPostedFileBase file, [Bind(Include = "ID_Doc,Nombre,Codificacion,PriCodAdi,SegCodAdi,NoRevision,ID_Status,ID_TipoDoc,ID_Area,ID_Depart,Descripcion,Fecha_Alta,LinkWeb,Ruta_Archivo,CodificacionCalc")] T_Documentos t_Documentos)
        {
            if (file != null)
            {
                string archivo = (file.FileName).ToLower();

                file.SaveAs(Server.MapPath("~/Archivos/" + archivo));
                t_Documentos.Ruta_Archivo = archivo;
                t_Documentos.Fecha_Alta = DateTime.Now;
                Iteracciones.IteraccionBD.UpdateArchivo(t_Documentos);
                return RedirectToAction("Index");
            }
            else
                return View();
        }
    }
}
