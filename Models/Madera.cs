using System;
using System.Collections.Generic;

namespace MaderasProveedores.API.Models
{
    public partial class Madera
    {
        public int Id { get; set; }
        public string Maderas { get; set; } = null!;
        public int? Cantidad { get; set; }
        public int IdProveedores { get; set; }

        public virtual Proveedore IdProveedoresNavigation { get; set; } = null!;
    }
}
