using HostedServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<HostedJob>();

var app = builder.Build();

app.MapGet("/", () => "Olá, estou rodando uma aplicação em segundo plano, com serviço hospedado...");

app.Run();
