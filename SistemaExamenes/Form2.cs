using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SistemaExamenes
{
    public partial class Form2 : Form
    {
        private List<Pregunta> listaPreguntasCargadas = new List<Pregunta>();
        private Pregunta preguntaSeleccionada;

        public Form2()
        {
            InitializeComponent();
            CargarPreguntas();
            lstContenido.SelectedIndexChanged += lstContenido_SelectedIndexChanged;
        }
        private void lstContenido_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstContenido.SelectedIndex;
            if (index < 0 || listaPreguntasCargadas.Count == 0)
                return;

            // Cada bloque de pregunta + 4 opciones + línea en blanco = 6 ítems
            int preguntaIndex = index / 6;
            if (preguntaIndex >= listaPreguntasCargadas.Count)
                return;

            // Sólo rellenamos cuando haces clic en la línea de pregunta (0)
            // o en cualquiera de sus 4 opciones (1–4). Si haces clic en la 5 (blanco) salimos.
            int lineaDentro = index % 6;
            if (lineaDentro == 5)
                return;

            // Traemos la pregunta correspondiente
            preguntaSeleccionada = listaPreguntasCargadas[preguntaIndex];

            // La mostramos en los TextBox
            txtPregunta.Text = preguntaSeleccionada.Texto;
            txtResp1.Text = preguntaSeleccionada.Opciones[0];
            txtResp2.Text = preguntaSeleccionada.Opciones[1];
            txtResp3.Text = preguntaSeleccionada.Opciones[2];
            txtRespCorrecta.Text = preguntaSeleccionada.Opciones[3];
            txtAsignatura.Text = preguntaSeleccionada.Asignatura;
            txtUnidad.Text = preguntaSeleccionada.Unidad;
            txtSubunidad.Text = preguntaSeleccionada.SubUnidad;
        }

        private void BuscarPorUnidad(string unidad)
        {
            lstContenido.Items.Clear();
            listaPreguntasCargadas = RepositorioPreguntas.ObtenerTodas()
                .Where(p => p.Unidad.Equals(unidad, StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var pregunta in listaPreguntasCargadas)
            {
                lstContenido.Items.Add($"[{pregunta.PreguntaId}] {pregunta.Texto}");

                char letra = 'A';
                foreach (var opcion in pregunta.Opciones)
                {
                    lstContenido.Items.Add($"   {letra}) {opcion}");
                    letra++;
                }

                lstContenido.Items.Add("");
            }
        }

        private void btnAgregarPreg_Click(object sender, EventArgs e)
        {
            var pregunta = new Pregunta
            {
                Texto = txtPregunta.Text,
                Opciones = new List<string> { txtResp1.Text, txtResp2.Text, txtResp3.Text, txtRespCorrecta.Text },
                RespuestaCorrecta = txtRespCorrecta.Text,
                Asignatura = txtAsignatura.Text,
                Unidad = txtUnidad.Text,
                SubUnidad = txtSubunidad.Text
            };
            RepositorioPreguntas.Agregar(pregunta);
            MessageBox.Show("Pregunta agregada correctamente.");
            CargarPreguntas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (preguntaSeleccionada == null)
            {
                MessageBox.Show("Seleccioná una pregunta primero.");
                return;
            }
            preguntaSeleccionada.Texto = txtPregunta.Text;
            preguntaSeleccionada.Opciones = new List<string> { txtResp1.Text, txtResp2.Text, txtResp3.Text, txtRespCorrecta.Text };
            preguntaSeleccionada.RespuestaCorrecta = txtRespCorrecta.Text;
            preguntaSeleccionada.Asignatura = txtAsignatura.Text;
            preguntaSeleccionada.Unidad = txtUnidad.Text;
            preguntaSeleccionada.SubUnidad = txtSubunidad.Text;

            RepositorioPreguntas.Modificar(preguntaSeleccionada);

            MessageBox.Show("Pregunta modificada correctamente.");
            CargarPreguntas();
            preguntaSeleccionada = null;
        }

        private void CargarPreguntas()
        {
            lstContenido.Items.Clear();
            listaPreguntasCargadas = RepositorioPreguntas.ObtenerTodas();

            foreach (var pregunta in listaPreguntasCargadas)
            {
                lstContenido.Items.Add($"[{pregunta.PreguntaId}] {pregunta.Texto}");

                char letra = 'A';
                foreach (var opcion in pregunta.Opciones)
                {
                    lstContenido.Items.Add($"   {letra}) {opcion}");
                    letra++;
                }

                lstContenido.Items.Add(""); // línea en blanco para separar
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (preguntaSeleccionada == null)
            {
                MessageBox.Show("Seleccioná una pregunta para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Esta seguro que quiere eliminar esta pregunta?", "Confirmar eliminación", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                RepositorioPreguntas.Eliminar(preguntaSeleccionada.PreguntaId);
                MessageBox.Show("Pregunta eliminada correctamente.");

                preguntaSeleccionada = null;
                CargarPreguntas();
                LimpiarCampos();
            }
        }
        private void LimpiarCampos()
        {
            txtPregunta.Clear();
            txtResp1.Clear();
            txtResp2.Clear();
            txtResp3.Clear();
            txtRespCorrecta.Clear();
            txtAsignatura.Clear();
            txtUnidad.Clear();
            txtSubunidad.Clear();
        }

        private void btnUnidad_Click(object sender, EventArgs e)
        {
            string unidad = txtUnidad.Text.Trim();

            if (string.IsNullOrWhiteSpace(unidad))
            {
                MessageBox.Show("Ingresá una unidad para buscar.");
                return;
            }

            BuscarPorUnidad(unidad);
        }
    }
}
