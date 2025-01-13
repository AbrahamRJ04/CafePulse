using System;
using System.Collections.Generic;

namespace CafePulse.DataBaseClass.Models;

public partial class Pedido
{
    public int Idpedido { get; set; }

    public int? Idcompra { get; set; }

    public DateOnly? HoraPedido { get; set; }

    public int? Idcliente { get; set; }

    public int? Idtipoentrega { get; set; }

    public int? Idusuario { get; set; }

    public int? Idestatuspedido { get; set; }

    public virtual Cliente? IdclienteNavigation { get; set; }

    public virtual Ticket? IdcompraNavigation { get; set; }

    public virtual CatEstatusPedido? IdestatuspedidoNavigation { get; set; }

    public virtual CatTipoEntrega? IdtipoentregaNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
