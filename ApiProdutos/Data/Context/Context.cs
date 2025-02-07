using ApiProdutos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Data.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Produtos> Produtos { get; set; }
    }  
}
