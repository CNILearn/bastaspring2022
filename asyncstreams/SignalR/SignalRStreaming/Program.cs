using SignalRStreaming.Hubs;

var builder = WebApplication.CreateBuilder();
builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapHub<StreamingHub>("/stream");

app.MapGet("/", () => "Use SignalR");

app.Run();

