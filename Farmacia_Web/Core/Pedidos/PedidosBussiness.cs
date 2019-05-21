using Farmacia_Web.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Farmacia_Web.Models;

namespace Farmacia_Web.Core.Pedidos
{
    public class PedidosBussiness : ICoreBussiness<PEDIDO>
    {
        public RespuestaServicio<PEDIDO> Consulta()
        {
            RespuestaServicio<PEDIDO> respuesta = new RespuestaServicio<PEDIDO>();
            try
            {
                using (var db = new FarmaciaEntities())
                {
                    respuesta.Lista_Resultado = db.PEDIDO.Include("CLIENTE").ToList();
                }
            }
            catch(Exception ex)
            {
                respuesta.Error = true;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        public RespuestaServicio<PEDIDO> Consulta(int Id)
        {
            RespuestaServicio<PEDIDO> respuesta = new RespuestaServicio<PEDIDO>();
            try
            {
                using (var db = new FarmaciaEntities())
                {
                    respuesta.Resultado = db.PEDIDO.Find(Id);
                }
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        public RespuestaServicio<PEDIDO> Eliminar(int Id)
        {
            RespuestaServicio<PEDIDO> respuesta = new RespuestaServicio<PEDIDO>();
            try
            {
                if (Id <= 0)
                    throw new Exception("El Id es invalido");

                using (var bd = new FarmaciaEntities())
                {
                    var _Pedido = bd.PEDIDO.Find(Id);
                    _Pedido.Estatus = false;
                    bd.Entry(_Pedido).State = System.Data.Entity.EntityState.Modified;
                    bd.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        public RespuestaServicio<PEDIDO> Guardar(PEDIDO _item)
        {
            RespuestaServicio<PEDIDO> respuesta = new RespuestaServicio<PEDIDO>();
            try
            {
                if (_item.Id_Cliente < 1)
                    throw new Exception("Cliente Invalido");                
                if (_item.PEDIDO_DETALLE.Count() < 1)
                    throw new Exception("Almenos debe contener un articulo");
                using (var bd = new FarmaciaEntities())
                {
                    _item.Estatus = true;
                    _item.Fecha_Pedido = DateTime.Now;
                    _item.Fecha_Creacion = DateTime.Now;
                    bd.PEDIDO.Add(_item);
                    bd.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        public RespuestaServicio<PEDIDO> Modificar(PEDIDO _item)
        {
            RespuestaServicio<PEDIDO> respuesta = new RespuestaServicio<PEDIDO>();
            try
            {
                if (_item.Id <= 0)
                    throw new Exception("El Id es invalido");

                using (var bd = new FarmaciaEntities())
                {
                    _item.Fecha_Modificacion = DateTime.Now;
                    bd.Entry(_item).State = System.Data.Entity.EntityState.Modified;
                    bd.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }
    }
}