using AsyncStreaming.Shared;

using System.Text.Json;
Console.WriteLine("...");
Console.ReadLine();

using HttpClient httpClient = new();
httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

// v1
using HttpResponseMessage response = await httpClient.GetAsync("https://localhost:5001/api/ADevice", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

response.EnsureSuccessStatusCode();
using Stream responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

await foreach (SomeData? data in JsonSerializer.DeserializeAsyncEnumerable<SomeData>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, DefaultBufferSize = 128 }))
{
    Console.WriteLine(data);

}

// v2
//using HttpResponseMessage response = await httpClient.GetAsync("https://localhost:5001/api/UseEFCore", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

//response.EnsureSuccessStatusCode();
//using Stream responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

//await foreach (SomeData? data in JsonSerializer.DeserializeAsyncEnumerable<SomeData>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, DefaultBufferSize = 128 }))
//{
//    Console.WriteLine(data);

//}

Console.ReadLine();
