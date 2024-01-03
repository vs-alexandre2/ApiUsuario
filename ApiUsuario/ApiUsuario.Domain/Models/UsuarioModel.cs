using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiUsuario.ApiUsuario.Domain.Enums;

namespace ApiUsuario.ApiUsuario.Domain.Models
{
    public class UsuarioModel
    {
        [Key]
        [Column("IdUsuario")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        [Column("IdEscolaridade")]
        public EscolaridadeEnum Escolaridade { get; set; }        
    }
}
