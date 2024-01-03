using ApiUsuario.ApiUsuario.Application.Services;
using ApiUsuario.ApiUsuario.Domain.Models;

namespace ApiUsuario.ApiUsuario.Infrastructure.Repositorys
{
    public interface IUsuarioRepository
    {
        Task<UsuarioServiceResponse<List<UsuarioModel>>> GetUsuarios();
        Task<UsuarioServiceResponse<List<UsuarioModel>>> CreateUsuario(UsuarioModel novoUsuario);
        Task<UsuarioServiceResponse<UsuarioModel>> GetUsuarioById(int id);
        Task<UsuarioServiceResponse<List<UsuarioModel>>> UpdateUsuario(UsuarioModel editadoUsuario);
        Task<UsuarioServiceResponse<List<UsuarioModel>>> DeleteUsuario(int id);
    }
}
