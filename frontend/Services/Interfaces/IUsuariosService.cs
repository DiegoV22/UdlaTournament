using frontend.Models;

namespace frontend.Services.Interfaces
{
    public interface IUsuariosService
    {
        Task<IEnumerable<Usuarios>> GetAllUsuariosAsync();
        Task<Usuarios> GetUsuarioByIdAsync(int id);
        Task AddUsuarioAsync(Usuarios usuario);
        Task UpdateUsuarioAsync(int id, Usuarios usuario);
        Task DeleteUsuarioAsync(int id);
    }
}
