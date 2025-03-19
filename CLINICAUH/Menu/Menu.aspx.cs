using System;
using System.Data;
using System.Web.UI.WebControls;
using CLINICAUH.CapLogica;

namespace CLINICAUH
{
    public partial class Menu : System.Web.UI.Page
    {
        private LogicaPaciente logica = new LogicaPaciente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPacientes();
            }
        }

        // 🔹 CARGAR PACIENTES EN EL GRIDVIEW
        private void CargarPacientes()
        {
            gvPacientes.DataSource = logica.ObtenerPacientes();
            gvPacientes.DataBind();
        }

        // 🔹 MOSTRAR MENSAJE EN LA INTERFAZ
        private void MostrarMensaje(string mensaje, bool esError)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = esError ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }

        // 🔹 VALIDAR CAMPOS VACÍOS
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrimerApellido.Text) ||
                string.IsNullOrWhiteSpace(txtFechaNacimiento.Text) ||
                string.IsNullOrWhiteSpace(txtEdad.Text) ||
                string.IsNullOrWhiteSpace(txtMedico.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtEspecialidad.Text) ||
                string.IsNullOrWhiteSpace(txtNumeroConsulta.Text) ||
                string.IsNullOrWhiteSpace(txtFechaAtencion.Text) ||
                string.IsNullOrWhiteSpace(txtHoraAtencion.Text) ||
                string.IsNullOrWhiteSpace(txtConsultorio.Text))
            {
                MostrarMensaje("⚠️ Por favor, complete todos los campos.", true);
                return false;
            }
            return true;
        }

        // 🔹 AGREGAR PACIENTE
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            PacientesData nuevoPaciente = new PacientesData
            {
                Cedula = txtCedula.Text,
                Nombre = txtNombre.Text,
                PrimerApellido = txtPrimerApellido.Text,
                FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                Edad = int.Parse(txtEdad.Text),
                Medico = txtMedico.Text,
                Telefono = txtTelefono.Text,
                Especialidad = txtEspecialidad.Text,
                NumeroConsulta = txtNumeroConsulta.Text,
                FechaAtencion = Convert.ToDateTime(txtFechaAtencion.Text),
                HoraAtencion = TimeSpan.Parse(txtHoraAtencion.Text),
                Consultorio = txtConsultorio.Text
            };

            logica.AgregarPaciente(nuevoPaciente);
            MostrarMensaje("✅ Paciente agregado correctamente.", false);
            CargarPacientes();
        }

        // 🔹 MODIFICAR PACIENTE
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            PacientesData pacienteModificado = new PacientesData
            {
                Cedula = txtCedula.Text,
                Nombre = txtNombre.Text,
                PrimerApellido = txtPrimerApellido.Text,
                FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                Edad = int.Parse(txtEdad.Text),
                Medico = txtMedico.Text,
                Telefono = txtTelefono.Text,
                Especialidad = txtEspecialidad.Text,
                NumeroConsulta = txtNumeroConsulta.Text,
                FechaAtencion = Convert.ToDateTime(txtFechaAtencion.Text),
                HoraAtencion = TimeSpan.Parse(txtHoraAtencion.Text),
                Consultorio = txtConsultorio.Text
            };

            logica.ModificarPaciente(pacienteModificado);
            MostrarMensaje("✅ Paciente modificado correctamente.", false);
            CargarPacientes();
        }

        // 🔹 ELIMINAR PACIENTE
        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MostrarMensaje("⚠️ Debe ingresar una cédula para eliminar un paciente.", true);
                return;
            }

            logica.EliminarPaciente(txtCedula.Text);
            MostrarMensaje("✅ Paciente eliminado correctamente.", false);
            CargarPacientes();
        }

        // 🔹 SELECCIONAR PACIENTE DEL GRIDVIEW
        protected void gvPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow filaSeleccionada = gvPacientes.SelectedRow;
            txtCedula.Text = filaSeleccionada.Cells[1].Text;
            txtNombre.Text = filaSeleccionada.Cells[2].Text;
            txtPrimerApellido.Text = filaSeleccionada.Cells[3].Text;
            txtTelefono.Text = filaSeleccionada.Cells[4].Text;
            txtEspecialidad.Text = filaSeleccionada.Cells[5].Text;
        }
    }
}
