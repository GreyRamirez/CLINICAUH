using System;
using System.Data;
using CLINICAUH.CapLogica; // Asegúrate de que este espacio de nombres coincida con tu capa de datos

namespace CLINICAUH.CapLogica
{
    public class LogicaPaciente
    {
        private PacienteRep datos = new PacienteRep(); // Clase que maneja los datos

        // 🔹 CONSULTAR TODOS LOS PACIENTES
        public DataTable ObtenerPacientes()
        {
            return datos.ObtenerPacientes();
        }

        // 🔹 AGREGAR PACIENTE
        public int AgregarPaciente(PacientesData paciente)
        {
            return datos.AgregarPaciente(paciente);
        }

        // 🔹 MODIFICAR PACIENTE (USANDO CÉDULA)
        public int ModificarPaciente(PacientesData paciente)
        {
            return datos.ModificarPaciente(paciente);
        }

        // 🔹 ELIMINAR PACIENTE POR CÉDULA
        public int EliminarPaciente(string cedula)
        {
            return datos.EliminarPaciente(cedula);
        }
    }
}
