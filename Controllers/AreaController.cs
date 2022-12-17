using MaderasProveedores.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaderasProveedores.API.DTO;
using AutoMapper;

namespace MaderasProveedores.API.Controllers
{
    public class AreaController : Controller
    {
        private readonly MaderasProveedoresContext _maderasProveedoresContext;
        private readonly IMapper _mapper;

        public AreaController(MaderasProveedoresContext maderasProveedoresContext, IMapper mapper)
        {
            _maderasProveedoresContext = maderasProveedoresContext;
            _mapper = mapper;
        }

        [HttpGet("getAllAreas")]
        public async Task<IActionResult> GetAllAreas()
        {
            var areas = await _maderasProveedoresContext.Areas.ToListAsync();
            var listaMapeada = _mapper.Map<List<AddAreaDto>>(areas);

            return Ok(listaMapeada);
        }

        [HttpPost("addAreas")]
        public async Task<IActionResult> AddAreas([FromBody] AddAreaDto areaDto)
        {
            var newArea = _mapper.Map<Area>(areaDto);

            await _maderasProveedoresContext.Areas.AddAsync(newArea);
            await _maderasProveedoresContext.SaveChangesAsync();

            var areas = await _maderasProveedoresContext.Areas.AsNoTracking().ToListAsync();
            var listaMapeada = _mapper.Map<List<AddAreaDto>>(areas);

            return Ok(listaMapeada);
        }

        [HttpPut("updateAreas")]
        public async Task<IActionResult> UpdateEmpleados(int id, AddAreaDto areaDto)
        {
            var newArea = _mapper.Map<Empleado>(areaDto);
            newArea.Id = id;
            _maderasProveedoresContext.Update(newArea);
            await _maderasProveedoresContext.SaveChangesAsync();

            var areas = await _maderasProveedoresContext.Areas.ToListAsync();

            return Ok(areas);
        }

        [HttpDelete("deleteAreas")]
        public async Task<IActionResult> DeleteEmpleados(int id)
        {
            var idToDelete = new Area { Id = id };
            _maderasProveedoresContext.Areas.Remove(idToDelete);
            await _maderasProveedoresContext.SaveChangesAsync();

            var areas = await _maderasProveedoresContext.Areas.ToListAsync();

            return Ok(areas);
        }
    }
}