using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_tesis_2023.Model
{
    public class MisReserva
    {
        public int IdMisReservas { get; set; }
        public int IdReservasDispo { get; set; }
        public int IdAlumnos { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaReservada { get; set; }
    }
}
