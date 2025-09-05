using API.Models;

Console.Clear();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Lista com produtos fakes
List<Produto> produtos = new List<Produto>
{
    new Produto { Nome = "Notebook", Quantidade = 10, Preco = 3500.00 },
    new Produto { Nome = "Smartphone", Quantidade = 25, Preco = 2200.00 },
    new Produto { Nome = "Fone de Ouvido", Quantidade = 50, Preco = 199.90 },
    new Produto { Nome = "Monitor", Quantidade = 15, Preco = 899.99 },
    new Produto { Nome = "Teclado Mecânico", Quantidade = 20, Preco = 350.00 }
};

//Funcionalidades
//Requisições
// - Endereço/URL
// - Método HTTP

//Métodos HTTP
// GET: Recupera dados de um servidor sem modificar o recurso.
// POST: Envia dados ao servidor para criar um novo recurso.
// PUT: Atualiza completamente um recurso existente no servidor.
// PATCH: Atualiza parcialmente um recurso existente.
// DELETE: Remove um recurso do servidor.
app.MapGet("/", () => "API de Produtos");

app.MapGet("/api/produto/listar", () =>
{
    return produtos;
});

app.MapPost("/api/produto/cadastrar", (Produto produto) =>
{
    produtos.Add(produto);
});

app.Run();

