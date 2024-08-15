using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VENTA.Dto
{
    public class RespuestaGenerica<T>
    {
        public bool EsValida { get; set; }
        public string? Mensaje { get; set; }
        public T? Resultado { get; set; }

        public static RespuestaGenerica<T> RespuestaError(string mensajeError)
        {
            return new RespuestaGenerica<T>()
            {
                EsValida = false,
                Mensaje = mensajeError
            };
        }

        public static RespuestaGenerica<T> RespuestaExito(T resultado, string mensajeExito = "Operación realizada exitosamente")
        {
            return new RespuestaGenerica<T>()
            {
                EsValida = true,
                Mensaje = mensajeExito,
                Resultado = resultado
            };
        }
    }
}
