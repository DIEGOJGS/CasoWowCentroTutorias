using System;

// 1. ¡Importante! Usamos el namespace de nuestro proyecto para poder ver
//    las clases Estudiante y GestionTutorias que creamos.
namespace CasoWowCentroTutorias
{
    class Program
    {
        // El "static void Main" es el punto de entrada, aquí comienza todo.
        static void Main(string[] args)
        {
            // 2. Creamos UNA instancia de nuestro gestor.
            //    Este objeto 'gestor' vivirá mientras el programa se ejecute
            //    y contendrá nuestras colas e historial.
            GestionTutorias gestor = new GestionTutorias();

            bool salir = false;

            // 3. Un bucle "while" que mantiene el programa corriendo
            //    hasta que el usuario elija "5. Salir".
            while (!salir)
            {
                // Limpiamos la consola para mostrar el menú de forma clara
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("  Sistema de Control de Atenciones - Centro UPN   ");
                Console.WriteLine("==================================================");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Registrar Estudiante");
                Console.WriteLine("2. Atender Siguiente Estudiante");
                Console.WriteLine("3. Ver Listas de Espera");
                Console.WriteLine("4. Ver Historial de Atendidos");
                Console.WriteLine("5. Salir");
                Console.Write("\nOpción: ");

                string opcion = Console.ReadLine();

                // 4. Un "switch" para manejar la opción del usuario
                switch (opcion)
                {
                    case "1":
                        RegistrarNuevoEstudiante(gestor);
                        break;
                    case "2":
                        gestor.AtenderSiguienteEstudiante();
                        break;
                    case "3":
                        gestor.VerPendientes();
                        break;
                    case "4":
                        gestor.VerHistorial();
                        break;
                    case "5":
                        salir = true;
                        Console.WriteLine("\nSaliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione Enter para continuar...");
                    Console.ReadLine(); // Pausa para que el usuario pueda leer
                }
            }
        }

        // 5. Creamos una función separada para registrar,
        //    así mantenemos el menú principal limpio.
        static void RegistrarNuevoEstudiante(GestionTutorias gestor)
        {
            Console.WriteLine("\n--- Nuevo Registro ---");
            Console.Write("Nombre del estudiante: ");
            string nombre = Console.ReadLine();

            Console.Write("Asignatura: ");
            string asignatura = Console.ReadLine();

            string tipoSolicitud = "";
            while (tipoSolicitud != "1" && tipoSolicitud != "2")
            {
                Console.Write("Tipo (1=Prioritaria, 2=Regular): ");
                tipoSolicitud = Console.ReadLine();
                if (tipoSolicitud != "1" && tipoSolicitud != "2")
                {
                    Console.WriteLine("Error: ingrese solo 1 o 2.");
                }
            }

            // Convertimos el "1" o "2" al texto que espera nuestro gestor
            string tipoFinal = (tipoSolicitud == "1") ? "prioritaria" : "regular";

            gestor.RegistrarEstudiante(nombre, asignatura, tipoFinal);
        }
    }
}