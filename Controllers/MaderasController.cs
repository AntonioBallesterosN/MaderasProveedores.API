using Microsoft.AspNetCore.Mvc;
using MaderasProveedores.API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MaderasProveedores.API.DTO;
using MaderasProveedores.Core.Interfaces;
using MaderasProveedores.DataAccess.Dto;

namespace MaderasProveedores.API.Controllers
{
    public class MaderasController : Controller
    {
        private readonly IMaderasService _maderasService;

        public MaderasController(IMaderasService maderasService)
        {
            _maderasService = maderasService;
        }

        [HttpGet("getAllMaderas")]
        public async Task<IActionResult> GetAllMaderas()
        {
            var response = await _maderasService.GetAll();

            return Ok(response);
        }

        [HttpGet("getByIdMaderas")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _maderasService.GetById(id);

            return Ok(response);    
        }

        [HttpPost("addMaderas")]
        public async Task<IActionResult> AddMaderas([FromBody] MaderaDto maderaDto)
        {
            var response = await _maderasService.AddMadera(maderaDto);

            return Ok(response);
        }

        [HttpPut("updateMaderas")]
        public async Task<IActionResult> UpdateMaderas(MaderaDto maderaDto)
        {
            var response = await _maderasService.Update(maderaDto);

            return Ok(response);
        }

        [HttpDelete("deleteMaderas")]
        public async Task<IActionResult> DeleteEmpleados(int id)
        {
            await _maderasService.Delete(id);

            return Ok();
        }
    }
}
