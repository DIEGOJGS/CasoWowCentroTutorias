using System; // Importa tipos de sistema esenciales.

// Incluimos el espacio de nombres del proyecto para acceder a nuestras clases.
namespace CasoWowCentroTutorias
{
    class Program // Clase principal de la aplicación de consola.
    {
        // El método Main es el punto de inicio del programa.
        static void Main(string[] args)
        {
            // Crea el objeto que administra las colas y la base de datos de tutorías.
            GestionTutorias gestor = new GestionTutorias();

            bool salir = false;

            // Bucle principal que mantiene la ejecución del menú.
            while (!salir)
            {
                // Borra la pantalla para presentar el menú limpio.
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("  Sistema de Control de Atenciones - Centro UPN    ");
                Console.WriteLine("==================================================");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Registrar Estudiante");
                Console.WriteLine("2. Atender Siguiente Estudiante");
                Console.WriteLine("3. Ver Listas de Espera");
                Console.WriteLine("4. Ver Historial de Atendidos");
                Console.WriteLine("5. Salir");
                Console.Write("\nOpción: ");

                string opcion = Console.ReadLine();

                // Evalúa la opción ingresada por el usuario.
                switch (opcion)
                {
                    case "1":
                        RegistrarNuevoEstudiante(gestor); // Llama a la función para ingresar datos de un estudiante.
                        break;
                    case "2":
                        // Llama al método para atender al siguiente y captura el mensaje de resultado.
                        string mensaje = gestor.AtenderSiguienteEstudiante();
                        Console.WriteLine(mensaje); // Muestra el mensaje de estudiante atendido.
                        break;
                    case "3":
                        gestor.VerPendientes(); // Llama al método para mostrar las colas de espera.
                        break;
                    case "4":
                        gestor.VerHistorial(); // Llama al método para mostrar el historial de atenciones.
                        break;
                    case "5":
                        salir = true; // Establece la bandera de salida para terminar el bucle.
                        Console.WriteLine("\nSaliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Intente de nuevo."); // Maneja opciones incorrectas.
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione Enter para continuar...");
                    Console.ReadLine(); // Pausa la ejecución para lectura del usuario.
                }
            }
        }

        // Función auxiliar para solicitar y registrar los datos del nuevo estudiante.
        static void RegistrarNuevoEstudiante(GestionTutorias gestor)
        {
            Console.WriteLine("\n--- Nuevo Registro ---");
            Console.Write("Nombre del estudiante: ");
            string nombre = Console.ReadLine(); // Lee el nombre.

            Console.Write("Asignatura: ");
            string asignatura = Console.ReadLine(); // Lee la asignatura.

            string tipoSolicitud = "";
            while (tipoSolicitud != "1" && tipoSolicitud != "2") // Bucle de validación para el tipo de solicitud.
            {
                Console.Write("Tipo (1=Prioritaria, 2=Regular): ");
                tipoSolicitud = Console.ReadLine();
                if (tipoSolicitud != "1" && tipoSolicitud != "2")
                {
                    Console.WriteLine("Error: ingrese solo 1 o 2.");
                }
            }

            // Convierte la opción numérica del usuario al formato de texto esperado por el gestor.
            string tipoFinal = (tipoSolicitud == "1") ? "prioritaria" : "regular";

            gestor.RegistrarEstudiante(nombre, asignatura, tipoFinal); // Llama al método del gestor para guardar el nuevo registro.
        }
    }
}
