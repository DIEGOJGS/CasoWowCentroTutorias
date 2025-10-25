using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CasoWowCentroTutorias;

namespace CasoWow.AppVisual
{
    public partial class MainForm : Form
    {
        private GestionTutorias gestor;
        public MainForm()
        {
            InitializeComponent();
            gestor = new GestionTutorias();
            ActualizarListasVisuales();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // 1. Obtenemos los datos de los TextBox
            string nombre = txtNombre.Text;
            string asignatura = txtAsignatura.Text;

            // 2. Validamos que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(asignatura))
            {
                MessageBox.Show("Por favor, ingrese el nombre y la asignatura.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detiene la función aquí
            }

            // 3. Determinamos el tipo de solicitud
            string tipoSolicitud = "";
            if (radPrioritaria.Checked)
            {
                tipoSolicitud = "prioritaria";
            }
            else if (radRegular.Checked)
            {
                tipoSolicitud = "regular";
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un tipo de solicitud (Prioritaria o Regular).", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detiene la función
            }

            // 4. Llamamos a nuestro gestor
            gestor.RegistrarEstudiante(nombre, asignatura, tipoSolicitud);

            // 5. Limpiamos los campos para el siguiente registro
            txtNombre.Clear();
            txtAsignatura.Clear();
            radPrioritaria.Checked = false;
            radRegular.Checked = false;

            // 6. Actualizamos las 3 listas visuales
            ActualizarListasVisuales(); // <-- Esta línea dará error por ahora


        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            // 1. Llamamos al gestor y capturamos el mensaje que devuelve
            string mensajeAtencion = gestor.AtenderSiguienteEstudiante();

            // 2. Mostramos el mensaje en una ventana emergente
            MessageBox.Show(mensajeAtencion, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 3. Actualizamos las 3 listas visuales
            ActualizarListasVisuales(); // <-- Esta línea también dará error (¡normal!)
        }

        private void ActualizarListasVisuales()
        {
            // --- 1. Limpiar las listas ANTES de rellenarlas ---
            lstColaPrioritaria.Items.Clear();
            lstColaRegular.Items.Clear();
            lstHistorial.Items.Clear();

            // --- 2. Rellenar la Lista de Prioridad (desde la MEMORIA) ---
            //    (Estas siguen viniendo de la memoria, lo cual es correcto)
            foreach (Estudiante est in gestor.Cola_Prioritaria)
            {
                lstColaPrioritaria.Items.Add($"{est.Nombre} ({est.Asignatura})");
            }

            // --- 3. Rellenar la Lista Regular (desde la MEMORIA) ---
            foreach (Estudiante est in gestor.Cola_Regular)
            {
                lstColaRegular.Items.Add($"{est.Nombre} ({est.Asignatura})");
            }

            // --- 4. Rellenar el Historial (¡¡DESDE LA BASE DE DATOS!!) ---

            // 4.A. Creamos un NUEVO "puente" solo para esta consulta
            using (var db = new CasoWowCentroTutorias.TutoriasDbContext())
            {
                // 4.B. Buscamos TODOS los estudiantes con status "Atendido"
                var atendidos = db.Estudiantes
                                  .Where(e => e.Status == "Atendido")
                                  .OrderByDescending(e => e.HoraLlegada) // Opcional: muestra los más nuevos primero
                                  .ToList();

                // 4.C. Llenamos la lista visual con el historial de la BD
                foreach (Estudiante est in atendidos)
                {
                    lstHistorial.Items.Add($"{est.Nombre} ({est.Asignatura}) | Tipo: {est.TipoSolicitud}");
                }
            }
        }

        private void lstColaPrioritaria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
