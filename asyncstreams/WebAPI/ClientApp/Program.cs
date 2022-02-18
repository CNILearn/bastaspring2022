﻿using AsyncStreaming.Shared;

using System.Text.Json;
Console.WriteLine("Wait for service - press return to continue");
Console.ReadLine();

using HttpClient httpClient = new();
httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

// use in-memory data
using HttpResponseMessage response = await httpClient.GetAsync("https://localhost:5001/api/ADevice", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

response.EnsureSuccessStatusCode();
using Stream responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

await foreach (DeviceData? data in JsonSerializer.DeserializeAsyncEnumerable<DeviceData>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, DefaultBufferSize = 128 }))
{
    Console.WriteLine(data);

}

// use service accessing database
//using HttpResponseMessage response = await httpClient.GetAsync("https://localhost:5001/api/UseEFCore", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

//response.EnsureSuccessStatusCode();
//using Stream responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

//await foreach (SomeData? data in JsonSerializer.DeserializeAsyncEnumerable<SomeData>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, DefaultBufferSize = 128 }))
//{
//    Console.WriteLine(data);

//}

Console.ReadLine();
