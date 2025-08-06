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
    public partial class Form3 : Form
    {
        private string lastExamenId;
        public Form3()
        {
            InitializeComponent();
        }

        // btn Generar Examen
        private void btnGestionarExamen_Click(object sender, EventArgs e)
        {
            string asignatura = cmbAsignatura.Text.Trim();
            if (string.IsNullOrEmpty(asignatura))
            {
                MessageBox.Show("Seleccioná una asignatura.");
                return;
            }

            string[] unidades = txtUnidades.Text.Split(',').Select(u => u.Trim()).Where(u => !string.IsNullOrEmpty(u)).ToArray();
            if (unidades.Length == 0)
            {
                MessageBox.Show("Ingresá al menos una unidad.");
                return;
            }

            // HashSet es una estructura de datos que nos permite ingresar valores sin duplicados.
            var todas = RepositorioPreguntas.ObtenerTodas();
            List<Pregunta> preguntasExamen = new List<Pregunta>();
            HashSet<int> idsIncluidos = new HashSet<int>();

            foreach (string unidad in unidades)
            {
                var subunidades = todas
                    .Where(p => p.Asignatura.Equals(asignatura, StringComparison.OrdinalIgnoreCase) &&
                                p.Unidad.Equals(unidad, StringComparison.OrdinalIgnoreCase))
                    .Select(p => p.SubUnidad)
                    .Distinct();

                foreach (var sub in subunidades)
                {
                    var preguntas = todas
                        .Where(p => p.Asignatura.Equals(asignatura, StringComparison.OrdinalIgnoreCase) &&
                                    p.Unidad.Equals(unidad, StringComparison.OrdinalIgnoreCase) &&
                                    p.SubUnidad.Equals(sub, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    if (preguntas.Count > 0)
                    {
                        var rnd = new Random();
                        var seleccionada = preguntas[rnd.Next(preguntas.Count)];
                        if (!idsIncluidos.Contains(seleccionada.PreguntaId))
                        {
                            preguntasExamen.Add(seleccionada);
                            idsIncluidos.Add(seleccionada.PreguntaId);
                        }
                    }
                }
            }

            if (preguntasExamen.Count == 0)
            {
                MessageBox.Show("No se encontraron preguntas para los criterios ingresados.");
                return;
            }

            // Mostrar el examen en el RichTextBox
            rtbExamen.Clear();
            int numero = 1;
            Random randOpc = new Random();
            foreach (var p in preguntasExamen)
            {
                rtbExamen.AppendText($"{numero}) {p.Texto}\n");

                var opciones = p.Opciones.OrderBy(x => randOpc.Next()).ToList(); // aleatorizar opciones
                char letra = 'A';
                foreach (var op in opciones)
                {
                    rtbExamen.AppendText($"   {letra}) {op}\n");
                    letra++;
                }

                rtbExamen.AppendText("\n");
                numero++;
            }

            //No permite valores nulos
            string carrera = txtCarrera.Text.Trim();
            if (string.IsNullOrWhiteSpace(carrera))
            {
                MessageBox.Show("Ingresá el nombre de la carrera.");
                return;
            }

            /* Guardar en Examenes.txt
            -Guid sirve para generar identificadores unicos. En este caso genera el codigo, lo convierte a string y 
            con  Substring(0, 8) lo limita a 8 caracteres */
            string examenId = Guid.NewGuid().ToString().Substring(0, 8); lastExamenId = examenId;
            string universidad = txtUniversidad.Text.Trim();
            string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");
            string ids = string.Join(",", preguntasExamen.Select(p => p.PreguntaId));
            string linea = $"{examenId}|{fecha}|{universidad}|{carrera}|{asignatura}|{ids}";

            if (string.IsNullOrWhiteSpace(universidad))
            {
                MessageBox.Show("Ingresá el nombre de la universidad.");
                return;
            }

            File.AppendAllLines("Examenes.txt", new[] { linea });

            MessageBox.Show("Examen generado y guardado correctamente.");           

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var todas = RepositorioPreguntas.ObtenerTodas();

            var asignaturas = todas
                .Select(p => p.Asignatura)
                .Distinct()
                .OrderBy(a => a)
                .ToList();

            cmbAsignatura.DataSource = asignaturas;
        }

        // tiene como objetivo crear un archivo de texto que contenga el examen generado y luego abrirlo con un bloc de notas
        private void btnImprimirExamen_Click(object sender, EventArgs e)
        {
            //Se crea un objeto StringBuilder, que sirve para armar textos largos de forma eficiente
            var sb = new StringBuilder(); 
            // Se agregan los datos del encabezado del examen
            sb.AppendLine($"EXAMEN ID: {lastExamenId}");          
            sb.AppendLine($"Fecha: {dtpFecha.Value:yyyy-MM-dd}");
            sb.AppendLine($"Universidad: {txtUniversidad.Text}");
            sb.AppendLine($"Carrera:     {txtCarrera.Text}");
            sb.AppendLine($"Asignatura:  {cmbAsignatura.Text}");
            sb.AppendLine(new string('-', 50));
            sb.AppendLine();

            /* copia todo el contenido visible en el RichTextBox que ya tenia cargadas las preguntas y respuestas
            y tal como se muestran en pantalla se agregan al archivo final */
            sb.Append(rtbExamen.Text);

            File.WriteAllText("ImpresionExamen.txt", sb.ToString()); // crea el txt y guarda el texto generado hasta el momento
            MessageBox.Show("Se generó el archivo ImpresionExamen.txt correctamente.");
            System.Diagnostics.Process.Start("notepad.exe", "ImpresionExamen.txt"); // abre automaticamente el bloc de notas
        }
    }
}

