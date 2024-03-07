using ApiTarefa.ApiTarefa.Application.Services;
using ApiTarefa.ApiTarefa.Domain.Models;

namespace ApiTarefa.ApiTarefa.Infrastructure.Repositorys
{
    public interface ITarefaRepository
    {
        Task<TarefaServiceResponse<List<TarefaModel>>> GetTarefas();
        Task<TarefaServiceResponse<List<TarefaModel>>> CreateTarefa(TarefaModel novoTarefa);
        Task<TarefaServiceResponse<TarefaModel>> GetTarefaById(int id);
        Task<TarefaServiceResponse<List<TarefaModel>>> UpdateTarefa(TarefaModel editadoTarefa);
        Task<TarefaServiceResponse<List<TarefaModel>>> DeleteTarefa(int id);
    }
}
