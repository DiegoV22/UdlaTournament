using frontend.Models;

namespace frontend.Services.Interfaces
{
    public interface IEquiposService
    {
        Task<IEnumerable<Equipos>> GetAllEquiposAsync();
        Task<Equipos> GetEquipoByIdAsync(int id);
        Task AddEquipoAsync(Equipos equipo);
        Task UpdateEquipoAsync(int id, Equipos equipo);
        Task DeleteEquipoAsync(int id);
    }
}
