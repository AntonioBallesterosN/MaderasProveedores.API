using System;
using System.Collections.Generic;

namespace MaderasProveedores.API.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Rfc { get; set; }

    public string? Ciudad { get; set; }

    public int IdEstado { get; set; }

    public int? IdPersona { get; set; }

    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    public virtual Persona? IdPersonaNavigation { get; set; }
}
