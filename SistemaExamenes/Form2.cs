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
        private List<Pregunta> listaPreguntasCargadas = new List<Pregunta>();//guarda las preg cargadas desde el archivo
        private Pregunta preguntaSeleccionada;//guarda la preg q seleccionas para modif o eliminar

        public Form2()
        {
            InitializeComponent();
            CargarPreguntas();
            lstContenido.SelectedIndexChanged += lstContenido_SelectedIndexChanged;
        }

        // guarda algo seleccionado en alguna linea o sale del metodo
        private void lstContenido_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstContenido.SelectedIndex;
            if (index < 0 || listaPreguntasCargadas.Count == 0)
                return;

            // Cada bloque de pregunta + 4 opciones + línea en blanco = 6 ítems
            int preguntaIndex = index / 6;
            if (preguntaIndex >= listaPreguntasCargadas.Count)
                return;

            // Splo rellenamos cuando haces clic en la línea de pregunta (0)
            // o en cualquiera de sus 4 opciones (1–4). Si haces clic en la 5 (blanco) salimos
            int lineaDentro = index % 6;
            if (lineaDentro == 5)
                return;

            // traemos la pregunta correspondiente
            preguntaSeleccionada = listaPreguntasCargadas[preguntaIndex];

            // la mostramos en los TextBox
            txtPregunta.Text = preguntaSeleccionada.Texto;
            txtResp1.Text = preguntaSeleccionada.Opciones[0];
            txtResp2.Text = preguntaSeleccionada.Opciones[1];
            txtResp3.Text = preguntaSeleccionada.Opciones[2];
            txtRespCorrecta.Text = preguntaSeleccionada.Opciones[3];
            txtAsignatura.Text = preguntaSeleccionada.Asignatura;
            txtUnidad.Text = preguntaSeleccionada.Unidad;
            txtSubunidad.Text = preguntaSeleccionada.SubUnidad;
        }

        private void BuscarPorUnidad(string unidad) // muestra solo las preg q tengan esas unidad
        {
            lstContenido.Items.Clear(); // borra la lista para llenarla desde 0
            listaPreguntasCargadas = RepositorioPreguntas.ObtenerTodas().Where(p => p.Unidad.Equals(unidad, StringComparison.OrdinalIgnoreCase)).ToList(); // filtra las preg x unid

            foreach (var pregunta in listaPreguntasCargadas)
            {
                lstContenido.Items.Add($"[{pregunta.PreguntaId}] {pregunta.Texto}"); // agrega la preg con id a su lista

                char letra = 'A';
                foreach (var opcion in pregunta.Opciones)
                {
                    lstContenido.Items.Add($"   {letra}) {opcion}"); 
                    letra++;
                }

                lstContenido.Items.Add(""); 
            }
        }

        private void btnAgregarPreg_Click(object sender, EventArgs e) // crea una nueva preg con lo q cargamos
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

        private void btnModificar_Click(object sender, EventArgs e) // modifica una preg ya cargada
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

        private void btnEliminar_Click(object sender, EventArgs e) // elimina la preg que seleccionamos
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
        private void LimpiarCampos() // vacia los campos de texto
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

                lstContenido.Items.Add(""); 
            }
        }

        private void btnUnidad_Click(object sender, EventArgs e) // filtra las preg cargadas por unidad 
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
