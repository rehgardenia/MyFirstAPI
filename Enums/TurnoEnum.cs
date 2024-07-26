using System.Text.Json.Serialization;

namespace PrimeiraApi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurnoEnum
    {
        Manha,
        Tarde ,
        Noite
    }
}
