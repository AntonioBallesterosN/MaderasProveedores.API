using MaderasProveedores.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaderasProveedores.API.DTO;
using AutoMapper;
using MaderasProveedores.Core.Interfaces;
using MaderasProveedores.DataAccess.Dto;

namespace MaderasProveedores.API.Controllers
{
    public class EmpleadosController : Controller
    {
        //Inyeccion de dependecias 

        //private readonly MaderasProveedoresContext _maderasProveedoresContext;
        private readonly IMapper _mapper;
        private readonly IEmpleadosService _empleadosService;

        public EmpleadosController(IMapper mapper, IEmpleadosService empleadosService)
        {
            // yo soy el constructor 
            //_maderasProveedoresContext = maderasProveedoresContext;
            _mapper = mapper;
            _empleadosService = empleadosService;
        }

        //[HttpGet("getAllEmpleados")]
        //public async Task<IActionResult> GetAllEmpleados()
        //{
        //    var empleados = await _maderasProveedoresContext.Empleados.ToListAsync();
        //    var listaMapeada = _mapper.Map<List<AddEmpleadoDto>>(empleados);

        //    return Ok(listaMapeada);
        //}

        [HttpPost("addEmpleados")]
        public async Task<IActionResult> AddEmpleados([FromBody] EmpleadosDto empleadoDto)
        {
            var response = await _empleadosService.AddEmpleados(empleadoDto);
            return Ok(response);
        }

        //[HttpPut("updateEmpleados")]
        //public async Task<IActionResult> UpdateEmpleados(int id, AddEmpleadoDto empleadoDto)
        //{
        //    var newEmpleado = _mapper.Map<Empleado>(empleadoDto);
        //    newEmpleado.Id = id;
        //    _maderasProveedoresContext.Empleados.Update(newEmpleado);
        //    await _maderasProveedoresContext.SaveChangesAsync();

        //    var empleados = await _maderasProveedoresContext.Empleados.ToListAsync();

        //    return Ok(empleados);
        //}

        //[HttpDelete("deleteEmpleados")]
        //public async Task<IActionResult> DeleteEmpleados(int id)
        //{
        //    var idToDelete = new Empleado { Id = id };
        //    _maderasProveedoresContext.Empleados.Remove(idToDelete);
        //    await _maderasProveedoresContext.SaveChangesAsync();

        //    var empleados = await _maderasProveedoresContext.Empleados.ToListAsync();

        //    return Ok(empleados);
        //}
    }
}
