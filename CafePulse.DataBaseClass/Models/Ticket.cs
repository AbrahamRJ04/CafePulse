using System;
using System.Collections.Generic;

namespace CafePulse.DataBaseClass.Models;

public partial class Ticket
{
    public int Idcompra { get; set; }

    public int? Idproductomenu { get; set; }

    public int? Cantidad { get; set; }

    public virtual Menu? IdproductomenuNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
