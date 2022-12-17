namespace MaderasProveedores.API.DTO
{
    //esta clase se utilizara para añadir objetos exclusivamente 
    public class AddEmpleadoDto
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? IdArea { get; set; }
        public bool? Activo { get; set; }
    }
}
