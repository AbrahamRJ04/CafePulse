using Microsoft.AspNetCore.Mvc;

namespace CafePulse.FrontClass.Controllers
{
    public class CartaMenuController : Controller
    {
        [HttpGet]
        public IActionResult GetAllMenuCafe(int Rol)
        {
            ModelClass.Result Response = BusinessClass.Menu.GetAll();
            if (Response.Success)
            {
                ModelClass.Menu menuCarta = new ModelClass.Menu();
                menuCarta.MenuList = Response.Objects;
                ViewBag.Rol = Rol;
                return View(menuCarta);
            }
            else
            {
                ViewBag.Mensaje = "Ocurrio un error interno al buscar la Carta de Menu";
                return View("Modal");
            }
        }


        //[HttpGet]
        //public IActionResult ItemMenu(int? Idproductomenu, int Rol)
        //{
        //    if(Idproductomenu == null)
        //    {
        //        return View();
        //    }
        //    else
        //    {

        //    }
        //}
    }
}
