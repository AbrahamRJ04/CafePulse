using System;
using System.Collections.Generic;

namespace CafePulse.DataBaseClass.Models;

public partial class Cliente
{
    public int Idcliente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Usuario { get; set; }

    public string? NumeroTelefonico { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
