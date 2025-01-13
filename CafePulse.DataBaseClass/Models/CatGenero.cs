using System;
using System.Collections.Generic;

namespace CafePulse.DataBaseClass.Models;

public partial class CatGenero
{
    public int Idgenero { get; set; }

    public string Genero { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
