using Microsoft.EntityFrameworkCore;

namespace MarlinMotors.Models;

public class MarlinMotorsContext : DbContext
{
    

    public DbSet<Carro> Carros { get; set; }
    public DbSet<Venda> Vendas { get; set; }
    public DbSet<Van> Vans { get; set; }
    public DbSet<Moto> Motos { get; set; }

    public MarlinMotorsContext(DbContextOptions<MarlinMotorsContext> options) : base(options)
    {}
}