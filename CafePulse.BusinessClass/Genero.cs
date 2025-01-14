using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafePulse.BusinessClass
{
    public class Genero
    {
        public static CafePulse.ModelClass.Result GetAll()
        {
            var response = new CafePulse.ModelClass.Result();

            try
            {
                using var context = new CafePulse.DataBaseClass.Models.CoffeeDevBdContext();

                // Ejecutar el procedimiento almacenado
                var query = context.CatGeneros.FromSqlRaw("EXEC USP_GetCat_Genero").ToList();

                // Validar si la consulta tiene resultados
                if (query.Any())
                {
                    response.Objects = query.Select(item => new CafePulse.ModelClass.Genero
                    {
                        IdGenero = item.Idgenero,
                        Nombre = item.Genero
                    }).Cast<object>().ToList();

                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = "No se encontraron registros.";
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                response.Success = false;
                response.ErrorMessage = "Ocurrió un error al procesar la solicitud.";
                response.exception = ex; // Para logueo interno (si aplica)
            }

            return response;
        }

    }
}
