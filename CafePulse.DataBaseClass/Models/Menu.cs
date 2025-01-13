using System;
using System.Collections.Generic;

namespace CafePulse.DataBaseClass.Models;

public partial class Menu
{
    public int Idproductomenu { get; set; }

    public string? NombreProducto { get; set; }

    public decimal? Cantidad { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
