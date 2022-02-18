namespace RikkicomClient;

public class ApiException : Exception  
{ 
    public readonly string Error;

    public ApiException(string msg) 
    {
        Error = msg;
    }

    public static void ThrowIfNull(object value, string name)
    {
        if (value is null)
        {
            throw new ApiException($"{name} is null");
        }
    }
}

