using System.Text.Json.Serialization;

namespace RikkicomClient;

public class CallInPool 
{
    [JsonIgnore]
    public int Id { get; set; }

    [JsonPropertyName("phone_number")]
    public string Phone { get; set; }

    public CallInPool(int id, string phone)
        => (Id, Phone) = (id, phone);
}

