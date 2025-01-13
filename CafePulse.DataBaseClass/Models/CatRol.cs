using System;
using System.Collections.Generic;

namespace CafePulse.DataBaseClass.Models;

public partial class CatRol
{
    public int Idrol { get; set; }

    public string Rol { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
