using Microsoft.EntityFrameworkCore;
using ApiTarefa.ApiTarefa.Infrastructure.DataContexts;
using ApiTarefa.ApiTarefa.Domain.Models;
using ApiTarefa.ApiTarefa.Application.Services;

namespace ApiTarefa.ApiTarefa.Infrastructure.Repositorys
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly TarefaDbContext _context;
        public TarefaRepository(TarefaDbContext context)
        {
            _context = context;
        }

        public async Task<TarefaServiceResponse<List<TarefaModel>>> CreateTarefa(TarefaModel novoTarefa)
        {
            TarefaServiceResponse<List<TarefaModel>> serviceResponse = new TarefaServiceResponse<List<TarefaModel>>();

            try
            {
                if(novoTarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }                

                _context.Add(novoTarefa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Tarefas.ToList();


            }catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<TarefaServiceResponse<List<TarefaModel>>> DeleteTarefa(int id)
        {
            TarefaServiceResponse<List<TarefaModel>> serviceResponse = new TarefaServiceResponse<List<TarefaModel>>();

            try
            {
                TarefaModel Tarefa = _context.Tarefas.FirstOrDefault(x => x.Id == id);

                if (Tarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }


                _context.Tarefas.Remove(Tarefa);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Tarefas.ToList();

            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<TarefaServiceResponse<TarefaModel>> GetTarefaById(int id)
        {
            TarefaServiceResponse<TarefaModel> serviceResponse = new TarefaServiceResponse<TarefaModel>();

            try
            {
                TarefaModel Tarefa = _context.Tarefas.FirstOrDefault(x => x.Id == id);

                if(Tarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = Tarefa;

            }
            catch(Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<TarefaServiceResponse<List<TarefaModel>>> GetTarefas()
        {
            TarefaServiceResponse<List<TarefaModel>> serviceResponse = new TarefaServiceResponse<List<TarefaModel>>();

            try
            {
                serviceResponse.Dados = _context.Tarefas.ToList();

                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }


            }catch(Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }

        public async Task<TarefaServiceResponse<List<TarefaModel>>> UpdateTarefa(TarefaModel editadoTarefa)
        {
            TarefaServiceResponse<List<TarefaModel>> serviceResponse = new TarefaServiceResponse<List<TarefaModel>>();

            try
            {
                TarefaModel Tarefa = _context.Tarefas.AsNoTracking().FirstOrDefault(x => x.Id == editadoTarefa.Id);

                if (Tarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }                

                _context.Tarefas.Update(editadoTarefa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Tarefas.ToList();

            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
