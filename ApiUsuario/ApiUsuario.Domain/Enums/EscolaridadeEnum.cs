using System.Text.Json.Serialization;

namespace ApiUsuario.ApiUsuario.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EscolaridadeEnum
    {
        Infantil = 1,
        Fundamental = 2,
        Medio = 3,
        Superior = 4
    }
}
