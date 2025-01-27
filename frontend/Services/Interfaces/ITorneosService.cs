using frontend.Models;

namespace frontend.Services.Interfaces
{
    public interface ITorneosService
    {
        Task<IEnumerable<Torneos>> GetAllTorneosAsync();
        Task<Torneos> GetTorneoByIdAsync(int id);
        Task AddTorneoAsync(Torneos torneo);
        Task UpdateTorneoAsync(int id, Torneos torneo);
        Task DeleteTorneoAsync(int id);
    }

}
