using System;
using System.Collections.Generic;

namespace MaderasProveedores.API.Models;

public partial class Persona
{
    public int Id { get; set; }

    public string? Persona1 { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();
}
