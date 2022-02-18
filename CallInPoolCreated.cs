using System.Text.Json.Serialization;

namespace RikkicomClient;

public class CallInPoolCreated 
{
    [JsonPropertyName("call_id")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("phone_number")]
    public string Phone { get; set; } = default!;

    [JsonPropertyName("code")]
    public string Code { get; set; } = default!;
}

