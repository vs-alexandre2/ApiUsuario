using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiTarefa.ApiTarefa.Domain.Models;
using ApiTarefa.ApiTarefa.Infrastructure.Repositorys;
using ApiTarefa.ApiTarefa.Application.Services;

namespace ApiTarefa.ApiTarefa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _TarefaRepository;
        public TarefaController(ITarefaRepository TarefaRepository)
        {
            _TarefaRepository = TarefaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<TarefaServiceResponse<List<TarefaModel>>>> GetTarefas()
        {
            return Ok( await _TarefaRepository.GetTarefas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaServiceResponse<TarefaModel>>> GetTarefaById(int id)
        {
            TarefaServiceResponse<TarefaModel> serviceResponse = await _TarefaRepository.GetTarefaById(id);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaServiceResponse<List<TarefaModel>>>> CreateTarefa(TarefaModel novoTarefa)
        {
            return Ok(await _TarefaRepository.CreateTarefa(novoTarefa));
        }

        [HttpPut]
        public async Task<ActionResult<TarefaServiceResponse<List<TarefaModel>>>> UpdateTarefa(TarefaModel editadoTarefa)
        {
            TarefaServiceResponse<List<TarefaModel>> serviceResponse = await _TarefaRepository.UpdateTarefa(editadoTarefa);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<TarefaServiceResponse<List<TarefaModel>>>> DeleteTarefa(int id)
        {
            TarefaServiceResponse<List<TarefaModel>> serviceResponse = await _TarefaRepository.DeleteTarefa(id);

            return Ok(serviceResponse);

        }

    }
}
