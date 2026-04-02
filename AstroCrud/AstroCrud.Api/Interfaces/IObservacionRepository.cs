using AstroCrud.Api.Models;

namespace AstroCrud.Api.Interfaces
{
    public interface IObservacionRepository
    {
        Task<List<ObservacionAstronomica>> GetAllAsync();
        Task<ObservacionAstronomica?> GetByIdAsync(int id);
        Task<ObservacionAstronomica> CreateAsync(ObservacionAstronomica observacion);
        Task<bool> UpdateAsync(ObservacionAstronomica observacion);
        Task<bool> DeleteAsync(int id);
    }
}