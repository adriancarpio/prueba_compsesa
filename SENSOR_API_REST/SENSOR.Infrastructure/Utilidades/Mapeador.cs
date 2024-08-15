using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SENSOR.Infrastructure.Utilidades
{
    public static class Mapeador
    {
        public static T Mapear<T>(this object objeto)
        {
            var serializar = JsonSerializer.Serialize(objeto);
            return JsonSerializer.Deserialize<T>(serializar)!;
        }
    }
}
