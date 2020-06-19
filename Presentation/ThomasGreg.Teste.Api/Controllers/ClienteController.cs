using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThomasGreg.Teste.Application.Interfaces;
using ThomasGreg.Teste.Domain.Entities;

namespace ThomasGreg.Teste.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        protected readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        /// <summary>
        /// Use os parâmetros guid ou email na query string para buscar por uma dessas opções, caso preenchido as duas, será buscado pelo guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(Guid guid, string email)
        {
            try
            {
                var cliente = await _clienteAppService.Get(new Cliente { Id = guid, Email = email });

                return Ok(cliente);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Cliente cliente)
        {
            try
            {
                cliente = await _clienteAppService.Add(cliente);

                return Ok(cliente);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Cliente cliente)
        {
            try
            {
                cliente = await _clienteAppService.Update(cliente);

                return Ok(cliente);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid guid)
        {
            try
            {
                await _clienteAppService.Delete(guid);

                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}