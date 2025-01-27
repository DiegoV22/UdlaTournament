using frontend.Models;
using frontend.Services.Interfaces;
using RestSharp;

namespace frontend.Services
{
    public class LoginService : ILoginService
    {
        private readonly RestClient _client;

        public LoginService()
        {
            _client = new RestClient("http://localhost:5070/api/Usuarios");
        }

        public async Task<Usuarios> Login(string gmail, string contrasena)
        {
            var request = new RestRequest("login", Method.Post);
            request.AddJsonBody(new { Gmail = gmail, Contrasena = contrasena });

            var response = await _client.ExecuteAsync<Usuarios>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }

            return null;
        }
    }
}