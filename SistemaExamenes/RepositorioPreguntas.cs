using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SistemaExamenes
{
    public static class RepositorioPreguntas
    {
        private const string archivo = "Preguntas.txt";

        public static List<Pregunta> ObtenerTodas()
        {
            if (!File.Exists(archivo)) return new List<Pregunta>();
            return File.ReadAllLines(archivo).Select(Pregunta.FromString).ToList();
        }

        public static void Guardar(List<Pregunta> preguntas)
        {
            File.WriteAllLines(archivo, preguntas.Select(p => p.ToString()));
        }

        public static void Agregar(Pregunta nueva)
        {
            var todas = ObtenerTodas();
            nueva.PreguntaId = (todas.Any() ? todas.Max(p => p.PreguntaId) + 1 : 1);
            todas.Add(nueva);
            Guardar(todas);
        }

        public static void Eliminar(int id)
        {
            var todas = ObtenerTodas();
            todas = todas.Where(p => p.PreguntaId != id).ToList();
            Guardar(todas);
        }

        public static void Modificar(Pregunta modificada)
        {
            var todas = ObtenerTodas();
            var index = todas.FindIndex(p => p.PreguntaId == modificada.PreguntaId);
            if (index != -1)
            {
                todas[index] = modificada;
                Guardar(todas);
            }
        }
        public static Pregunta ObtenerPorId(int id)
        {
            var todas = ObtenerTodas();
            return todas.FirstOrDefault(p => p.PreguntaId == id);
        }
    }
}
