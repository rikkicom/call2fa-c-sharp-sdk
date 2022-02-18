using System.Text.Json.Serialization;

namespace RikkicomClient;

public class CallWithCode 
{
    [JsonPropertyName("phone_number")]
    public string Phone { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("lang")]
    public Language Language { get; set; }

    public CallWithCode(string phone, string code, Language lang) 
        => (Phone, Code, Language) = (phone, code, lang);
}

