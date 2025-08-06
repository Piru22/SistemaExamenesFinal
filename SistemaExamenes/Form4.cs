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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void btnCorregirExamen_Click(object sender, EventArgs e)
        {
            string alumno = txtAlumno.Text.Trim();
            string examenId = txtIdExamen.Text.Trim();

            if (string.IsNullOrWhiteSpace(alumno) || string.IsNullOrWhiteSpace(examenId))
            {
                MessageBox.Show("Completá todos los campos.");
                return;
            }

            var preguntasRepo = RepositorioPreguntas.ObtenerTodas();
            var lineas = File.ReadAllLines("Examenes.txt");
            var linea = lineas.FirstOrDefault(l => l.StartsWith(examenId + "|"));
            if (linea == null) return;

            var partes = linea.Split('|');
            if (partes.Length < 6) return;

            var ids = partes[5].Split(',').Select(id => int.Parse(id)).ToList();
            int correctas = 0;
            List<string> feedback = new List<string>();

            foreach (int id in ids)
            {
                var pregunta = preguntasRepo.FirstOrDefault(p => p.PreguntaId == id);
                if (pregunta == null) continue;

                string tag = $"{examenId}|{pregunta.PreguntaId}";
                RadioButton seleccion = null;

                foreach (GroupBox groupBox in panelPreguntas.Controls.OfType<GroupBox>())
                {
                    seleccion = groupBox.Controls
                        .OfType<RadioButton>()
                        .FirstOrDefault(rb => rb.Tag?.ToString() == tag && rb.Checked);

                    if (seleccion != null)
                        break;
                }

                if (seleccion == null)
                {
                    feedback.Add($"Pregunta {pregunta.Texto}: No respondida.");
                    continue;
                }

                string textoSeleccionado = seleccion.Text;
                string respuestaUsuario = textoSeleccionado.Substring(textoSeleccionado.IndexOf(')') + 1).Trim();
                string correcta = pregunta.RespuestaCorrecta.Trim();

                if (respuestaUsuario == correcta)
                {
                    feedback.Add($"Pregunta {pregunta.Texto}: Correcta");
                    correctas++;
                }
                else
                {
                    feedback.Add($"Pregunta {pregunta.Texto}: Incorrecta (Ingresó: {respuestaUsuario} | Correcta: {correcta})");
                }
            }

            double nota = ((double)correctas / ids.Count) * 10;
            string resumen = $"EXAMEN ID: {examenId}\nAlumno: {alumno}\nNota: {nota} / 10\n";
            string feedbackDetalle = string.Join("\n", feedback);
            string todo = resumen + feedbackDetalle + "\n--------------------------------------------------\n";

            File.AppendAllText("Correcciones.txt", todo);

            // Mostrar resumen y feedback detallado en el MessageBox
            MessageBox.Show(
                "Examen corregido. Resultado:\n\n" + resumen + "\nPreguntas:\n" + feedbackDetalle,
                "Resultado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnGenerarExamen_Click(object sender, EventArgs e)
        {
            panelPreguntas.Controls.Clear();
            panelPreguntas.AutoScroll = true; // Asegurarse de activar scroll

            string examenId = txtIdExamen.Text.Trim();
            if (string.IsNullOrWhiteSpace(examenId))
            {
                MessageBox.Show("Ingresá el ID del examen.");
                return;
            }

            var lineas = File.ReadAllLines("Examenes.txt");
            var linea = lineas.FirstOrDefault(l => l.StartsWith(examenId + "|"));

            if (linea == null)
            {
                MessageBox.Show("No se encontró el examen.");
                return;
            }

            var partes = linea.Split('|');
            if (partes.Length < 6)
            {
                MessageBox.Show("Formato de examen inválido.");
                return;
            }

            var preguntasRepo = RepositorioPreguntas.ObtenerTodas();
            string[] ids = partes[5].Split(',');
            int y = 10;
            int preguntaNum = 1;

            foreach (var idStr in ids)
            {
                if (!int.TryParse(idStr, out int id)) continue;
                var pregunta = preguntasRepo.FirstOrDefault(p => p.PreguntaId == id);
                if (pregunta == null) continue;

                // Crear un GroupBox para agrupar la pregunta y sus opciones
                GroupBox groupBox = new GroupBox();
                groupBox.Text = $"{preguntaNum}) {pregunta.Texto}";
                groupBox.Location = new Point(10, y);
                groupBox.Size = new Size(panelPreguntas.Width - 40, 100);
                groupBox.AutoSize = true;

                int yOffset = 20;
                char letra = 'A';
                foreach (var opcion in pregunta.Opciones)
                {
                    RadioButton rb = new RadioButton();
                    rb.Text = $"{letra}) {opcion}";
                    rb.Tag = $"{examenId}|{pregunta.PreguntaId}";
                    rb.Location = new Point(10, yOffset);
                    rb.AutoSize = true;
                    groupBox.Controls.Add(rb);

                    yOffset += 25;
                    letra++;
                }
                panelPreguntas.Controls.Add(groupBox);
                y += groupBox.Height + 10;
                preguntaNum++;
            }
        }       
    }
}
