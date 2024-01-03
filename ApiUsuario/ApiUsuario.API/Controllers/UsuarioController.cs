using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiUsuario.ApiUsuario.Domain.Models;
using ApiUsuario.ApiUsuario.Infrastructure.Repositorys;
using ApiUsuario.ApiUsuario.Application.Services;

namespace ApiUsuario.ApiUsuario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        public UsuarioController(IUsuarioRepository UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<UsuarioServiceResponse<List<UsuarioModel>>>> GetUsuarios()
        {
            return Ok( await _UsuarioRepository.GetUsuarios());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioServiceResponse<UsuarioModel>>> GetUsuarioById(int id)
        {
            UsuarioServiceResponse<UsuarioModel> serviceResponse = await _UsuarioRepository.GetUsuarioById(id);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioServiceResponse<List<UsuarioModel>>>> CreateUsuario(UsuarioModel novoUsuario)
        {
            return Ok(await _UsuarioRepository.CreateUsuario(novoUsuario));
        }

        [HttpPut]
        public async Task<ActionResult<UsuarioServiceResponse<List<UsuarioModel>>>> UpdateUsuario(UsuarioModel editadoUsuario)
        {
            UsuarioServiceResponse<List<UsuarioModel>> serviceResponse = await _UsuarioRepository.UpdateUsuario(editadoUsuario);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<UsuarioServiceResponse<List<UsuarioModel>>>> DeleteUsuario(int id)
        {
            UsuarioServiceResponse<List<UsuarioModel>> serviceResponse = await _UsuarioRepository.DeleteUsuario(id);

            return Ok(serviceResponse);

        }

    }
}
