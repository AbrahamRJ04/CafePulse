using System;
using System.Collections.Generic;

namespace CafePulse.DataBaseClass.Models;

public partial class BitLogErrore
{
    public int Iderror { get; set; }

    public DateTime FechaError { get; set; }

    public string Descripcion { get; set; } = null!;
}
