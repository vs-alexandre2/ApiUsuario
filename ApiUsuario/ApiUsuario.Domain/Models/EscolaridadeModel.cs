using System.ComponentModel.DataAnnotations;

namespace ApiUsuario.ApiUsuario.Domain.Models
{
    public class EscolaridadeModel
    {
        [Key]
        public int IdEscolaridade { get; set; }
        public string Escolaridade { get; set; }

    }
}
