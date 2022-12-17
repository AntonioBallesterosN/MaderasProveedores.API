using MaderasProveedores.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaderasProveedores.API.DTO;
using AutoMapper;

namespace MaderasProveedores.API.Controllers
{
    public class EmpleadosController : Controller
    {
        //Inyeccion de dependecias 

        private readonly MaderasProveedoresContext _maderasProveedoresContext;
        private readonly IMapper _mapper;

        public EmpleadosController(MaderasProveedoresContext maderasProveedoresContext, IMapper mapper)
        {
            // yo soy el constructor 
            _maderasProveedoresContext = maderasProveedoresContext;
            _mapper = mapper;
        }

        [HttpGet("getAllEmpleados")]
        public async Task<IActionResult> GetAllEmpleados()
        {
            var empleados = await _maderasProveedoresContext.Empleados.ToListAsync();
            var listaMapeada = _mapper.Map<List<AddEmpleadoDto>>(empleados);

            return Ok(listaMapeada);
        }

        [HttpPost("addEmpleados")]
        public async Task<IActionResult> AddEmpleados([FromBody] AddEmpleadoDto empleadoDto)
        {
            if (string.IsNullOrWhiteSpace(empleadoDto.Nombre))
            {
                return BadRequest("Los campos nombre y apellido son obligatorios");
            }

            if (string.IsNullOrWhiteSpace(empleadoDto.Apellido))
            {
                return BadRequest("Los campos nombre y apellido son obligatorios");
            }

            //busca en area la id que se ingresa en empleado
            var area = await _maderasProveedoresContext.Areas.FirstOrDefaultAsync(p => p.Id == empleadoDto.IdArea);

            if (area is null)
            {
                return BadRequest("No existe el area");
            }
            
            var newEmpleado = _mapper.Map<Empleado>(empleadoDto);

            newEmpleado.Activo = true;

            await _maderasProveedoresContext.Empleados.AddAsync(newEmpleado);
            await _maderasProveedoresContext.SaveChangesAsync();

            var empleados = await _maderasProveedoresContext.Empleados.AsNoTracking().ToListAsync();
            var listaMapeada = _mapper.Map<List<AddEmpleadoDto>>(empleados);

            return Ok(listaMapeada);
        }

        [HttpPut("updateEmpleados")]
        public async Task<IActionResult> UpdateEmpleados(int id, AddEmpleadoDto empleadoDto)
        {
            var newEmpleado = _mapper.Map<Empleado>(empleadoDto);
            newEmpleado.Id = id;
            _maderasProveedoresContext.Empleados.Update(newEmpleado);
            await _maderasProveedoresContext.SaveChangesAsync();

            var empleados = await _maderasProveedoresContext.Empleados.ToListAsync();

            return Ok(empleados);
        }

        [HttpDelete("deleteEmpleados")]
        public async Task<IActionResult> DeleteEmpleados(int id)
        {
            var idToDelete = new Empleado { Id = id };
            _maderasProveedoresContext.Empleados.Remove(idToDelete);
            await _maderasProveedoresContext.SaveChangesAsync();

            var empleados = await _maderasProveedoresContext.Empleados.ToListAsync();

            return Ok(empleados);
        }
    }
}
