using Microsoft.AspNetCore.Mvc;
using MaderasProveedores.API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MaderasProveedores.API.DTO;

namespace MaderasProveedores.API.Controllers
{
    public class MaderasController : Controller
    {
        private readonly MaderasProveedoresContext _maderasProveedoresContext;
        private readonly IMapper _mapper;

        public MaderasController(MaderasProveedoresContext maderasProveedoresContext, IMapper mapper)
        {
            _maderasProveedoresContext = maderasProveedoresContext;
            _mapper = mapper;
        }

        [HttpGet("getAllMaderas")]
        public async Task<IActionResult> GetAllMaderas()
        {
            var maderas = await _maderasProveedoresContext.Maderas.ToListAsync();
            var listaMapeada = _mapper.Map<List<AddMaderasDto>>(maderas);

            return Ok(listaMapeada);
        }

        [HttpPost("addMaderas")]
        public async Task<IActionResult> AddMaderas([FromBody] AddMaderasDto maderaDto)
        {
            if (string.IsNullOrWhiteSpace(maderaDto.Maderas))
            { 
                return BadRequest("Ingresa una madera"); 
            }

            if(maderaDto.Cantidad <= 0 )
            {
                return BadRequest("Ingresa una cantidad");
            }

            var proveedor = await _maderasProveedoresContext.Proveedores.FirstOrDefaultAsync(p => p.Id == maderaDto.IdProveedores);

            if (proveedor is null)
            {
                return BadRequest("Proveedor no existe");
            }

            var newMadera = _mapper.Map<Madera>(maderaDto);
        
            await _maderasProveedoresContext.Maderas.AddAsync(newMadera);
            await _maderasProveedoresContext.SaveChangesAsync();

            var maderas = await _maderasProveedoresContext.Maderas.AsNoTracking().ToListAsync();
            var listaMapeada = _mapper.Map<List<AddMaderasDto>>(maderas);

            return Ok(listaMapeada);
        }

        [HttpPut("updateMaderas")]
        public async Task<IActionResult> UpdateMaderas(int id, AddMaderasDto maderaDto)
        {
            var newMadera = _mapper.Map<Madera>(maderaDto);
            newMadera.Id = id;
            _maderasProveedoresContext.Maderas.Update(newMadera);
            await _maderasProveedoresContext.SaveChangesAsync();

            var maderas = await _maderasProveedoresContext.Maderas.ToListAsync();

            return Ok(maderas);
        }

        [HttpDelete("deleteMaderas")]
        public async Task<IActionResult> DeleteEmpleados(int id)
        {
            var idToDelete = new Madera { Id = id };
            _maderasProveedoresContext.Maderas.Remove(idToDelete);
            await _maderasProveedoresContext.SaveChangesAsync();

            var maderas = await _maderasProveedoresContext.Maderas.ToListAsync();

            return Ok(maderas);
        }
    }
}
