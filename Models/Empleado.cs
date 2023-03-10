using System;
using System.Collections.Generic;

namespace MaderasProveedores.API.Models
{
    public partial class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int IdArea { get; set; }
        public bool Activo { get; set; }

        public virtual Area IdAreaNavigation { get; set; } = null!;
    }
}
