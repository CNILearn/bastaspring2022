using SignalRStreaming.Hubs;

namespace SignalRStreaming;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSignalR();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<StreamingHub>("/stream");
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("SignalR Streaming Sample");
            });
        });
    }
}
