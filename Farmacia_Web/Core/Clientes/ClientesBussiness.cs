using Farmacia_Web.Core.Interfaces;
using Farmacia_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Farmacia_Web.Core.Clientes
{
    public class ClientesBussiness : ICoreBussiness<CLIENTE>
    {
        //guardamos en base de datos el objeto cliente
        public RespuestaServicio<CLIENTE> Guardar(CLIENTE _item)
        {
            RespuestaServicio<CLIENTE> respuesta = new RespuestaServicio<CLIENTE>();
            try
            {
                using (var bd = new FarmaciaEntities())
                {
                    _item.Estatus = true;
                    bd.CLIENTE.Add(_item);
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
        /// <summary>
        /// Consultamos todos los clientes con estatus activo en la base de datos
        /// </summary>
        /// <returns></returns>
        public RespuestaServicio<CLIENTE> Consulta()
        {
            RespuestaServicio<CLIENTE> respuesta = new RespuestaServicio<CLIENTE>();
            try
            {
                using (var bd = new FarmaciaEntities())
                {
                    respuesta.Lista_Resultado = bd.CLIENTE.ToList();

                    //Consultando el store procedure creado manualmente en la base de datos
                    //trae como resultado una lista de clientes
                    var resultado = bd.SP_SEL_CLIENTES().Cast<CLIENTE>();
                }
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }
        /// <summary>
        /// Consultamos un cliente con un Id especifíco.
        /// </summary>
        /// <param name="ClienteId"></param>
        /// <returns></returns>
        public RespuestaServicio<CLIENTE> Consulta(int Id)
        {
            RespuestaServicio<CLIENTE> respuesta = new RespuestaServicio<CLIENTE>();
            try
            {
                using (var bd = new FarmaciaEntities())
                {
                    respuesta.Resultado = bd.CLIENTE.Find(Id);
                }
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }
        public RespuestaServicio<CLIENTE> Modificar(CLIENTE _cliente)
        {
            RespuestaServicio<CLIENTE> respuesta = new RespuestaServicio<CLIENTE>();
            try
            {
                if (_cliente.Id <= 0)
                    throw new Exception("El Id es invalido");

                using (var bd = new FarmaciaEntities())
                {

                    bd.Entry(_cliente).State = System.Data.Entity.EntityState.Modified;
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
        public RespuestaServicio<CLIENTE> Eliminar(int Id)
        {
            RespuestaServicio<CLIENTE> respuesta = new RespuestaServicio<CLIENTE>();
            try
            {
                if (Id <= 0)
                    throw new Exception("El Id es invalido");

                using (var bd = new FarmaciaEntities())
                {
                    var _cliente = bd.CLIENTE.Find(Id);
                    _cliente.Estatus = false;
                    bd.Entry(_cliente).State = System.Data.Entity.EntityState.Modified;
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