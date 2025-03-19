<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="CLINICAUH.Menu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Estilo/MenuS.css" rel="stylesheet" type="text/css" />
    <title>Consulta de Pacientes</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 style="text-align: center;">Consulta de Pacientes</h2>
            
            <div class="panel-menu">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="menu-btn" OnClick="btnAgregar_Click" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="menu-btn" OnClick="btnModificar_Click" />
                <asp:Button ID="btnBorrar" runat="server" Text="Borrar" CssClass="menu-btn" OnClick="btnBorrar_Click" />
            </div>

            <div class="panel-form">
                <table>
                    <tr>
                        <th>Cédula</th>
                        <th>Nombre</th>
                        <th>1er Apellido</th>
                        <th>Fecha Nacimiento</th>
                        <th>Edad</th>
                        <th>Médico</th>
                    </tr>
                    <tr>
                        <td><asp:TextBox ID="txtCedula" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtPrimerApellido" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtMedico" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Teléfono</th>
                        <th>Especialidad</th>
                        <th># Consulta</th>
                        <th>Fecha Atención</th>
                        <th>Hora Atención</th>
                        <th>Consultorio</th>
                    </tr>
                    <tr>
                        <td><asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEspecialidad" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtNumeroConsulta" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtFechaAtencion" runat="server" TextMode="Date"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtHoraAtencion" runat="server" TextMode="Time"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtConsultorio" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
            </div>

            <div class="panel-grid">
<asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvPacientes_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="Cedula" HeaderText="Cédula" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="PrimerApellido" HeaderText="1er Apellido" />
        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="Edad" HeaderText="Edad" />
        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
        <asp:BoundField DataField="Medico" HeaderText="Médico" />
        <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
        <asp:BoundField DataField="NumeroConsulta" HeaderText="#Consulta" />
        <asp:BoundField DataField="Consultorio" HeaderText="Consultorio" />
        <asp:BoundField DataField="FechaAtencion" HeaderText="Fecha Atención" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="HoraAtencion" HeaderText="Hora Atención" />
    </Columns>
</asp:GridView>
            </div>
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" CssClass="mensaje-error"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblInstrucciones" runat="server" ForeColor="Blue" CssClass="mensaje-info"
             Text="(Para modificar o borrar, introduzca la cédula.)"></asp:Label>

        </div>
    </form>
</body>
</html>
