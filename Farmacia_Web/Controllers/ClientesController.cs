using Farmacia_Web.Core.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farmacia_Web.Controllers
{
    public class ClientesController : Controller
    {
        //Vista que se muestra al precionar el menu clientes
        public ActionResult Index()
        {
            //Consultamos a la base de datos la lista de clientes almacenados en estatus true
            var Clientes = new ClientesBussiness().Consulta().Lista_Resultado;
            return View("Guardar", Clientes);
        }
        /// <summary>
        /// Vista que se muestra al presionar nuevo cliente
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Guardar()
        {
            return View("Index");
        }
        /// <summary>
        /// Vista que guarda al nuevo cliente en base de datos y redirige a la lista de clientes
        /// </summary>
        /// <param name="_cliente"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Guardar(CLIENTE _cliente)
        {
            List<CLIENTE> Clientes = new List<CLIENTE>();
            if (ModelState.IsValid)
            {
                var Resultado = new ClientesBussiness().Guardar(_cliente);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Modificar(int id)
        {
            var Resultado = new ClientesBussiness().Consulta(id);
            return View(Resultado.Resultado);
        }
        [HttpPost]
        public ActionResult Modificar(CLIENTE _cliente)
        {
            var Resultado = new ClientesBussiness().Modificar(_cliente);
            if (Resultado.Error)
            {
                ModelState.AddModelError("Error", Resultado.Mensaje);
                return View("Modificar");
            }
            else
            {
                return View(Resultado.Resultado);
            }
        }
        [HttpGet]
        public ActionResult Eliminar(int ClienteId)
        {
            var Resultado = new ClientesBussiness().Eliminar(ClienteId);
            return RedirectToAction("Index");
        }

    }
}