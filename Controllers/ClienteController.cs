using MaderasProveedores.Core.Interfaces;
using MaderasProveedores.DataAccess.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MaderasProveedores.API.Controllers
{
    public class ClienteController : Controller
    {
        public readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("getAllClientes")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _clienteService.GetAll();
            return Ok(response);
        }

        [HttpGet("getByIdClientes")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _clienteService.GetById(id);
            return Ok(response);
        }

        [HttpPost("addClientes")]
        public async Task<IActionResult> Add([FromBody] ClienteDto clienteDto)
        {
            var response = await _clienteService.AddCliente(clienteDto);
            return Ok(response);
        }

        [HttpPut("updateClientes")]
        public async Task<IActionResult> Update([FromBody] ClienteDto clienteDto)
        {
            var response = await _clienteService.UpdateCliente(clienteDto);
            return Ok(response);
        }

        [HttpDelete("deleteClientes")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            await _clienteService.Delete(id);
            return Ok();
        }
    }
}

