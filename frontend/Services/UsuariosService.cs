using frontend.Models;
using frontend.Services.Interfaces;
using RestSharp;

public class UsuariosService : IUsuariosService
{
    private readonly RestClient _client;

    public UsuariosService()
    {
        _client = new RestClient("http://localhost:5070/api/Usuarios"); // URL base de tu API de Usuarios
    }

    public async Task<IEnumerable<Usuarios>> GetAllUsuariosAsync()
    {
        var request = new RestRequest("", Method.Get); // Nota el uso de Method.Get
        var response = await _client.ExecuteAsync<List<Usuarios>>(request);
        if (!response.IsSuccessful) throw new System.Exception("Error al obtener usuarios: " + response.ErrorMessage);
        return response.Data;
    }

    public async Task<Usuarios> GetUsuarioByIdAsync(int id)
    {
        var request = new RestRequest($"{id}", Method.Get); // GET /api/Usuarios/{id}
        var response = await _client.ExecuteAsync<Usuarios>(request);
        if (!response.IsSuccessful) throw new System.Exception("Error al obtener el usuario: " + response.ErrorMessage);
        return response.Data;
    }

    public async Task AddUsuarioAsync(Usuarios usuario)
    {
        var request = new RestRequest("", Method.Post); // POST /api/Usuarios
        request.AddJsonBody(usuario);
        var response = await _client.ExecuteAsync(request);
        if (!response.IsSuccessful) throw new System.Exception("Error al agregar usuario: " + response.ErrorMessage);
    }

    public async Task UpdateUsuarioAsync(int id, Usuarios usuario)
    {
        var request = new RestRequest($"{id}", Method.Put); // PUT /api/Usuarios/{id}
        request.AddJsonBody(usuario);
        var response = await _client.ExecuteAsync(request);
        if (!response.IsSuccessful) throw new System.Exception("Error al actualizar usuario: " + response.ErrorMessage);
    }

    public async Task DeleteUsuarioAsync(int id)
    {
        var request = new RestRequest($"{id}", Method.Delete); // DELETE /api/Usuarios/{id}
        var response = await _client.ExecuteAsync(request);
        if (!response.IsSuccessful) throw new System.Exception("Error al eliminar usuario: " + response.ErrorMessage);
    }
}
