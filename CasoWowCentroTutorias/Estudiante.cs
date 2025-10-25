using System;

namespace CasoWowCentroTutorias
{
    public class Estudiante
    {
        // --- PROPIEDADES NUEVAS PARA LA BASE DE DATOS ---

        // 1. Clave Primaria (PK) para la base de datos.
        public int Id { get; set; }

        // 2. Estado para saber si está en cola o ya fue atendido.
        public string Status { get; set; }

        // --- PROPIEDADES QUE YA TENÍAMOS ---
        public string Nombre { get; set; }
        public string Asignatura { get; set; }
        public string TipoSolicitud { get; set; }
        public DateTime HoraLlegada { get; set; }

        // Constructor vacío (necesario para Entity Framework)
        public Estudiante() { }

        // Constructor que ya usábamos
        public Estudiante(string nombre, string asignatura, string tipoSolicitud)
        {
            Nombre = nombre;
            Asignatura = asignatura;
            TipoSolicitud = tipoSolicitud;
            HoraLlegada = DateTime.Now;
            Status = "En Espera"; // ¡Estado inicial!
        }
    }
}