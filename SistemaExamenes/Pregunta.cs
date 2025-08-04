using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExamenes
{
    public class Pregunta
    {
        public int PreguntaId { get; set; }
        public string Texto { get; set; }
        public List<string> Opciones { get; set; } = new List<string>();
        public string RespuestaCorrecta { get; set; }
        public string Asignatura { get; set; }
        public string Unidad { get; set; }
        public string SubUnidad { get; set; }

        public override string ToString()
        {
            return $"{PreguntaId}|{Texto}|{string.Join(";", Opciones)}|{RespuestaCorrecta}|{Asignatura}|{Unidad}|{SubUnidad}";
        }

        public static Pregunta FromString(string line)
        {
            // dividimos como máximo en 7 partes (evita que un '|' extra en el texto rompa el formato)
            var parts = line.Split(new[] { '|' }, 7);

            // si nos quedaron menos de 7 campos, rellenamos con cadenas vacías 
            if (parts.Length < 7)
            {
                var tmp = parts.ToList();
                while (tmp.Count < 7) tmp.Add(string.Empty);
                parts = tmp.ToArray();
            }

            return new Pregunta
            {
                PreguntaId = int.TryParse(parts[0], out var id) ? id : 0,
                Texto = parts[1],
                Opciones = parts[2].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(o => o.Trim())
                                           .ToList(),
                RespuestaCorrecta = parts[3],
                Asignatura = parts[4],
                Unidad = parts[5],
                SubUnidad = parts[6],
            };
        }
    }
}
