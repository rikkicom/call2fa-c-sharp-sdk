using System.Text.Json.Serialization;

namespace RikkicomClient;

public class CallCreated 
{
    [JsonPropertyName("call_id")]
    public string Id { get; set; } = default!;
}

