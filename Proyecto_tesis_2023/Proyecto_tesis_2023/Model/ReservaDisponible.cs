using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Proyecto_tesis_2023.Model
{
    public class ReservaDisponible
    {
        public int Id { get; set; }
        public int DiaId { get; set; }
        public int CampoId { get; set; }
        public int HorarioId { get; set; }

        // Relaciones con otras entidades
        public Dia Dia { get; set; }
        public Campo Campo { get; set; }
        public Horario Horario { get; set; }
    }
}
