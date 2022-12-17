using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MaderasProveedores.API.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MaderasProveedores.API.DTO;

namespace MaderasProveedores.API.Controllers
{
    public class ProveedoreController : Controller
    {
        private readonly MaderasProveedoresContext _maderasProveedoresContext;
        private readonly IMapper _mapper;


        public ProveedoreController(MaderasProveedoresContext maderasProveedoresContext, IMapper mapper)
        {
            _maderasProveedoresContext = maderasProveedoresContext;
            _mapper = mapper;
        }

        [HttpGet("getAllProveedores")]
        public async Task<IActionResult> GetAllProvedorees()
        {
            var provedores = await _maderasProveedoresContext.Proveedores.ToListAsync();

            return Ok(provedores);
        }

        [HttpPost("addProveddores")]
        public async Task<IActionResult> AddProveedor(AddProveedorDto proveedorDto)
        {
            var newProveedor = _mapper.Map<Proveedore>(proveedorDto);
           
            if(!string.IsNullOrWhiteSpace(proveedorDto.Rfc))
            {
                if(proveedorDto.Rfc.Length != 13)
                {
                    return BadRequest("RFC debe contener 13 caracteres");
                }
            }
            
            if (string.IsNullOrWhiteSpace(proveedorDto.Proveedor))
            {
                return BadRequest("Ingresa un proveedor");
            }
           
            var telefonoLength = newProveedor.Telefono.ToString().Length;
           
            if (telefonoLength > 10)
            {
                return BadRequest("Ingresa un numero menor a 10 digitos");
            }

            await _maderasProveedoresContext.Proveedores.AddAsync(newProveedor);
            await _maderasProveedoresContext.SaveChangesAsync();

            var proveedores = await _maderasProveedoresContext.Proveedores.ToListAsync();

            return Ok(proveedores);
        }

        [HttpPut("updateProveedores")]
        public async Task<IActionResult> UpdateProveedor(int id, AddProveedorDto proveedorDto)
        {
            var newProveedor = _mapper.Map<Proveedore>(proveedorDto);
            newProveedor.Id = id;
            _maderasProveedoresContext.Proveedores.Update(newProveedor);
            await _maderasProveedoresContext.SaveChangesAsync();

            var proveedores = await _maderasProveedoresContext.Proveedores.ToListAsync();

            return Ok(proveedores);
        }

        [HttpDelete("deleteProveedores")]

        public async Task<IActionResult> RemoveProveedor(int id)
        {
            var iDProveedorToDelete = new Proveedore { Id = id };
            _maderasProveedoresContext.Proveedores.Remove(iDProveedorToDelete);
            await _maderasProveedoresContext.SaveChangesAsync();

            var proveedores = await _maderasProveedoresContext.Proveedores.ToListAsync();

            return Ok(proveedores);
        }

    }
}
