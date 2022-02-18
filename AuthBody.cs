using System.Text.Json.Serialization;

namespace RikkicomClient;

internal class AuthBody 
{
    [JsonPropertyName("login")]
    public string Login { get; set; } = null!;

    [JsonPropertyName("password")]
    public string Password { get; set; } = null!;

    internal AuthBody() {}

    internal AuthBody(string login, string password)
        => (Login, Password) = (login, password);
}

