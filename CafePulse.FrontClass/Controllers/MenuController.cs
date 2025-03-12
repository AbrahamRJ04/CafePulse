using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafePulse.FrontClass.Controllers
{
    public class MenuController : Controller
    {

        [HttpGet]
        public IActionResult IntoMenu(int IdRol)
        {

            ModelClass.Opciones MenuConfig = new ModelClass.Opciones();


            if (MenuConfig.MenuConfigurado == null)
            {
                MenuConfig.MenuConfigurado = new List<string>();
            }

            switch (IdRol)
            {
                case 1: // Rol Usuario
                    MenuConfig.Rol = 1;
                    MenuConfig.MenuConfigurado.AddRange(new List<string>
            {
                "PEDIDOS",
                "CLIENTES",
                "MENU",
                "PROOVEDORES",
                "PROMOCIONES"
            });
                    break;

                case 2: // Rol Administrador
                    MenuConfig.Rol = 2;
                    MenuConfig.MenuConfigurado.AddRange(new List<string>
            {
                "USUARIOS",
                "PEDIDOS",
                "CLIENTES",
                "TICKETS",
                "MENU",
                "INVENTARIO",
                "AUTENTICACIONES",
                "PROOVEDORES",
                "QUEJAS / SUGERENCIAS",
                "PROMOCIONES"
            });
                    break;

                case 3: // Rol Cliente
                    MenuConfig.Rol = 3;
                    MenuConfig.MenuConfigurado.AddRange(new List<string>
            {
                "MENU",
                "SUGERENCIAS",
                "PROMOCIONES"
            });
                    break;

                default: // Rol por defecto (como Cliente)
                    MenuConfig.Rol = 3;
                    MenuConfig.MenuConfigurado.AddRange(new List<string>
            {
                "MENU",
                "SUGERENCIAS",
                "PROMOCIONES"
            });
                    break;
            }


            return View(MenuConfig);
        }

        [HttpGet]
        public IActionResult SeleccionMenu(string Seleccion, int Rol)
        {
            if (string.IsNullOrEmpty(Seleccion))
            {
                return BadRequest("Selección no válida");
            }

            switch (Seleccion.ToUpper())
            {
                case "MENU":
                  
                    return RedirectToAction("GetAllMenuCafe", "CartaMenu", new { Rol });

                default:
                    ViewBag.Mensaje = "No se encuentra un menu configurado por el momento";
                    return View("Modal");
            }
           
        }

    }
}
