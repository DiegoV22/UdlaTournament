using frontend.Models;
using frontend.Services.Interfaces;
using RestSharp;

namespace frontend.Services
{
    public class TorneosService : ITorneosService
    {
        private readonly RestClient _client;

        public TorneosService()
        {
            _client = new RestClient("http://localhost:5234/api"); // URL base de tu API
        }

        public async Task<IEnumerable<Torneos>> GetAllTorneosAsync()
        {
            var request = new RestRequest("Torneos", Method.Get); // Endpoint: /api/Torneos
            var response = await _client.ExecuteAsync<List<Torneos>>(request);

            if (!response.IsSuccessful)
                throw new System.Exception("Error al obtener torneos: " + response.ErrorMessage);

            return response.Data;
        }


        public async Task<Torneos> GetTorneoByIdAsync(int id)
        {
            var request = new RestRequest($"Torneos/{id}", Method.Get); // GET /api/Torneos/{id}
            var response = await _client.ExecuteAsync<Torneos>(request);
            if (!response.IsSuccessful) throw new System.Exception("Error al obtener el torneo: " + response.ErrorMessage);
            return response.Data;
        }

        public async Task AddTorneoAsync(Torneos torneo)
        {
            var request = new RestRequest("Torneos", Method.Post); // POST /api/Torneos
            request.AddJsonBody(new
            {
                NombreTorneo = torneo.NombreTorneo,
                FechaInicio = torneo.FechaInicio,
                FechaFin = torneo.FechaFin,
                Equipos = new List<object>() // Enviar una lista vacía
            });
            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful) throw new System.Exception("Error al agregar torneo: " + response.Content);
        }



        public async Task UpdateTorneoAsync(int id, Torneos torneo)
        {
            var request = new RestRequest($"Torneos/{id}", Method.Put); // PUT /api/Torneos/{id}
            request.AddJsonBody(new
            {
                NombreTorneo = torneo.NombreTorneo,
                FechaInicio = torneo.FechaInicio,
                FechaFin = torneo.FechaFin
            });
            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful) throw new System.Exception("Error al actualizar torneo: " + response.ErrorMessage);
        }

        public async Task DeleteTorneoAsync(int id)
        {
            var request = new RestRequest($"Torneos/{id}", Method.Delete); // DELETE /api/Torneos/{id}
            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful) throw new System.Exception("Error al eliminar torneo: " + response.ErrorMessage);
        }
    }
}
