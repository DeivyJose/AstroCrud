using AstroCrud.Api.Data;
using AstroCrud.Api.Interfaces;
using AstroCrud.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AstroCrud.Api.Repositories
{
    public class ObservacionRepository : IObservacionRepository
    {
        private readonly AppDbContext _context;

        public ObservacionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ObservacionAstronomica>> GetAllAsync()
        {
            return await _context.ObservacionesAstronomicas
                .OrderByDescending(o => o.FechaObservacion)
                .ToListAsync();
        }

        public async Task<ObservacionAstronomica?> GetByIdAsync(int id)
        {
            return await _context.ObservacionesAstronomicas.FindAsync(id);
        }

        public async Task<ObservacionAstronomica> CreateAsync(ObservacionAstronomica observacion)
        {
            _context.ObservacionesAstronomicas.Add(observacion);
            await _context.SaveChangesAsync();
            return observacion;
        }

        public async Task<bool> UpdateAsync(ObservacionAstronomica observacion)
        {
            var existente = await _context.ObservacionesAstronomicas.FindAsync(observacion.Id);

            if (existente is null)
                return false;

            existente.Titulo = observacion.Titulo;
            existente.ObjetoCeleste = observacion.ObjetoCeleste;
            existente.FechaObservacion = observacion.FechaObservacion;
            existente.Ubicacion = observacion.Ubicacion;
            existente.Descripcion = observacion.Descripcion;
            existente.TelescopioUsado = observacion.TelescopioUsado;
            existente.EsVisible = observacion.EsVisible;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var observacion = await _context.ObservacionesAstronomicas.FindAsync(id);

            if (observacion is null)
                return false;

            _context.ObservacionesAstronomicas.Remove(observacion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}