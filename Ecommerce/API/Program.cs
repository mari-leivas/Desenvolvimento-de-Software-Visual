Console.Clear();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Funcionalidades
//Requisições
// - Endereço/URL
// - Método HTTP
app.MapGet("/", () => "Minha primeira API");

app.MapGet("/funcionalidade", () => "Segunda funcionalidade");

app.MapPost("/funcionalidade", () => "Funcionalidade com POST");

app.Run();
