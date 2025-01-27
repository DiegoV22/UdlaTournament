using frontend.Models;

namespace frontend.Services.Interfaces
{
    public interface ILoginService
    {
        Task<Usuarios> Login(string gmail, string contrasena);

    }
}
