using System; // Importa tipos de sistema esenciales.
using System.Collections.Generic; // Proporciona interfaces y clases para colecciones genéricas.
using System.ComponentModel; // Proporciona clases para implementar componentes.
using System.Data; // Proporciona clases para manejar datos (no muy usado aquí, pero es común).
using System.Drawing; // Proporciona acceso a funciones gráficas GDI+.
using System.Linq; // Proporciona capacidades de consulta (LINQ).
using System.Text; // Proporciona clases para la codificación de caracteres.
using System.Threading.Tasks; // Proporciona tipos para tareas asíncronas.
using System.Windows.Forms; // Proporciona clases para crear aplicaciones basadas en Windows.
using CasoWowCentroTutorias; // Importa el namespace de nuestra lógica de negocio (GestiónTutorias, Estudiante, etc.).

namespace CasoWow.AppVisual // Define el namespace de la aplicación visual.
{
    public partial class MainForm : Form // Define la clase de la ventana principal de la aplicación.
    {
        private GestionTutorias gestor; // Objeto que contiene la lógica de negocio (colas y BD).
        
        public MainForm() // Constructor de la ventana.
        {
            InitializeComponent(); // Función generada por el diseñador para inicializar los controles de la interfaz.
            gestor = new GestionTutorias(); // Crea una nueva instancia del gestor de tutorías.
            ActualizarListasVisuales(); // Carga los datos iniciales al mostrar la ventana.
        }

        private void btnRegistrar_Click(object sender, EventArgs e) // Manejador de eventos para el botón "Registrar".
        {
            // 1. Obtenemos los datos de los TextBox
            string nombre = txtNombre.Text; // Obtiene el nombre del campo de texto.
            string asignatura = txtAsignatura.Text; // Obtiene la asignatura del campo de texto.

            // 2. Validamos que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(asignatura)) // Comprueba si los campos están vacíos.
            {
                MessageBox.Show("Por favor, ingrese el nombre y la asignatura.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra un mensaje de error.
                return; // Detiene la función aquí.
            }

            // 3. Determinamos el tipo de solicitud
            string tipoSolicitud = ""; // Inicializa la variable de tipo de solicitud.
            if (radPrioritaria.Checked) // Verifica si el RadioButton de Prioritaria está seleccionado.
            {
                tipoSolicitud = "prioritaria"; // Asigna el valor "prioritaria".
            }
            else if (radRegular.Checked) // Verifica si el RadioButton de Regular está seleccionado.
            {
                tipoSolicitud = "regular"; // Asigna el valor "regular".
            }
            else // Si ninguno está seleccionado.
            {
                MessageBox.Show("Por favor, seleccione un tipo de solicitud (Prioritaria o Regular).", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra error por falta de selección.
                return; // Detiene la función.
            }

            // 4. Llamamos a nuestro gestor
            gestor.RegistrarEstudiante(nombre, asignatura, tipoSolicitud); // Invoca el método para registrar y guardar en la BD.

            // 5. Limpiamos los campos para el siguiente registro
            txtNombre.Clear(); // Limpia el campo de nombre.
            txtAsignatura.Clear(); // Limpia el campo de asignatura.
            radPrioritaria.Checked = false; // Deselecciona el radio button.
            radRegular.Checked = false; // Deselecciona el radio button.

            // 6. Actualizamos las 3 listas visuales
            ActualizarListasVisuales(); // Refresca las listas de la interfaz gráfica con los datos actuales.
        }

        private void btnAtender_Click(object sender, EventArgs e) // Manejador de eventos para el botón "Atender Siguiente".
        {
            // 1. Llamamos al gestor y capturamos el mensaje que devuelve
            string mensajeAtencion = gestor.AtenderSiguienteEstudiante(); // Atiende al siguiente estudiante y actualiza la BD.

            // 2. Mostramos el mensaje en una ventana emergente
            MessageBox.Show(mensajeAtencion, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra el resultado de la operación.

            // 3. Actualizamos las 3 listas visuales
            ActualizarListasVisuales(); // Refresca las listas de la interfaz.
        }

        private void ActualizarListasVisuales() // Método para refrescar los datos mostrados en las listas (ListBox).
        {
            // --- 1. Limpiar las listas ANTES de rellenarlas ---
            lstColaPrioritaria.Items.Clear(); // Vacía la lista de prioridad.
            lstColaRegular.Items.Clear(); // Vacía la lista regular.
            lstHistorial.Items.Clear(); // Vacía la lista de historial.

            // --- 2. Rellenar la Lista de Prioridad (desde la MEMORIA) ---
            // (Estas siguen viniendo de la memoria, lo cual es correcto)
            foreach (Estudiante est in gestor.Cola_Prioritaria) // Itera sobre la cola de prioridad en memoria.
            {
                lstColaPrioritaria.Items.Add($"{est.Nombre} ({est.Asignatura})"); // Agrega el formato de texto a la lista visual.
            }

            // --- 3. Rellenar la Lista Regular (desde la MEMORIA) ---
            foreach (Estudiante est in gestor.Cola_Regular) // Itera sobre la cola regular en memoria.
            {
                lstColaRegular.Items.Add($"{est.Nombre} ({est.Asignatura})"); // Agrega el formato de texto a la lista visual.
            }

            // --- 4. Rellenar el Historial (DESDE LA BASE DE DATOS) ---

            // 4.A. Creamos un NUEVO "puente" solo para esta consulta
            using (var db = new CasoWowCentroTutorias.TutoriasDbContext()) // Crea un nuevo contexto de BD temporal (se cerrará automáticamente).
            {
                // 4.B. Buscamos TODOS los estudiantes con status "Atendido"
                var atendidos = db.Estudiantes // Accede a la tabla de estudiantes.
                                     .Where(e => e.Status == "Atendido") // Filtra solo los estudiantes con estado "Atendido".
                                     .OrderByDescending(e => e.HoraLlegada) // Ordena los resultados para mostrar los últimos atendidos primero.
                                     .ToList(); // Ejecuta la consulta y trae los datos a memoria.

                // 4.C. Llenamos la lista visual con el historial de la BD
                foreach (Estudiante est in atendidos) // Itera sobre los estudiantes atendidos recuperados.
                {
                    lstHistorial.Items.Add($"{est.Nombre} ({est.Asignatura}) | Tipo: {est.TipoSolicitud}"); // Agrega el formato de historial a la lista visual.
                }
            }
        }

        private void lstColaPrioritaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Método vacío: no implementa lógica al seleccionar un elemento de la lista.
        }

        private void label9_Click(object sender, EventArgs e)
        {
            // Método vacío.
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Método vacío.
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Método vacío.
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // Método vacío.
        }

        private void label8_Click(object sender, EventArgs e)
        {
            // Método vacío.
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Método vacío: código que se ejecutaría al cargar la ventana.
        }
    }
}
