# C# SDK for Call2FA

This is a library you can use for Rikkicom's service named as Call2FA 
(a phone call as the second factor in an authorization pipeline).

## Installation

Just install as the following:

```
dotnet add reference /path/to/project/RikkicomClient.csproj
```

## Example

This simple code makes a new call to the +380631010121 number:

```csharp
using RikkicomClient;

// create the client
var client = new Client();

// authentication
await client.Auth("login", "password");

// new call via "press 1"
CallCreated call = await client.Call(new Call("+380631010121", "https://httpbin.org"));

// new call with a code
CallCreated call = await client.CallWithCode(new CallWithCode("+380631010121", "1234w", Language.Uk)); // or Language.Ru

// new call in a pool
CallInPoolCreated call = await client.CallInPool(new CallInPool("POOL_ID", "+380631010121"));

// get information about a call
CallInfo = await client.GetCallInfo("12345");
```

- Documentation: https://api.rikkicom.io/docs/en/call2fa/
- Documentation (in Ukrainian): https://api.rikkicom.io/docs/uk/call2fa/
- Documentation (in Russian): https://api.rikkicom.io/docs/ru/call2fa/
