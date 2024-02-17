using Microsoft.EntityFrameworkCore;
using System;

namespace TrabalhoFinalCsharp.Data
{
    using TrabalhoFinalCsharp.Models;

    public class BancoContext : DbContext
    {
        public DbSet<ProdutoModel>? Produtos { get; set; }
        public DbSet<ClienteModel>? Cliente { get; set; }
        public DbSet<FuncionarioModel>? Funcionario { get; set; }

        public BancoContext(DbContextOptions<BancoContext> options)
            : base(options)
        {
        }
        
    }
}
