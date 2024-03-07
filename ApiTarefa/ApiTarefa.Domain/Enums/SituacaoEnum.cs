using System.Text.Json.Serialization;

namespace ApiTarefa.ApiTarefa.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SituacaoEnum
    {
        Criada = 1,
        Iniciada = 2,
        Concluida = 3
    }
}
