using Microsoft.AspNetCore.Mvc;

namespace MaderasProveedores.API.DTO
{
    public class AddAreaDto 
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public bool? Activo { get; set; }
    }
}
