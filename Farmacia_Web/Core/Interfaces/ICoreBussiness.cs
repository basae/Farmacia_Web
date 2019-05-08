using Farmacia_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Farmacia_Web.Core.Interfaces
{
    interface ICoreBussiness<T>
    {
        RespuestaServicio<T> Guardar(T _item);
        RespuestaServicio<T> Consulta();
        RespuestaServicio<T> Consulta(int Id);
        RespuestaServicio<T> Modificar(T _item);
        RespuestaServicio<T> Eliminar(int Id);
    }
}