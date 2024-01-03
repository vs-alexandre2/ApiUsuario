using Microsoft.EntityFrameworkCore;
using ApiUsuario.ApiUsuario.Infrastructure.DataContexts;
using ApiUsuario.ApiUsuario.Domain.Models;
using ApiUsuario.ApiUsuario.Application.Services;

namespace ApiUsuario.ApiUsuario.Infrastructure.Repositorys
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _context;
        public UsuarioRepository(UsuarioDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioServiceResponse<List<UsuarioModel>>> CreateUsuario(UsuarioModel novoUsuario)
        {
            UsuarioServiceResponse<List<UsuarioModel>> serviceResponse = new UsuarioServiceResponse<List<UsuarioModel>>();

            try
            {
                if(novoUsuario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }                

                _context.Add(novoUsuario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Usuarios.ToList();


            }catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<UsuarioServiceResponse<List<UsuarioModel>>> DeleteUsuario(int id)
        {
            UsuarioServiceResponse<List<UsuarioModel>> serviceResponse = new UsuarioServiceResponse<List<UsuarioModel>>();

            try
            {
                UsuarioModel Usuario = _context.Usuarios.FirstOrDefault(x => x.Id == id);

                if (Usuario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }


                _context.Usuarios.Remove(Usuario);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Usuarios.ToList();

            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<UsuarioServiceResponse<UsuarioModel>> GetUsuarioById(int id)
        {
            UsuarioServiceResponse<UsuarioModel> serviceResponse = new UsuarioServiceResponse<UsuarioModel>();

            try
            {
                UsuarioModel Usuario = _context.Usuarios.FirstOrDefault(x => x.Id == id);

                if(Usuario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = Usuario;

            }
            catch(Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<UsuarioServiceResponse<List<UsuarioModel>>> GetUsuarios()
        {
            UsuarioServiceResponse<List<UsuarioModel>> serviceResponse = new UsuarioServiceResponse<List<UsuarioModel>>();

            try
            {
                serviceResponse.Dados = _context.Usuarios.ToList();

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

        public async Task<UsuarioServiceResponse<List<UsuarioModel>>> UpdateUsuario(UsuarioModel editadoUsuario)
        {
            UsuarioServiceResponse<List<UsuarioModel>> serviceResponse = new UsuarioServiceResponse<List<UsuarioModel>>();

            try
            {
                UsuarioModel Usuario = _context.Usuarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoUsuario.Id);

                if (Usuario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }                

                _context.Usuarios.Update(editadoUsuario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Usuarios.ToList();

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
