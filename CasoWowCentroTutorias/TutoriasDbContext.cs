using Microsoft.EntityFrameworkCore; // ¡Importante!
using System;
using System.IO;

namespace CasoWowCentroTutorias
{
    public class TutoriasDbContext : DbContext // <-- Hereda de DbContext
    {
        // Esto le dice a EF Core que queremos una tabla llamada "Estudiantes"
        // que usará nuestra clase "Estudiante" como molde.
        public DbSet<Estudiante> Estudiantes { get; set; }

        // Esto configura la conexión a la base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 1. Define el nombre de nuestro archivo de base de datos
            string dbNombre = "tutorias.db";

            // 2. Busca la ruta de la carpeta "Mis Documentos" del usuario
            string rutaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // 3. Combina la ruta para crear la ruta completa
            // Ej: C:\Users\TuUsuario\Documents\tutorias.db
            string rutaCompleta = Path.Combine(rutaDocumentos, dbNombre);

            // 4. Le dice a EF Core que use SQLite con esa ruta de archivo
            optionsBuilder.UseSqlite($"Data Source={rutaCompleta}");
        }
    }
}