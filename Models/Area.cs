using System;
using System.Collections.Generic;

namespace MaderasProveedores.API.Models
{
    public partial class Area
    {
        public Area()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
