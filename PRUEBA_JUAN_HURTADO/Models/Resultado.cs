using System;
using System.Collections.Generic;

namespace PRUEBA_JUAN_HURTADO.Models;

public partial class Resultado
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Pais { get; set; }

    public int? Arranque { get; set; }

    public int? Envio { get; set; }
}
