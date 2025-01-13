using System;
using System.Collections.Generic;

namespace CafePulse.DataBaseClass.Models;

public partial class CatEstatusPedido
{
    public int Idestatusproducto { get; set; }

    public string EstatusPedido { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
