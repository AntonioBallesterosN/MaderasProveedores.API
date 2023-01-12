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

        [HttpGet("getAllEmpleados")]
        public async Task<IActionResult> GetAllEmpleados()
        {
            var response = await _empleadosService.GetAll();

            return Ok(response);
        }

        [HttpGet("getByIdEmpleados")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _empleadosService.GetById(id);

            return Ok(response);
        }

        [HttpPost("addEmpleados")]
        public async Task<IActionResult> AddEmpleados([FromBody] EmpleadosDto empleadoDto)
        {
            var response = await _empleadosService.AddEmpleados(empleadoDto);
            return Ok(response);
        }

        [HttpPut("updateEmpleados")]
        public async Task<IActionResult> UpdateEmpleados([FromBody] EmpleadosDto empleadoDto)
        {
            var response = await _empleadosService.Update(empleadoDto);

            return Ok(response);
        }

        [HttpDelete("deleteEmpleados")]
        public async Task<IActionResult> DeleteEmpleados(int id)
        {
            await _empleadosService.Delete(id);

            return Ok();
        }
    }
}
