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
        //private readonly MaderasProveedoresContext _maderasProveedoresContext;
        private readonly IMapper _mapper;
        private readonly IAreaService _areaService;

        public AreaController(IMapper mapper, IAreaService areaServices)
        {
            //_maderasProveedoresContext = maderasProveedoresContext;
            _mapper = mapper;
            _areaService = areaServices;
        }

        [HttpGet("getAllAreas")]
        public async Task<IActionResult> GetAllAreas()
        {
            var response = await _areaService.GetAll();
            return Ok(response);
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