using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafePulse.ModelClass
{
    public class Menu
    {

        public int Idproductomenu { get; set; }

        public string NombreProducto { get; set; }

        public decimal Precio { get; set; }

        public List<Object> MenuList { get; set; }
    }

  
    public class Opciones
    {
        public List<string> MenuConfigurado { get; set; }
        public int Rol {  get; set; }
    }
}
