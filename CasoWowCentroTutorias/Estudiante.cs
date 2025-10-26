using System; // Importa el espacio de nombres base de .NET para tipos esenciales (como DateTime).

namespace CasoWowCentroTutorias // Define el espacio de nombres (contenedor) del proyecto.
{
    public class Estudiante // Define la clase 'Estudiante' que representa a un alumno en el sistema.
    {
        // --- PROPIEDADES NUEVAS PARA LA BASE DE DATOS ---

        // 1. Clave Primaria (PK) para la base de datos.
        public int Id { get; set; } // Propiedad única que identifica al estudiante (clave primaria).

        // 2. Estado para saber si está en cola o ya fue atendido.
        public string Status { get; set; } // Propiedad que indica el estado actual del estudiante ("En Espera", "Atendido", etc.).

        // --- PROPIEDADES QUE YA TENÍAMOS ---
        public string Nombre { get; set; } // Nombre completo del estudiante.
        public string Asignatura { get; set; } // Materia para la que solicita la tutoría.
        public string TipoSolicitud { get; set; } // Tipo de ayuda requerida (ej: "Duda", "Repaso").
        public DateTime HoraLlegada { get; set; } // Momento exacto en que el estudiante se puso en la cola.

        // Constructor vacío (necesario para Entity Framework)
        public Estudiante() { } // Constructor por defecto (sin parámetros), necesario para la deserialización y ORMs.

        // Constructor que ya usábamos
        public Estudiante(string nombre, string asignatura, string tipoSolicitud) // Constructor para crear un nuevo estudiante con datos iniciales.
        {
            Nombre = nombre; // Asigna el nombre provisto al objeto.
            Asignatura = asignatura; // Asigna la asignatura provista al objeto.
            TipoSolicitud = tipoSolicitud; // Asigna el tipo de solicitud provisto al objeto.
            HoraLlegada = DateTime.Now; // Establece la hora actual como la hora de llegada.
            Status = "En Espera"; // Establece el estado inicial por defecto.
        }
    }
}
