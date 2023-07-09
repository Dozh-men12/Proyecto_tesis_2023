using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Proyecto_tesis_2023.Model
{
    public class ReservaDisponible
    {
        public string id_reservas_dispo { get; set; }
        public string dia { get; set; }
        public string campo { get; set; }
        public string inicio { get; set; }
        public string fin { get; set; }
        public string id_mis_reservas { get; set; }
        public string id_alumnos { get; set; }
        public string nombre { get; set; }
        public string fecha_solicitud { get; set; }
        public string fecha_reservada { get; set; }




        // Relaciones con otras entidades
        //public Dia Dia { get; set; }
        //public Campo Campo { get; set; }
        //public Horario Horario { get; set; }
    }
}
