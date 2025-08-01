using System.Text.Json.Serialization;

namespace AngularWithASP.Server.DTOs
{
    public class BouncyObjects
    {
        [JsonPropertyName("Bouncy")]
        public List<int>? Bouncy { get; set; }
        [JsonPropertyName("Sum")]
        public int Sum { get; set; }
    }
}
