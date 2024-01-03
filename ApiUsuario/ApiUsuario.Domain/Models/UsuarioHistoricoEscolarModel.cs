using System.ComponentModel.DataAnnotations;

namespace ApiUsuario.ApiUsuario.Domain.Models
{
    public class UsuarioHistoricoEscolarModel
    {
        [Key]
        public int IdUsuarioHistoricoEscolar { get; set; }
        public int IdUsuario { get; set; }
        public int IdHistoricoEscolar { get; set; }
    }
}
