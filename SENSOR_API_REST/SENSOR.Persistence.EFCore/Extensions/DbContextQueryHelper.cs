using Microsoft.EntityFrameworkCore;
using SENSOR.Persistence.EFCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SENSOR.Persistence.EFCore.Extensions
{
    public static class DbContextQueryHelper
    {

        public static async Task<List<T>> ExecuteQueryAsync<T>(this ApplicationDbContext db, string query,
            params object[] parameters) where T : class, new()
        {
            var lst = new List<T>();

            using var command = db.Database.GetDbConnection().CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            command.Parameters.AddRange(parameters);

            await db.Database.OpenConnectionAsync();

            using var reader = await command.ExecuteReaderAsync();

            var lstColumns = typeof(T).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).ToList();

            while (await reader.ReadAsync())
            {
                var newObject = new T();

                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var name = reader.GetName(i);

                    PropertyInfo prop = lstColumns.Find(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase))!;

                    if (prop == null)
                        continue;

                    var val = reader.IsDBNull(i) ? null : reader.GetValue(i);

                    prop.SetValue(newObject, val);
                }
                lst.Add(newObject);
            }
            return lst;
        }

    }
}
