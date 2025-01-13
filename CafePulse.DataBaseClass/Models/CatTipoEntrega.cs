using System;
using System.Collections.Generic;

namespace CafePulse.DataBaseClass.Models;

public partial class CatTipoEntrega
{
    public int Idtipoentrega { get; set; }

    public string TipoEntrega { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
