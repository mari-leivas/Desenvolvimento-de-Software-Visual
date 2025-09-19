using System;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

//AppDataContext é a classe que representa o DB na aplicação
//1 - Criar a herança da classe DbContext
//2 - Criar os atributos que vão representar as tabelas do DB
//3 - Configurar as informações do seu banco de dados
public class AppDataContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Ecommerce.db");
    }
}
