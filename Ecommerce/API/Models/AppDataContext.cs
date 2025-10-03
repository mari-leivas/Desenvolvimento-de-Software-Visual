using System;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

//Entity Framework: Code First
//1 - Implementou a herança da classe DbContext
//2 - Criou as propriedades que vão informar quais as classes
//vão virar tabelas no banco
//3 - Configurar qual o banco utilizado e a string de conexão
public class AppDataContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Ecommerce.db");
    }

}
