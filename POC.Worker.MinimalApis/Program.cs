using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using POC.Worker.MinimalApis;

object response = new
{
    Resposta = $"Worker running at: {DateTimeOffset.Now}"
};

var host = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.Configure(app =>
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/notificacoes", () => response);
            });
        });
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
