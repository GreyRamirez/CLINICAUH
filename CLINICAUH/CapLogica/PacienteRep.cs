using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CLINICAUH.CapLogica;

namespace CLINICAUH.CapLogica
{
    public class PacienteRep
    {
        private string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        // 🔹 CONSULTAR TODOS LOS PACIENTES (Solo los campos necesarios)
        public DataTable ObtenerPacientes()
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "SELECT Cedula, Nombre, PrimerApellido, FechaNacimiento, Edad, Medico, Telefono, Especialidad, NumeroConsulta, FechaAtencion, HoraAtencion, Consultorio FROM Pacientes";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // 🔹 INSERTAR PACIENTE
        public int AgregarPaciente(PacientesData paciente)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = @"INSERT INTO Pacientes (Cedula, Nombre, PrimerApellido, FechaNacimiento, Edad, Medico, Telefono, Especialidad, NumeroConsulta, FechaAtencion, HoraAtencion, Consultorio) 
                                 VALUES (@Cedula, @Nombre, @PrimerApellido, @FechaNacimiento, @Edad, @Medico, @Telefono, @Especialidad, @NumeroConsulta, @FechaAtencion, @HoraAtencion, @Consultorio)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Cedula", paciente.Cedula);
                    cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                    cmd.Parameters.AddWithValue("@PrimerApellido", paciente.PrimerApellido);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", paciente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Edad", paciente.Edad);
                    cmd.Parameters.AddWithValue("@Medico", paciente.Medico);
                    cmd.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                    cmd.Parameters.AddWithValue("@Especialidad", paciente.Especialidad);
                    cmd.Parameters.AddWithValue("@NumeroConsulta", paciente.NumeroConsulta);
                    cmd.Parameters.AddWithValue("@FechaAtencion", paciente.FechaAtencion);
                    cmd.Parameters.AddWithValue("@HoraAtencion", paciente.HoraAtencion);
                    cmd.Parameters.AddWithValue("@Consultorio", paciente.Consultorio);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // 🔹 MODIFICAR PACIENTE (usando Cedula)
        public int ModificarPaciente(PacientesData paciente)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = @"UPDATE Pacientes 
                                 SET Nombre = @Nombre, PrimerApellido = @PrimerApellido, FechaNacimiento = @FechaNacimiento, Edad = @Edad, 
                                     Medico = @Medico, Telefono = @Telefono, Especialidad = @Especialidad, NumeroConsulta = @NumeroConsulta, 
                                     FechaAtencion = @FechaAtencion, HoraAtencion = @HoraAtencion, Consultorio = @Consultorio
                                 WHERE Cedula = @Cedula";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Cedula", paciente.Cedula);
                    cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                    cmd.Parameters.AddWithValue("@PrimerApellido", paciente.PrimerApellido);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", paciente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Edad", paciente.Edad);
                    cmd.Parameters.AddWithValue("@Medico", paciente.Medico);
                    cmd.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                    cmd.Parameters.AddWithValue("@Especialidad", paciente.Especialidad);
                    cmd.Parameters.AddWithValue("@NumeroConsulta", paciente.NumeroConsulta);
                    cmd.Parameters.AddWithValue("@FechaAtencion", paciente.FechaAtencion);
                    cmd.Parameters.AddWithValue("@HoraAtencion", paciente.HoraAtencion);
                    cmd.Parameters.AddWithValue("@Consultorio", paciente.Consultorio);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // 🔹 ELIMINAR PACIENTE (usando Cedula)
        public int EliminarPaciente(string cedula)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "DELETE FROM Pacientes WHERE Cedula = @Cedula";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Cedula", cedula);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
