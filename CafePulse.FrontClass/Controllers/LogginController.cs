using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafePulse.FrontClass.Controllers
{
    public class LogginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            CafePulse.ModelClass.Usuario user = new ModelClass.Usuario();
            return View(user);
        }

        [HttpPost]
        public IActionResult GetInto(CafePulse.ModelClass.Usuario user)
        {
            string User = Request.Form["Usuario"].ToString();
            string Pass = Request.Form["Contraseña"].ToString();

            ModelClass.Result response = CafePulse.BusinessClass.Usuario.GetAuthenticationLog(User, Pass);


            if (response.Success)
            {
                ModelClass.Usuario usuario = new ModelClass.Usuario();
                usuario = (ModelClass.Usuario)response.Object;

                if (usuario != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Mensaje = "El usuario o Contraseña ingresados no son validos o no existen";
                }
            }
            else
            {
                ViewBag.Mensaje = "El Usuario y/o Contraseña son Incorrectos";
            }

            return View("Modal");
        }
    }
}
