using frontend.Models;

namespace frontend.Services.Interfaces
{
    public interface IJugadoresService
    {
        Task<IEnumerable<Jugadores>> GetAllJugadoresAsync();
        Task<Jugadores> GetJugadorByIdAsync(int id);
        Task AddJugadorAsync(Jugadores jugador);
        Task UpdateJugadorAsync(int id, Jugadores jugador);
        Task DeleteJugadorAsync(int id);
    }
}
