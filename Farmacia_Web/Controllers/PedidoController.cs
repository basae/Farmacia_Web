using Farmacia_Web.Core.Clientes;
using Farmacia_Web.Core.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farmacia_Web.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            var Pedidos = new PedidosBussiness().Consulta().Lista_Resultado.ToList();
            return View(Pedidos);
        }
        public ActionResult Create()
        {
            ViewBag.Clientes = new ClientesBussiness().Consulta().Lista_Resultado.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = string.Format("{0}-{1}", x.Id.ToString(), string.Join(" ", x.Nombre, x.APaterno, x.AMaterno)) });
            return View();
        }
        [HttpPost]
        public JsonResult Create(PEDIDO _Pedido)
        {
            var resultrequest = new PedidosBussiness().Guardar(_Pedido);

            return Json(resultrequest, JsonRequestBehavior.AllowGet);
        }
    }
}