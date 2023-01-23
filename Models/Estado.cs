using System;
using System.Collections.Generic;

namespace MaderasProveedores.API.Models;

public partial class Estado
{
    public int Id { get; set; }

    public string? Estado1 { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();
}
