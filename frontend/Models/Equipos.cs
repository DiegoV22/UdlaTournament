namespace frontend.Models
{
    public class Equipos
    {
        public int Id { get; set; } // Identificador del equipo

        public string NombreEquipo { get; set; } // Nombre del equipo

        public int TorneoId { get; set; } // Clave foránea al torneo
    }
}
