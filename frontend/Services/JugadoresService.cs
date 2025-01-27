using frontend.Models;
using frontend.Services.Interfaces;
using RestSharp;

namespace frontend.Services
{
    public class JugadoresService : IJugadoresService
    {
        private readonly RestClient _client;

        public JugadoresService()
        {
            _client = new RestClient("http://localhost:5234/api"); // URL base de tu API
        }

        public async Task<IEnumerable<Jugadores>> GetAllJugadoresAsync()
        {
            var request = new RestRequest("Jugadores", Method.Get); // GET /api/Jugadores
            var response = await _client.ExecuteAsync<List<Jugadores>>(request);
            if (!response.IsSuccessful) throw new System.Exception("Error al obtener jugadores: " + response.ErrorMessage);
            return response.Data;
        }

        public async Task<Jugadores> GetJugadorByIdAsync(int id)
        {
            var request = new RestRequest($"Jugadores/{id}", Method.Get); // GET /api/Jugadores/{id}
            var response = await _client.ExecuteAsync<Jugadores>(request);
            if (!response.IsSuccessful) throw new System.Exception("Error al obtener el jugador: " + response.ErrorMessage);
            return response.Data;
        }

        public async Task AddJugadorAsync(Jugadores jugador)
        {
            var request = new RestRequest("Jugadores", Method.Post); // POST /api/Jugadores
            request.AddJsonBody(new
            {
                Nombre = jugador.Nombre,
                Apellido = jugador.Apellido,
                Cedula = jugador.Cedula,
                NumCamiseta = jugador.NumCamiseta,
                Lateralidad = jugador.Lateralidad,
                EquipoId = jugador.EquipoId
            });
            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful) throw new System.Exception("Error al agregar jugador: " + response.ErrorMessage);
        }

        public async Task UpdateJugadorAsync(int id, Jugadores jugador)
        {
            var request = new RestRequest($"Jugadores/{id}", Method.Put); // PUT /api/Jugadores/{id}
            request.AddJsonBody(new
            {
                Nombre = jugador.Nombre,
                Apellido = jugador.Apellido,
                Cedula = jugador.Cedula,
                NumCamiseta = jugador.NumCamiseta,
                Lateralidad = jugador.Lateralidad,
                EquipoId = jugador.EquipoId
            });
            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful) throw new System.Exception("Error al actualizar jugador: " + response.ErrorMessage);
        }

        public async Task DeleteJugadorAsync(int id)
        {
            var request = new RestRequest($"Jugadores/{id}", Method.Delete); // DELETE /api/Jugadores/{id}
            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful) throw new System.Exception("Error al eliminar jugador: " + response.ErrorMessage);
        }
    }
}
