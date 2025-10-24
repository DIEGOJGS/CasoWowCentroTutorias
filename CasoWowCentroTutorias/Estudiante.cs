using System;

namespace CasoWowCentroTutorias
{
    // Esta es nuestra plantilla para crear objetos "Estudiante"
    public class Estudiante
    {
        // Propiedades del estudiante
        // { get; set; } permite obtener y establecer el valor
        public string Nombre { get; set; }
        public string Asignatura { get; set; }
        public string TipoSolicitud { get; set; }
        public DateTime HoraLlegada { get; set; }

        // Un "Constructor": un método especial que se ejecuta al crear un nuevo estudiante
        // Nos obliga a pedir estos datos siempre que creemos uno.
        public Estudiante(string nombre, string asignatura, string tipoSolicitud)
        {
            Nombre = nombre;
            Asignatura = asignatura;
            TipoSolicitud = tipoSolicitud;
            HoraLlegada = DateTime.Now; // Guarda la hora exacta en que se creó
        }
    }
}
