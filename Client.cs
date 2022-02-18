using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.Net;
using System.Net.Http.Headers;

namespace RikkicomClient;

public class Client 
{	
    private HttpClient client;
    private string? jwt;
    private string? currentLogin, currentPassword;
    private JsonSerializerOptions opts;

    public Client()
    {
        client = new HttpClient();
        opts = new JsonSerializerOptions 
        {
            Converters = 
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
            }    
        };  
        
        client.BaseAddress = new Uri("https://api-call2fa.rikkicom.io");
    }

    private async Task<HttpResponseMessage> Post<T>(string url, T data) 
    {
        return await client.PostAsJsonAsync(url, data, opts); 
    }

    public async Task Auth(string login, string password) 
    {
        ApiException.ThrowIfNull(login, nameof(login));
        ApiException.ThrowIfNull(password, nameof(password));

        currentLogin = login;
        currentPassword = password;
        
        var body = new AuthBody(login, password);
        var response = await Post("v1/auth/", body);

        if(response?.StatusCode == HttpStatusCode.OK)
        {
            var succes = await response.Content.ReadFromJsonAsync<AuthSuccess>();            
            jwt = succes?.Jwt;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
        }
        else if(response is not null)
        {
            var error = await response.Content.ReadFromJsonAsync<ApiError>()!; 
            throw new ApiException(error!.Error);
        }
        else 
        {
            throw new ApiException("Server return nothing");
        }
    }

    public async Task<CallCreated> Call(Call call)
    {
        if (!IsJwtValid(jwt))
        {
            await Auth(currentLogin!, currentPassword!);
        }
            
        var response = await Post("v1/call/", call);

        if(response?.StatusCode == HttpStatusCode.Created) 
        {
            var res = await response!.Content.ReadFromJsonAsync<CallCreated>();
            return res!;
        }
        else if(response is not null)
        {
            var err = await response.Content.ReadFromJsonAsync<ApiError>();
            throw new ApiException(err!.Error);
        }
        else 
        {
            throw new ApiException("Server return nothing");
        }
    }

    public async Task<CallCreated> CallWithCode(CallWithCode call) 
    {
        if (!IsJwtValid(jwt))
        {
            await Auth(currentLogin!, currentPassword!);
        }
        
        var response = await Post("v1/code/call/", call);
        
        if(response?.StatusCode == HttpStatusCode.Created)
        {
            var res = await response!.Content.ReadFromJsonAsync<CallCreated>();
            return res!;
        }
        else if(response is not null)
        {
            var err = await response.Content.ReadFromJsonAsync<ApiError>();
            throw new ApiException(err!.Error);
        }
        else 
        {
            throw new ApiException("Server return nothing");
        }
    }

    public async Task<CallInPoolCreated> CallInPool(CallInPool call)
    {
        if (!IsJwtValid(jwt))
        {
            await Auth(currentLogin!, currentPassword!);
        }

        var response = await Post($"v1/pool/{call.Id}/call/", call);

        if(response?.StatusCode == HttpStatusCode.Created)
        {
            var res = await response!.Content.ReadFromJsonAsync<CallInPoolCreated>();
            return res!;
        }
        else if (response is not null)
        {
            var err = await response.Content.ReadFromJsonAsync<ApiError>();
            throw new ApiException(err!.Error);
        }
        else 
        {
            throw new ApiException("Server return nothing");
        }
    }

    public async Task<CallInfo> GetCallInfo(string id) 
    {
        if (!IsJwtValid(jwt))
        {
            await Auth(currentLogin!, currentPassword!);
        }

        var response = await client.GetAsync($"v1/call/{id}/");
        if(response?.StatusCode == HttpStatusCode.OK)
        {
            var res = await response!.Content.ReadFromJsonAsync<CallInfo>();
            return res!;
        }
        else if(response is not null) 
        {
            var err = await response.Content.ReadFromJsonAsync<ApiError>();
            throw new ApiException(err!.Error);
        }
        else 
        {
            throw new ApiException("Server return nothing");
        }
    }

    private bool IsJwtValid(string? jwt)
    {
        ArgumentNullException.ThrowIfNull(jwt, nameof(jwt));

        var start = jwt.IndexOf('.') + 1;
        var len = jwt.LastIndexOf('.') - start;
        var sub = jwt.Substring(start, len);
        var json = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(sub));
        var doc = JsonDocument.Parse(json);
        var seconds = doc.RootElement.GetProperty("exp").GetInt64();
        var date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(seconds);

        return DateTime.UtcNow.AddSeconds(1) < date;
    }
}
