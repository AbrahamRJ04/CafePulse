using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafePulse.ModelClass
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string ConfirmPass { get; set; }
        public List<Object> Usuarios { get; set; }
        

        #region
        public CafePulse.ModelClass.Rol Rol { get; set; }
        public CafePulse.ModelClass.Genero Genero { get; set; }
        #endregion

    }

}
