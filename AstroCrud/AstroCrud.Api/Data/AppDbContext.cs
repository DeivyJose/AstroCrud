using Microsoft.EntityFrameworkCore;
using AstroCrud.Api.Models;

namespace AstroCrud.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ObservacionAstronomica> ObservacionesAstronomicas => Set<ObservacionAstronomica>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ObservacionAstronomica>().HasData(
                new ObservacionAstronomica
                {
                    Id = 1,
                    Titulo = "Luna llena sobre la ciudad",
                    ObjetoCeleste = "Luna",
                    FechaObservacion = new DateTime(2026, 3, 20, 20, 30, 0),
                    Ubicacion = "Santo Domingo",
                    Descripcion = "Observación nocturna con cielo despejado.",
                    TelescopioUsado = "Celestron 130EQ",
                    EsVisible = true
                },
                new ObservacionAstronomica
                {
                    Id = 2,
                    Titulo = "Júpiter y sus lunas",
                    ObjetoCeleste = "Júpiter",
                    FechaObservacion = new DateTime(2026, 3, 24, 21, 15, 0),
                    Ubicacion = "La Vega",
                    Descripcion = "Se pudieron observar varias lunas galileanas.",
                    TelescopioUsado = "Sky-Watcher 150P",
                    EsVisible = true
                }
            );
        }
    }
}