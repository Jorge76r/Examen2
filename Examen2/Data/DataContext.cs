using Microsoft.EntityFrameworkCore;
using Examen2.Models;
using System.Globalization;

namespace Examen2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Tareas> Tareas { get; set; }

    }
}
