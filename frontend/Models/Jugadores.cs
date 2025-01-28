namespace frontend.Models
{
    public class Jugadores
    {
        public int Id { get; set; } // Identificador del jugador

        public string Nombre { get; set; } // Nombre del jugador

        public string Apellido { get; set; } // Apellido del jugador

        public string Cedula { get; set; } // Cédula del jugador

        public int NumCamiseta { get; set; } // Número de camiseta del jugador

        public string Lateralidad { get; set; } // Lateralidad (Derecha/Izquierda) del jugador

        public int? EquipoId { get; set; } // Clave foránea al equipo
    }
}
