using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Procedimientos = Iteracciones.IteraccionBD.ObtenerProcedimientos();
            ViewBag.DescPuestos = Iteracciones.IteraccionBD.ObtenerDescPuesto();
            ViewBag.Boletin = Iteracciones.IteraccionBD.ObtenerBoletin();
            ViewBag.DocExt = Iteracciones.IteraccionBD.ObtenerDocExtr();
            ViewBag.ObjTac = Iteracciones.IteraccionBD.ObtenerObjTac();
            ViewBag.RegyPoli = Iteracciones.IteraccionBD.ObtenerRegyPoli();
            ViewBag.StatusHa = Iteracciones.IteraccionBD.ObtenerStatusHa();
            ViewBag.Manuales = Iteracciones.IteraccionBD.ObtenerManuales();
            ViewBag.Organigrama = Iteracciones.IteraccionBD.ObtenerOrganigrama();
            ViewBag.PoliObj = Iteracciones.IteraccionBD.ObtenerPoliObj();
            ViewBag.Proc = Iteracciones.IteraccionBD.ObtenerProc();
            ViewBag.Inst = Iteracciones.IteraccionBD.ObtenerInst();
            ViewBag.ForReg = Iteracciones.IteraccionBD.ObtenerForReg();
            ViewBag.Manual = Iteracciones.IteraccionBD.ObtenerManual();
            return View();
        }
    }
}