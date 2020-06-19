using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThomasGreg.Teste.Application.Interfaces;
using ThomasGreg.Teste.Domain.Entities;

namespace ThomasGreg.Teste.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        protected readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet]
        [Authorize("admin")]
        public async Task<IActionResult> Get(string username, string password)
        {
            try
            {
                var usuario = await _usuarioAppService.Get(new Usuario {  Username = username, Password = password });

                return Ok(usuario);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Add(Usuario usuario)
        {
            try
            {
                usuario = await _usuarioAppService.Add(usuario);

                return Ok(usuario);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(Usuario usuario)
        {
            try
            {
                usuario = await _usuarioAppService.Authenticate(usuario);

                return Ok(usuario);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Usuario usuario)
        {
            try
            {
                usuario = await _usuarioAppService.Update(usuario);

                return Ok(usuario);
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
                await _usuarioAppService.Delete(guid);

                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}