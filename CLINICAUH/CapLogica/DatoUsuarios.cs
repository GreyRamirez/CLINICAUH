using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLINICAUH.CapLogica
{
    public class PacientesData
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Medico { get; set; }
        public string Telefono { get; set; }
        public string Especialidad { get; set; }
        public string NumeroConsulta { get; set; }
        public DateTime FechaAtencion { get; set; }
        public TimeSpan HoraAtencion { get; set; }
        public string Consultorio { get; set; }
    }
}