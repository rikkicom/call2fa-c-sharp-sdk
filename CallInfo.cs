using System.Text.Json.Serialization;

namespace RikkicomClient;

public class CallInfo 
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("state")]
    public string State { get; set; } = default!;

    [JsonPropertyName("phone_number")]
    public string Phone { get; set; } = default!;

    [JsonPropertyName("phone_number_raw")]
    public string PhoneRaw { get; set; } = default!;

    [JsonPropertyName("region_code")]
    public string RegionCode { get; set; } = default!;

    [JsonPropertyName("callback_url")]
    public string Callback { get; set; } = default!;

    [JsonPropertyName("ivr_answer")]
    public string IvrAnswer { get; set; } = default!; 

    [JsonPropertyName("is_called")]
    public bool IsCalled { get; set; }

    [JsonPropertyName("is_callback_sent")]
    public bool IsCallbackSent { get; set; }

    [JsonPropertyName("is_error")]
    public bool IsError { get; set; }

    [JsonPropertyName("error_info")]
    public string ErrorInfo { get; set; } = default!;

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; } = default!;

    [JsonPropertyName("created_at_unix")]
    public long CreatedAtUnix { get; set; }

    [JsonPropertyName("finished_at")]
    public string FinishedAt { get; set; } = default!;

    [JsonPropertyName("finished_at_unix")]
    public long FinishedAtUnix { get; set; }

    [JsonPropertyName("called_at")]
    public string CalledAt { get; set; } = default!;

    [JsonPropertyName("called_at_unix")]
    public long CalledAtUnix { get; set; }

    [JsonPropertyName("answer_at")]
    public string AnswerAt { get; set; } = default!;

    [JsonPropertyName("answer_at_unix")]
    public long AnswerAtUnix { get; set; }
}

