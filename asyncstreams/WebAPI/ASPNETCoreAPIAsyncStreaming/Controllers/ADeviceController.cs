using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AsyncStreaming.Shared;

namespace ASPNETCoreAPIAsyncStreaming.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ADeviceController : ControllerBase
{
    [HttpGet]
    public async IAsyncEnumerable<SomeData> GetSomeData()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new SomeData($"text {Random.Shared.Next(200)}", i);
            await Task.Delay(100);
        }
    }
}
