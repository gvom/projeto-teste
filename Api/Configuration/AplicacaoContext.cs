using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace Api.Configuration
{
    public class AplicacaoContext : DbContext
    {
    public AplicacaoContext(DbContextOptions<AplicacaoContext> options)
        : base(options)
    { }

    public DbSet<Usuario> Usuario { get; set; }

    public DbSet<Tarefa> Tarefa { get; set; }
    
    }
}