using Microsoft.AspNetCore.Mvc;

namespace MaderasProveedores.API.DTO
{
    public class AddAreaDto 
    {
        public string? Descripción { get; set; }
        public bool? Activo { get; set; }
    }
}
