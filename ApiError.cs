using System.Text.Json.Serialization;

namespace RikkicomClient;

internal class ApiError 
{
    [JsonPropertyName("error")]
    public string Error { get; set; } = default!;

    public ApiException Wrap() => new ApiException(Error);
}
