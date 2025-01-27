using frontend.Models;
using frontend.Services.Interfaces;
using RestSharp;

namespace frontend.Services
{
    public class EquiposService : IEquiposService
    {
        private readonly RestClient _client;

        public EquiposService()
        {
            _client = new RestClient("http://localhost:5234/api/"); // URL base de tu API
        }

        public async Task<IEnumerable<Equipos>> GetAllEquiposAsync()
        {
            var request = new RestRequest("Equipos", Method.Get); // GET /api/Equipos
            var response = await _client.ExecuteAsync<List<Equipos>>(request);
            if (!response.IsSuccessful) throw new System.Exception("Error al obtener equipos: " + response.ErrorMessage);
            return response.Data;
        }

        public async Task<Equipos> GetEquipoByIdAsync(int id)
        {
            var request = new RestRequest($"Equipos/{id}", Method.Get); // GET /api/Equipos/{id}
            var response = await _client.ExecuteAsync<Equipos>(request);
            if (!response.IsSuccessful) throw new System.Exception("Error al obtener el equipo: " + response.ErrorMessage);
            return response.Data;
        }

        public async Task AddEquipoAsync(Equipos equipo)
        {
            var request = new RestRequest("Equipos", Method.Post); // POST /api/Equipos
            request.AddJsonBody(new
            {
                NombreEquipo = equipo.NombreEquipo,
                TorneoId = equipo.TorneoId,
                Jugadores = new List<object>() // Enviar una lista vacía explícitamente
            });
            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful)
                throw new System.Exception("Error al agregar equipo: " + response.ErrorMessage);
        }


        public async Task UpdateEquipoAsync(int id, Equipos equipo)
        {
            var request = new RestRequest($"Equipos/{id}", Method.Put); // PUT /api/Equipos/{id}
            request.AddJsonBody(new
            {
                NombreEquipo = equipo.NombreEquipo,
                TorneoId = equipo.TorneoId
            });
            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful) throw new System.Exception("Error al actualizar equipo: " + response.ErrorMessage);
        }

        public async Task DeleteEquipoAsync(int id)
        {
            var request = new RestRequest($"Equipos/{id}", Method.Delete); // DELETE /api/Equipos/{id}
            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful) throw new System.Exception("Error al eliminar equipo: " + response.ErrorMessage);
        }
    }
}
