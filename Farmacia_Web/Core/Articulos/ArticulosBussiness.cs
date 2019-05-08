using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Farmacia_Web.Models;
using Farmacia_Web.Core.Interfaces;

namespace Farmacia_Web.Core.Productos
{
    public class ArticulosBussiness : ICoreBussiness<ARTICULO>
    {
        public RespuestaServicio<ARTICULO> Consulta()
        {
            RespuestaServicio<ARTICULO> respuesta = new RespuestaServicio<ARTICULO>();
            try
            {
                using (var bd = new FarmaciaEntities())
                {
                    respuesta.Lista_Resultado = bd.ARTICULO.ToList();
                }
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        public RespuestaServicio<ARTICULO> Consulta(int Id)
        {
            RespuestaServicio<ARTICULO> respuesta = new RespuestaServicio<ARTICULO>();
            try
            {
                using (var bd = new FarmaciaEntities())
                {
                    respuesta.Resultado = bd.ARTICULO.Find(Id);
                }
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        public RespuestaServicio<ARTICULO> Eliminar(int Id)
        {
            RespuestaServicio<ARTICULO> respuesta = new RespuestaServicio<ARTICULO>();
            try
            {
                if (Id <= 0)
                    throw new Exception("El Id es invalido");

                using (var bd = new FarmaciaEntities())
                {
                    var _articulo = bd.ARTICULO.Find(Id);
                    _articulo.Estatus = false;
                    _articulo.Fecha_Modificacion = DateTime.Now;
                    bd.Entry(_articulo).State = System.Data.Entity.EntityState.Modified;
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

        public RespuestaServicio<ARTICULO> Guardar(ARTICULO _item)
        {
            RespuestaServicio<ARTICULO> respuesta = new RespuestaServicio<ARTICULO>();
            try
            {
                using (var bd = new FarmaciaEntities())
                {
                    _item.Estatus = true;
                    _item.Fecha_Creacion = DateTime.Now;
                    bd.ARTICULO.Add(_item);
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

        public RespuestaServicio<ARTICULO> Modificar(ARTICULO _item)
        {
            RespuestaServicio<ARTICULO> respuesta = new RespuestaServicio<ARTICULO>();
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