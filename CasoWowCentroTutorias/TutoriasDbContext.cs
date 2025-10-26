using Microsoft.EntityFrameworkCore; // Importa Entity Framework Core, esencial para la conexión a la BD.
using System; // Importa tipos de sistema, necesario para Environment.
using System.IO; // Importa clases para manejar rutas de archivos (Path).

namespace CasoWowCentroTutorias // Define el espacio de nombres del proyecto.
{
    public class TutoriasDbContext : DbContext // Define la clase de contexto que maneja la BD. Hereda de DbContext.
    {
        // Esto le dice a EF Core que queremos una tabla llamada "Estudiantes"
        // que usará nuestra clase "Estudiante" como molde.
        public DbSet<Estudiante> Estudiantes { get; set; } // Propiedad que representa la tabla "Estudiantes" en la base de datos.

        // Esto configura la conexión a la base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Método que configura las opciones de conexión a la BD.
        {
            // 1. Define el nombre de nuestro archivo de base de datos
            string dbNombre = "tutorias.db"; // Nombre del archivo físico de la base de datos SQLite.

            // 2. Busca la ruta de la carpeta "Mis Documentos" del usuario
            string rutaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Obtiene la ruta de la carpeta "Mis Documentos".

            // 3. Combina la ruta para crear la ruta completa
            // Ej: C:\Users\TuUsuario\Documents\tutorias.db
            string rutaCompleta = Path.Combine(rutaDocumentos, dbNombre); // Construye la ruta completa al archivo de la BD.

            // 4. Le dice a EF Core que use SQLite con esa ruta de archivo
            optionsBuilder.UseSqlite($"Data Source={rutaCompleta}"); // Configura EF Core para usar SQLite y especifica la ruta del archivo.
        }
    }
}s
