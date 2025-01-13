using System;
using System.Collections.Generic;

namespace CafePulse.DataBaseClass.Models;

public partial class Inventario
{
    public int Idinventario { get; set; }

    public string? Nombre { get; set; }

    public int? Cantidad { get; set; }
}
