using Farmacia_Web.Core.Clientes;
using Farmacia_Web.Core.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farmacia_Web.Controllers
{
    public class ArticulosController : Controller
    {
        // GET: Articulos
        public ActionResult Index()
        {
            var Articulos = new ArticulosBussiness().Consulta().Lista_Resultado;
            return View(Articulos);
        }
        [HttpGet]
        public ActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Guardar(ARTICULO _articulo)
        {
            if (ModelState.IsValid)
            {
                var Resultado = new ArticulosBussiness().Guardar(_articulo);
                if (Resultado.Error)
                {
                    ModelState.AddModelError("Error", Resultado.Mensaje);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View();

        }
        [HttpGet]
        public ActionResult Modificar(int id)
        {
            var Resultado = new ArticulosBussiness().Consulta(id);
            return View(Resultado.Resultado);
        }
        [HttpPost]
        public ActionResult Modificar(ARTICULO _articulo)
        {
            var Resultado = new ArticulosBussiness().Modificar(_articulo);
            if (Resultado.Error)
            {
                ModelState.AddModelError("Error", Resultado.Mensaje);
                return View("Modificar");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Eliminar(int Id)
        {
            var Resultado = new ArticulosBussiness().Eliminar(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Consulta(int Id)
        {
            var Artiruculo = new ArticulosBussiness().Consulta(Id);
            return View(Artiruculo.Resultado);
        }
        [HttpGet]
        public JsonResult ConsultaArticulos()
        {
            var Articulos = new ArticulosBussiness().Consulta().Lista_Resultado;
            return Json(Articulos, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ConsultaJson(int Id)
        {
            var Artiruculo = new ArticulosBussiness().Consulta(Id);
            return Json(Artiruculo.Resultado, JsonRequestBehavior.AllowGet);
        }
    }
}