using API.Models;
using Microsoft.AspNetCore.Mvc;

Console.Clear();
var builder = WebApplication.CreateBuilder(args);

//Adicionar o serviço de banco de dados na aplicação
builder.Services.AddDbContext<AppDataContext>();

builder.Services.AddCors(options =>
    options.AddPolicy("Acesso Total",
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);

var app = builder.Build();

//Lista com produtos fixos
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
// - Dados: rota (URL) e corpo (opcional)

//Respostas
// - Código de status HTTP
// - Corpo/Dados

//Métodos HTTP
// GET: Buscar dados de um servidor sem modificar o recurso.
// POST: Enviar dados ao servidor para criar um novo recurso.
// PUT: Atualizar completamente um recurso existente no servidor.
// PATCH: Atualizar parcialmente um recurso existente.
// DELETE: Remover um recurso do servidor.

//Códigos de Status HTTP
// 2xx (Sucesso)
// 200 OK: A solicitação foi bem-sucedida e o servidor retornou a resposta esperada.
// 201 Created: A solicitação foi bem-sucedida e um novo recurso foi criado como resultado (geralmente usado em POST).
// 204 No Content: A solicitação foi bem-sucedida, mas não há conteúdo para retornar (geralmente em respostas de DELETE ou PUT sem necessidade de retornar dados).
// 4xx (Erro do Cliente)
// 400 Bad Request: A solicitação é inválida ou malformada; o servidor não conseguiu entendê-la.
// 401 Unauthorized: O cliente não tem permissão para acessar o recurso, geralmente porque precisa autenticar-se.
// 404 Not Found: O recurso solicitado não foi encontrado no servidor.
// 409 Conflict: A solicitação não pôde ser processada devido a um conflito, geralmente relacionado a dados (como tentar criar um recurso com o mesmo identificador que outro já existe).

//Raiz da aplicação
app.MapGet("/", () => "API de Produtos");

//Listar produtos
app.MapGet("/api/produto/listar", ([FromServices] AppDataContext ctx) =>
{
    List<Produto> produtos = ctx.Produtos.ToList();
    double total = 0;
    foreach(Produto produto in produtos)
    {
        total = total + produto.Preco;
    }

    //Validar se existe alguma coisa dentro da lista    
    if (ctx.Produtos.Any())
    {
        return Results.Ok(ctx.Produtos.ToList());
    }
    return Results.BadRequest("Lista vazia");
});

//Cadastrar produto
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto,
    [FromServices] AppDataContext ctx) =>
{
    Produto? resultado =
        ctx.Produtos.FirstOrDefault(x => x.Nome == produto.Nome);
    if (resultado is not null)
    {
        return Results.Conflict("Produto já existente!");
    }
    ctx.Produtos.Add(produto);
    ctx.SaveChanges();
    return Results.Created("", produto);
});

//Buscar produto pelo id
app.MapGet("/api/produto/buscar/{id}", ([FromRoute] string id,
    [FromServices] AppDataContext ctx) =>
{
    //Expressão lambda
    // Produto produto = produtos.FirstOrDefault(x => x.Nome.Contains(nome));
    Produto? resultado = ctx.Produtos.Find(id);
    if (resultado is null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    return Results.Ok(resultado);
});

//Remover produto pelo id
app.MapDelete("/api/produto/remover/{id}", ([FromRoute] string id,
    [FromServices] AppDataContext ctx) =>
{
    Produto? resultado = ctx.Produtos.Find(id);
    if (resultado is null)
    {
        return Results.NotFound("Produto não encontrado");
    }   
    ctx.Produtos.Remove(resultado);
    ctx.SaveChanges();
    return Results.Ok(resultado);
});

//Alterar produto pelo id
app.MapPatch("/api/produto/alterar/{id}", ([FromRoute] string id,
    [FromBody] Produto produtoAlterado,
    [FromServices] AppDataContext ctx) =>
{   
    Produto? resultado = ctx.Produtos.Find(id);
    if (resultado is null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    resultado.Nome = produtoAlterado.Nome;
    resultado.Quantidade = produtoAlterado.Quantidade;
    resultado.Preco = produtoAlterado.Preco;
    ctx.Produtos.Update(resultado);
    ctx.SaveChanges();
    return Results.Ok(resultado);
});

app.UseCors("Acesso Total");

app.Run();