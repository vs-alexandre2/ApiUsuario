using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiTarefa.ApiTarefa.Domain.Enums;

namespace ApiTarefa.ApiTarefa.Domain.Models
{
    public class TarefaModel
    {
        [Key]
        [Column("IdTarefa")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Responsavel { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataConclusao { get; set; }
        public SituacaoEnum Situacao { get; set; }        
    }
}
