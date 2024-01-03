using System.ComponentModel.DataAnnotations;

namespace ApiUsuario.ApiUsuario.Domain.Models
{
    public class HistoricoEscolarModel
    {
        [Key]
        public int IdHistoricoEscolar { get; set; }
        public string Formato { get; set; }
        public string Texto { get; set; }
    }
}
