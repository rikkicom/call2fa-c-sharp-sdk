using System.Text.Json.Serialization;

namespace RikkicomClient;

internal class AuthSuccess 
{
    [JsonPropertyName("jwt")]
    public string Jwt { get; set; } = default!;
}

