using System;
using System.Collections.Generic; // ¡Muy importante! Esto nos da acceso a Queue<> y List<>

namespace CasoWowCentroTutorias
{
    public class GestionTutorias
    {
        // --- ESTRUCTURAS DE DATOS ---
        // Aquí creamos las 2 Colas y 1 Lista que planeamos.
        // Usamos <Estudiante> para decirle a C# que solo guardaremos objetos de esa clase.

        private Queue<Estudiante> Cola_Prioritaria;
        private Queue<Estudiante> Cola_Regular;
        private List<Estudiante> Lista_Historial;

        // "Constructor": Esto se ejecuta automáticamente cuando creamos la GestionTutorias
        public GestionTutorias()
        {
            // Inicializamos nuestras estructuras para que estén listas para usarse
            Cola_Prioritaria = new Queue<Estudiante>();
            Cola_Regular = new Queue<Estudiante>();
            Lista_Historial = new List<Estudiante>();
        }

        // --- OPERACIONES (Métodos de la aplicación) ---

        // 1. Función para registrar un nuevo estudiante
        public void RegistrarEstudiante(string nombre, string asignatura, string tipoSolicitud)
        {
            // Creamos el nuevo estudiante usando la clase Estudiante.cs que hicimos antes
            Estudiante nuevoEstudiante = new Estudiante(nombre, asignatura, tipoSolicitud);

            // Decidimos a qué cola va
            if (tipoSolicitud == "prioritaria")
            {
                Cola_Prioritaria.Enqueue(nuevoEstudiante); // Enqueue = Encolar
                Console.WriteLine($"\n-> ESTUDIANTE: {nombre} registrado en cola PRIORITARIA.");
            }
            else
            {
                Cola_Regular.Enqueue(nuevoEstudiante);
                Console.WriteLine($"\n-> ESTUDIANTE: {nombre} registrado en cola REGULAR.");
            }
        }

        // 2. Función para llamar al siguiente estudiante a ser atendido
        public void AtenderSiguienteEstudiante()
        {
            Estudiante estudianteAtendido = null;

            // 1. Revisamos siempre la cola prioritaria primero
            if (Cola_Prioritaria.Count > 0) // Count es como preguntar "cuántos hay"
            {
                estudianteAtendido = Cola_Prioritaria.Dequeue(); // Dequeue = Desencolar
                Console.WriteLine($"\n*** LLAMANDO (Prioridad): {estudianteAtendido.Nombre} para {estudianteAtendido.Asignatura} ***");
            }
            // 2. Si la prioritaria está vacía, revisamos la regular
            else if (Cola_Regular.Count > 0)
            {
                estudianteAtendido = Cola_Regular.Dequeue();
                Console.WriteLine($"\n*** LLAMANDO (Regular): {estudianteAtendido.Nombre} para {estudianteAtendido.Asignatura} ***");
            }
            // 3. Si ambas están vacías
            else
            {
                Console.WriteLine("\n-> No hay estudiantes en espera.");
                return; // Termina la función aquí
            }

            // 4. Agregamos al historial consolidado
            Lista_Historial.Add(estudianteAtendido);
        }

        // 3. Función para ver quiénes están en espera
        public void VerPendientes()
        {
            Console.WriteLine("\n--- PENDIENTES PRIORITARIOS ---");
            if (Cola_Prioritaria.Count == 0)
            {
                Console.WriteLine("(Vacía)");
            }
            else
            {
                // Imprime cada estudiante en la cola
                foreach (Estudiante est in Cola_Prioritaria)
                {
                    Console.WriteLine($"- {est.Nombre} ({est.Asignatura}) | Llegó a las {est.HoraLlegada.ToShortTimeString()}");
                }
            }

            Console.WriteLine("\n--- PENDIENTES REGULARES ---");
            if (Cola_Regular.Count == 0)
            {
                Console.WriteLine("(Vacía)");
            }
            else
            {
                foreach (Estudiante est in Cola_Regular)
                {
                    Console.WriteLine($"- {est.Nombre} ({est.Asignatura}) | Llegó a las {est.HoraLlegada.ToShortTimeString()}");
                }
            }
        }

        // 4. Función para ver el historial del día
        public void VerHistorial()
        {
            Console.WriteLine("\n--- HISTORIAL DE ATENDIDOS HOY ---");
            if (Lista_Historial.Count == 0)
            {
                Console.WriteLine("(Sin atenciones registradas)");
            }
            else
            {
                foreach (Estudiante est in Lista_Historial)
                {
                    Console.WriteLine($"- {est.Nombre} ({est.Asignatura}) | Tipo: {est.TipoSolicitud}");
                }
            }
        }
    }
}