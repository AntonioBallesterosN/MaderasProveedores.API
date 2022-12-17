using AutoMapper;
using MaderasProveedores.API.DTO;
using MaderasProveedores.API.Models;

namespace MaderasProveedores.API.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddEmpleadoDto, Empleado>();
            CreateMap<AddProveedorDto, Proveedore>();
            CreateMap<AddMaderasDto, Madera>();
            CreateMap<AddAreaDto, Area>();
            CreateMap<Madera, AddMaderasDto>();
            CreateMap<Empleado, AddEmpleadoDto>();
            CreateMap<Area, AddAreaDto>();
        }
    }
}
