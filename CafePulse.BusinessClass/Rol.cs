using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CafePulse.BusinessClass
{
    public class Rol
    {
        public static CafePulse.ModelClass.Result GetAll()
        {
            var response = new CafePulse.ModelClass.Result();

            try
            {
                using var context = new CafePulse.DataBaseClass.Models.CoffeeDevBdContext();

                var query = context.CatRols.FromSqlRaw("EXEC USP_GetCat_Rol").ToList();

                if (query.Any())
                {

                    response.Objects = query.Select(item => new CafePulse.ModelClass.Rol
                    {
                        IdRol = item.Idrol,
                        Nombre = item.Rol
                    }).Cast<object>().ToList();
                    response.Success = true;

                }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = "No se encuentran registros.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = "Ocurrio un error al procesar la solicitud.";
                response.exception = ex;
            }
            return response;
        }
    }
}
