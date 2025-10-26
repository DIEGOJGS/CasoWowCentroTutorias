using System; // Importa tipos de sistema básicos.
using System.Collections.Generic; // Importa estructuras de datos como Queue y List.
using System.Linq; // Importa LINQ, necesario para hacer consultas a la Base de Datos (BD).

namespace CasoWowCentroTutorias // Define el espacio de nombres del proyecto.
{
    public class GestionTutorias // Clase que maneja toda la lógica del centro de tutorías.
    {
        // 'public' para que el Formulario Visual las vea
        public Queue<Estudiante> Cola_Prioritaria; // Cola en memoria para estudiantes con alta prioridad.
        public Queue<Estudiante> Cola_Regular; // Cola en memoria para estudiantes con prioridad normal.
        public List<Estudiante> Lista_Historial; // Lista en memoria para registrar estudiantes ya atendidos.

        // --- NUEVA PROPIEDAD PARA LA BD ---
        private TutoriasDbContext dbContext; // Objeto de contexto que conecta la aplicación con la BD.


        public GestionTutorias() // Constructor de la clase.
        {
            // Inicializamos las estructuras en memoria
            Cola_Prioritaria = new Queue<Estudiante>(); // Crea la cola de prioridad.
            Cola_Regular = new Queue<Estudiante>(); // Crea la cola regular.
            Lista_Historial = new List<Estudiante>(); // Crea la lista de historial.

            // --- CÓDIGO DE CONEXIÓN A BD ---
            // 1. Inicializamos el puente
            dbContext = new TutoriasDbContext(); // Instancia el contexto para acceder a la BD.

            // 2. Asegura que el archivo (ej: tutorias.db) y las tablas existan.
            //    Si no existen, los crea.
            dbContext.Database.EnsureCreated(); // Garantiza que el esquema de la base de datos esté creado.

            // 3. Cargamos los estudiantes pendientes
            CargarPendientesDesdeBD(); // Llama a la rutina para cargar datos pendientes al inicio.
        }

        // --- MÉTODO PRIVADO DE CARGA ---
        private void CargarPendientesDesdeBD() // Carga estudiantes con estado "En Espera" desde la BD a las colas.
        {
            // Busca en la tabla "Estudiantes" todos los que tengan Status "En Espera"
            var pendientes = dbContext.Estudiantes // Accede a la tabla de estudiantes.
                                        .Where(e => e.Status == "En Espera") // Filtra los registros por el estado de espera.
                                        .OrderBy(e => e.HoraLlegada) // Ordena los resultados por la hora de llegada.
                                        .ToList(); // Recupera los datos de la BD a una lista.

            foreach (var est in pendientes) // Recorre cada estudiante pendiente.
            {
                // Los re-encola en las listas en memoria
                if (est.TipoSolicitud == "prioritaria") // Comprueba si la solicitud es prioritaria.
                {
                    Cola_Prioritaria.Enqueue(est); // Encola el estudiante en la cola de prioridad.
                }
                else // Si es una solicitud regular.
                {
                    Cola_Regular.Enqueue(est); // Encola el estudiante en la cola regular.
                }
            }
        }


        // 1. Función para registrar
        public void RegistrarEstudiante(string nombre, string asignatura, string tipoSolicitud) // Registra un nuevo estudiante en el sistema.
        {
            // 1. Creamos el estudiante (esto ya pone el Status en "En Espera")
            Estudiante nuevoEstudiante = new Estudiante(nombre, asignatura, tipoSolicitud); // Crea el objeto estudiante.

            // 2. Lo agregamos a la cola en MEMORIA
            if (tipoSolicitud == "prioritaria") // Evalúa la prioridad de la solicitud.
            {
                Cola_Prioritaria.Enqueue(nuevoEstudiante); // Añade a la cola prioritaria.
            }
            else
            {
                Cola_Regular.Enqueue(nuevoEstudiante); // Añade a la cola regular.
            }

            // 3. Lo guardamos en la BASE DE DATOS
            dbContext.Estudiantes.Add(nuevoEstudiante); // Prepara el objeto para ser insertado en la BD.
            dbContext.SaveChanges(); // Confirma la inserción del nuevo registro en el archivo .db.
        }

        // 2. Función para atender
        public string AtenderSiguienteEstudiante() // Selecciona y remueve al siguiente estudiante a ser atendido.
        {
            Estudiante estudianteAtendido = null; // Inicializa la variable del estudiante a atender.
            string mensaje = ""; // Inicializa la variable para el mensaje de salida.

            if (Cola_Prioritaria.Count > 0) // Prioriza la cola prioritaria.
            {
                estudianteAtendido = Cola_Prioritaria.Dequeue(); // Saca el primer estudiante de la cola prioritaria (en memoria).
                mensaje = $"*** LLAMANDO (Prioridad): {estudianteAtendido.Nombre} para {estudianteAtendido.Asignatura} ***"; // Genera el mensaje de llamada.
            }
            else if (Cola_Regular.Count > 0) // Si la prioritaria está vacía, revisa la cola regular.
            {
                estudianteAtendido = Cola_Regular.Dequeue(); // Saca el primer estudiante de la cola regular (en memoria).
                mensaje = $"*** LLAMANDO (Regular): {estudianteAtendido.Nombre} para {estudianteAtendido.Asignatura} ***"; // Genera el mensaje de llamada.
            }
            else // Si ambas colas están vacías.
            {
                mensaje = "-> No hay estudiantes en espera."; // Mensaje de aviso.
                return mensaje; // Sale de la función retornando el mensaje.
            }

            // Agregamos al historial en MEMORIA
            Lista_Historial.Add(estudianteAtendido); // Agrega el estudiante atendido a la lista de historial en memoria.

            // --- Actualizamos la BD ---
            // 1. Cambiamos el status del estudiante
            estudianteAtendido.Status = "Atendido"; // Cambia el estado del estudiante.

            // 2. Le decimos a EF Core que este estudiante fue modificado
            dbContext.Estudiantes.Update(estudianteAtendido); // Marca el registro en la BD para su actualización.

            // 3. Guardamos los cambios en el archivo .db
            dbContext.SaveChanges(); // Persiste la actualización del estado en la BD.

            return mensaje; // Devuelve el mensaje de quién fue llamado.
        }

        // --- MÉTODOS DE CONSOLA (Funciones auxiliares) ---
        public void VerPendientes() { } // Función para mostrar estudiantes en espera (sin implementación).
        public void VerHistorial() { } // Función para mostrar el historial de estudiantes atendidos (sin implementación).
    }
}
