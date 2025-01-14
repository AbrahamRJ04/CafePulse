using System;
using System.Collections.Generic;

namespace CafePulse.DataBaseClass.Models;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public int? Idgenero { get; set; }

    public int? Idrol { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Usuario1 { get; set; }

    public byte[]? Contrasenahash { get; set; }

    public virtual CatGenero? IdgeneroNavigation { get; set; }

    public virtual CatRol? IdrolNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();


    #region
    public string? Genero { get; set; }

    public string? Rol { get; set; }
    #endregion


}
