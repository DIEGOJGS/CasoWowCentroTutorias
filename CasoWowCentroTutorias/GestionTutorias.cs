using System;
using System.Collections.Generic;
using System.Linq; // ¡¡Importante!! Necesario para consultas a la BD

namespace CasoWowCentroTutorias
{
    public class GestionTutorias
    {
        // 'public' para que el Formulario Visual las vea
        public Queue<Estudiante> Cola_Prioritaria;
        public Queue<Estudiante> Cola_Regular;
        public List<Estudiante> Lista_Historial;

        // --- NUEVA PROPIEDAD PARA LA BD ---
        private TutoriasDbContext dbContext; // Nuestro "puente" a la BD


        public GestionTutorias()
        {
            // Inicializamos las estructuras en memoria
            Cola_Prioritaria = new Queue<Estudiante>();
            Cola_Regular = new Queue<Estudiante>();
            Lista_Historial = new List<Estudiante>();

            // --- CÓDIGO NUEVO DE BD ---
            // 1. Inicializamos el puente
            dbContext = new TutoriasDbContext();

            // 2. Asegura que el archivo (ej: tutorias.db) y las tablas existan.
            //    Si no existen, los crea.
            dbContext.Database.EnsureCreated();

            // 3. ¡¡La "magia"!! Cargamos los estudiantes pendientes
            CargarPendientesDesdeBD();
        }

        // --- NUEVO MÉTODO PRIVADO ---
        private void CargarPendientesDesdeBD()
        {
            // Busca en la tabla "Estudiantes" todos los que tengan Status "En Espera"
            var pendientes = dbContext.Estudiantes
                                      .Where(e => e.Status == "En Espera")
                                      .OrderBy(e => e.HoraLlegada) // Los ordena por hora
                                      .ToList(); // Los trae a memoria

            foreach (var est in pendientes)
            {
                // Los re-encola en las listas en memoria
                if (est.TipoSolicitud == "prioritaria")
                {
                    Cola_Prioritaria.Enqueue(est);
                }
                else
                {
                    Cola_Regular.Enqueue(est);
                }
            }
        }


        // 1. Función para registrar (¡¡MODIFICADA!!)
        public void RegistrarEstudiante(string nombre, string asignatura, string tipoSolicitud)
        {
            // 1. Creamos el estudiante (esto ya pone el Status en "En Espera")
            Estudiante nuevoEstudiante = new Estudiante(nombre, asignatura, tipoSolicitud);

            // 2. Lo agregamos a la cola en MEMORIA
            if (tipoSolicitud == "prioritaria")
            {
                Cola_Prioritaria.Enqueue(nuevoEstudiante);
            }
            else
            {
                Cola_Regular.Enqueue(nuevoEstudiante);
            }

            // 3. ¡¡NUEVO!! Lo guardamos en la BASE DE DATOS
            dbContext.Estudiantes.Add(nuevoEstudiante);
            dbContext.SaveChanges(); // Confirma los cambios en el archivo .db
        }

        // 2. Función para atender (¡¡MODIFICADA!!)
        public string AtenderSiguienteEstudiante()
        {
            Estudiante estudianteAtendido = null;
            string mensaje = "";

            if (Cola_Prioritaria.Count > 0)
            {
                estudianteAtendido = Cola_Prioritaria.Dequeue(); // Sale de la cola en MEMORIA
                mensaje = $"*** LLAMANDO (Prioridad): {estudianteAtendido.Nombre} para {estudianteAtendido.Asignatura} ***";
            }
            else if (Cola_Regular.Count > 0)
            {
                estudianteAtendido = Cola_Regular.Dequeue(); // Sale de la cola en MEMORIA
                mensaje = $"*** LLAMANDO (Regular): {estudianteAtendido.Nombre} para {estudianteAtendido.Asignatura} ***";
            }
            else
            {
                mensaje = "-> No hay estudiantes en espera.";
                return mensaje;
            }

            // Agregamos al historial en MEMORIA
            Lista_Historial.Add(estudianteAtendido);

            // --- ¡¡NUEVO!! Actualizamos la BD ---
            // 1. Cambiamos el status del estudiante
            estudianteAtendido.Status = "Atendido";

            // 2. Le decimos a EF Core que este estudiante fue modificado
            dbContext.Estudiantes.Update(estudianteAtendido);

            // 3. Guardamos los cambios en el archivo .db
            dbContext.SaveChanges();

            return mensaje;
        }

        // --- MÉTODOS DE CONSOLA (Los dejamos por si acaso) ---
        public void VerPendientes() { }
        public void VerHistorial() { }
    }
}