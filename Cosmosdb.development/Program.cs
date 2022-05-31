using Cosmosdb.development.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Startup.Main());

app.Run();
