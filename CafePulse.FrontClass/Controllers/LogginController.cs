using CafePulse.ModelClass;
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

        [HttpGet]
        public IActionResult OpenFormNewUser()
        {
            var user = new ModelClass.Usuario
            {
                Genero = new ModelClass.Genero(),
                Rol = new ModelClass.Rol()
            };

            var responseGenere = BusinessClass.Genero.GetAll();
            var responseRol = BusinessClass.Rol.GetAll();

            if (responseRol.Success && responseRol.Objects != null)
            {
                user.Rol.Roles = responseRol.Objects
                    .Cast<ModelClass.Rol>() // Convertimos de object a Rol
                    .Where(r => r.IdRol != 2) // Excluimos el IdRol 2
                    .Cast<object>() // Volvemos a castear a object si es necesario
                    .ToList();
            }

            if (responseGenere.Success)
            {
                user.Genero.Generos = responseGenere.Objects;
                return View(user);
            }

            return View();
        }

        [HttpPost]
        public IActionResult OpenFormNewUser(CafePulse.ModelClass.Usuario DataUser)
        {
            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(DataUser.Nombre) ||
                string.IsNullOrWhiteSpace(DataUser.Apellido) ||
                string.IsNullOrWhiteSpace(DataUser.FechaNacimiento) ||
                string.IsNullOrWhiteSpace(DataUser.Telefono) ||
                string.IsNullOrWhiteSpace(DataUser.Email) ||
                string.IsNullOrWhiteSpace(DataUser.User) ||
                string.IsNullOrWhiteSpace(DataUser.Pass) ||
                string.IsNullOrWhiteSpace(DataUser.ConfirmPass) ||
                DataUser.Rol == null ||
                DataUser.Genero == null)
            {
                ViewBag.Titulo = "Error de validación";
                ViewBag.Mensaje = "Todos los campos son obligatorios.";
                return View("Modal");
            }

            // Validación de contraseñas
            if (DataUser.Pass != DataUser.ConfirmPass)
            {
                ViewBag.Titulo = "Error en las contraseñas";
                ViewBag.Mensaje = "Las contraseñas ingresadas no coinciden.";
                return View("Modal");
            }

            // Intentar insertar el usuario
            var responseInsert = BusinessClass.Usuario.InsertNewUser(DataUser);

            if (responseInsert == null)
            {
                ViewBag.Titulo = "Error interno";
                ViewBag.Mensaje = "No se pudo procesar la solicitud. Inténtalo nuevamente.";
                return View("Modal");
            }

            if (responseInsert.Success)
            {
                ViewBag.Titulo = "Registro exitoso";
                ViewBag.Mensaje = "El usuario se registró correctamente.";
            }
            else
            {
                ViewBag.Titulo = "Error al registrar usuario";
                ViewBag.Mensaje = "Ocurrió un error al intentar registrar al usuario: " + responseInsert.ErrorMessage;
            }

            return View("Modal");
        }


    }
}
