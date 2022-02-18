using System.Text.Json.Serialization;

namespace RikkicomClient;

public class Call 
{
    [JsonPropertyName("phone_number")]
    public string Phone { get; set; }

    [JsonPropertyName("callback_url")]
    public string Callback { get; set; }

    public Call(string phone, string callback) 
        => (Phone, Callback) = (phone, callback);
}

