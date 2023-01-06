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

        //[HttpGet("getAllAreas")]
        //public async Task<IActionResult> GetAllAreas()
        //{
        //    var areas = await _maderasProveedoresContext.Areas.ToListAsync();
        //    //var listaMapeada = _mapper.Map<List<AddAreaDto>>(areas);

        //    return Ok(areas);
        //}

        [HttpPost("addAreas")]
        public async Task<IActionResult> AddAreas([FromBody] AreaDto areaDto)
        {
            var response = await _areaService.AddAreas(areaDto);
            return Ok(response);
        }

        //[HttpPut("updateAreas")]
        //public async Task<IActionResult> UpdateAreas([FromBody] AddAreaDto areaDto)
        //{
        //    var newArea = _mapper.Map<Area>(areaDto);
            
        //    _maderasProveedoresContext.Areas.Update(newArea);
        //    await _maderasProveedoresContext.SaveChangesAsync();

        //    var areas = await _maderasProveedoresContext.Areas.ToListAsync();

        //    return Ok(areas);
        //}

        //[HttpDelete("deleteAreas")]
        //public async Task<IActionResult> DeleteEmpleados([FromBody] AddAreaDto areaDto)
        //{
        //    var deleteArea = _mapper.Map<Area>(areaDto);
        //    //var id = areaDto.Id;
        //    //var elementoId = await _maderasProveedoresContext.Areas.FirstOrDefaultAsync(d => d.Id == id);
        //    //var idToDelete = new Area { Id = areaDto.Id };
        //    _maderasProveedoresContext.Areas.Remove(deleteArea);
        //    await _maderasProveedoresContext.SaveChangesAsync();

        //    var areas = await _maderasProveedoresContext.Areas.ToListAsync();

        //    return Ok(areas);
        //}
    }
}