using Newtonsoft.Json;

namespace TestBackEndApi.Infrastructure.CrossCutting.Configuration
{
    public sealed class AppConfiguration
    {
        [JsonProperty("ConnectionStrings")]
        public ConnectionStrings Connection { get; set; }

        [JsonProperty("ParameterSettings")]
        public ParameterSettings Parameter { get; set; }
    }

    public sealed class ConnectionStrings
    {
        [JsonProperty("DefaultConnection")]
        public string DefaultConnection { get; set; }
    }

    public sealed class ParameterSettings
    {
        [JsonProperty("TotalAlunosPorTurma")]
        public int TotalAlunosPorTurma { get; set; }
    }
}
