using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MaderasProveedores.API.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MaderasProveedores.API.DTO;
using MaderasProveedores.Core.Interfaces;
using MaderasProveedores.DataAccess.Dto;

namespace MaderasProveedores.API.Controllers
{
    public class ProveedoreController : Controller
    {
        private readonly IProveedoresService _proveedoresService;

        public ProveedoreController(IProveedoresService proveedoresService)
        {
            _proveedoresService = proveedoresService;
        }

        [HttpGet("getAllProveedores")]
        public async Task<IActionResult> GetAllProvedorees()
        {
            var response =await _proveedoresService.GetAll();

            return Ok(response);
        }

        [HttpGet("getByIdProveedores")]
        public async Task<IActionResult> GetById(int id)
        {
            var response =await _proveedoresService.GetById(id);
            
            return Ok(response);
        }

        [HttpPost("addProveddores")]
        public async Task<IActionResult> AddProveedor(ProveedoresDto proveedoresDto)
        {
            var response =await _proveedoresService.AddProveedor(proveedoresDto);

            return Ok(response);
        }

        [HttpPut("updateProveedores")]
        public async Task<IActionResult> UpdateProveedor(ProveedoresDto proveedorDto)
        {
            var response =await _proveedoresService.Update(proveedorDto);
            
            return Ok(response);
        }

        [HttpDelete("deleteProveedores")]

        public async Task<IActionResult> Delete(int id)
        {
            await _proveedoresService.Delete(id);

            return Ok();
        }

    }
}
