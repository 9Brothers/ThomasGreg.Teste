using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThomasGreg.Teste.Application.Interfaces;
using ThomasGreg.Teste.Domain.Entities;

namespace ThomasGreg.Teste.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogradouroController : ControllerBase
    {
        protected readonly ILogradouroAppService _logradouroAppService;

        public LogradouroController(ILogradouroAppService logradouroAppService)
        {
            _logradouroAppService = logradouroAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid guid)
        {
            try
            {
                var logradouro = await _logradouroAppService.Get(new Logradouro { Id = guid });

                return Ok(logradouro);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Logradouro logradouro)
        {
            try
            {
                logradouro = await _logradouroAppService.Add(logradouro);

                return Ok(logradouro);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Logradouro logradouro)
        {
            try
            {
                logradouro = await _logradouroAppService.Update(logradouro);

                return Ok(logradouro);
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
                await _logradouroAppService.Delete(guid);

                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}