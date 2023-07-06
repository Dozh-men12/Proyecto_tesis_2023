using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Proyecto_tesis_2023.Model
{
    public class ReservasDisponibles
    {
        public int Id { get; set; }
        public int DiaId { get; set; }
        public int CampoId { get; set; }
        public int HorarioId { get; set; }

        // Relaciones con otras entidades
        public Dias Dia { get; set; }
        public Campos Campo { get; set; }
        public Horarios Horario { get; set; }
    }
}
