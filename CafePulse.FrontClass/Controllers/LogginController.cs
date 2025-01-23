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
       
    }
}
