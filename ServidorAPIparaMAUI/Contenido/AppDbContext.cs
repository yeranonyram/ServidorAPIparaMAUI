using Microsoft.EntityFrameworkCore;
using ServidorAPIparaMAUI.Models;

namespace ServidorAPIparaMAUI.Contenido
{
    public class AppDbContext : DbContext
    {
        public DbSet<Plato> Platos => Set<Plato>();//atributo creado
        //constructor
        public AppDbContext(DbContextOptions<AppDbContext> opciones) : base(opciones)
        { 

        }
    }
}
