using MaderasProveedores.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaderasProveedores.API.DTO;
using AutoMapper;
using MaderasProveedores.Core.Interfaces;
using MaderasProveedores.DataAccess.Dto;

namespace MaderasProveedores.API.Controllers
{
    public class AreaController : Controller
    {
        private readonly IAreaService _areaService;
        private readonly IClienteService _clienteService;

        public AreaController(IAreaService areaServices, IClienteService clienteService)
        {
            _areaService = areaServices;
            _clienteService = clienteService;
        }

        [HttpGet("getAllAreas")]
        public async Task<IActionResult> GetAllAreas()
        {
            var response = await _areaService.GetAll();
            var response2 = await _clienteService.GetAll();
            return Ok(new { response, response2 });
            
        }

        [HttpGet("getByIdAreas")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _areaService.GetById(id);
            return Ok(response);
        }

        [HttpPost("addAreas")]
        public async Task<IActionResult> AddAreas([FromBody] AreaDto areaDto)
        {
            var response = await _areaService.AddAreas(areaDto);
            return Ok(response);
        }

        [HttpPut("updateAreas")]
        public async Task<IActionResult> UpdateAreas([FromBody] AreaDto areaDto)
        {
            var response = await _areaService.UpdateArea(areaDto);
            return Ok(response);
        }

        [HttpDelete("deleteAreas")]
        public async Task<IActionResult> DeleteEmpleados(int id)
        {
            await _areaService.Delete(id);

            return Ok();
        }
    }
}