using System;
using System.Collections.Generic;

namespace MaderasProveedores.API.Models
{
    public partial class Proveedore
    {
        public Proveedore()
        {
            Maderas = new HashSet<Madera>();
        }

        public int Id { get; set; }
        public string? Proveedor { get; set; }
        public long? Telefono { get; set; }
        public string? Rfc { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Madera> Maderas { get; set; }
    }
}
