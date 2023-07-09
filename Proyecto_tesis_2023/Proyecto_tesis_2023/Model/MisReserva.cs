using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_tesis_2023.Model
{
    public class MisReserva
    {
        public string id_mis_reservas { get; set; }
        public string id_reservas_dispo { get; set; }
        public string nombre_alumno { get; set; }
        public string fecha_solicitud { get; set; }
        public string fecha_reservada { get; set; }
        public string dia { get; set; } 
        public string campo { get; set; }
        public string inicio { get; set; }
        public string fin { get; set; }   


        //public int IdAlumnos { get; set; }
        //public DateTime FechaSolicitud { get; set; }
        //public DateTime FechaReservada { get; set; }
    }
}
