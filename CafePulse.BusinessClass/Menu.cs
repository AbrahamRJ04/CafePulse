using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace CafePulse.BusinessClass
{
    public class Menu
    {
        public static CafePulse.ModelClass.Result GetAll()
        {
            var response = new CafePulse.ModelClass.Result();

            try
            {
                using var context = new CafePulse.DataBaseClass.Models.CoffeeDevBdContext();
                var query = context.Menus.FromSqlRaw("USP_GETMENU").ToList();

                if (query.Any())
                {
                    response.Objects = query.Select(item => new CafePulse.ModelClass.Menu
                    {
                        Idproductomenu = item.Idproductomenu,
                        NombreProducto = item.NombreProducto,
                        Precio = (decimal)item.Precio
                    }).Cast<object>().ToList();
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = "No se encontraron registros";
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = "Ocurrio un erropr al procesar la solicitud";
                response.exception = ex;
            }

            return response;
        }
    }
}
