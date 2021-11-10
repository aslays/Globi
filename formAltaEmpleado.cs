using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Globi
{
    public partial class formAltaEmpleado : Form
    {

        BaseDatos Datos = new BaseDatos(@"Data Source=CASA06;Initial Catalog=Globi;Integrated Security=True");

        public formAltaEmpleado()
        {
            InitializeComponent();
            CargarCombo("Provincias", cboProvincia);
        }

        private void CargarCombo(string tabla, ComboBox cbox)
        {
            DataTable dt = new DataTable();
            dt = Datos.Leer("select * from " + tabla);
            cbox.DataSource = dt;
            cbox.ValueMember = dt.Columns[0].ColumnName;
            cbox.DisplayMember = dt.Columns[1].ColumnName;
        }

        private void cargarEmpleado(Empleado E)
        {
            E.pApellido = txtApellido.Text;
            E.pNombre = txtNombre.Text;
            E.pDocumento = txtDocumento.Text;
            E.pDireccion = txtDireccion.Text;
            E.pEmail = txtEmail.Text;
            E.pCPostal = txtCPostal.Text;
            E.pTelefonoFijo = txtTelFijo.Text;
            E.pTelefonoMovil = txtTelMovil.Text;
            E.pProvincia = Convert.ToInt32(cboProvincia.SelectedValue);
            E.pCiudad = txtCiudad.Text;
            E.pNotas = richTextBoxNotas.Text;
            E.pAusencias = richTextBoxAusencias.Text;
            E.pVacaciones = richTextBoxVacaciones.Text;
        }

        private void Guardar()
        {
            string query = "";
            Empleado E = new Empleado();
            cargarEmpleado(E);

            if (Nuevo == true)
            {
                query = "insert into Empleados (Apellido,Nombre,Documento,Direccion,TelefonoF,TelefonoM,Email,CPostal,Ciudad,IdProvincia,Notas,Ausencias,Vacaciones) values ('" + E.pApellido + "', '" + E.pNombre + "', '" + E.pDocumento + "', '" + E.pDireccion + "', '" + E.pTelefonoFijo + "','" + E.pTelefonoMovil + "', '" + E.pEmail + "','" + E.pCPostal + "', '" + E.pCiudad + "', " + E.pProvincia + ", '" + E.pNotas + "','" + E.pAusencias + "','" + E.pVacaciones + "')";
            }
            if (Nuevo == false)
            {
                E.pCODEmpleado = Convert.ToInt32(txtCodEmpleado.Text);

                query = "update Empleados set Apellido='" + E.pApellido + "',Nombre='" + E.pNombre + "',Documento='" + E.pDocumento + "',Direccion='" + E.pDireccion + "',TelefonoF='" + E.pTelefonoFijo + "',TelefonoM=" + E.pTelefonoMovil + ",Email='" + E.pEmail + "',CPostal='" + E.pCPostal + "',Ciudad='" + E.pCiudad + "',idProvincia=" + E.pProvincia +  ",Notas='" + E.pNotas + "',Ausencias='" + E.pAusencias + "',Vacaciones='" + E.pVacaciones + "' where idEmpleado =" + E.pCODEmpleado;
            }

            Datos.Actualizar(query);
        }





        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        public bool Nuevo { get; set; }
        public int IDEmpleado { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Documetno { get; set; }
        public string Direccion { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string Email { get; set; }
        public string CPosta { get; set; }
        public string Ciudad { get; set; }
        public int IdProvincia { get; set; }
        public string Notas { get; set; }
        public string Ausencias { get; set; }
        public string Vacaciones { get; set; }

        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            this.Close();
        }

        private void formAltaEmpleado_Load(object sender, EventArgs e)
        {
            if (Nuevo == false)
            {
                txtApellido.Text = Apellido;
                txtNombre.Text = Nombre;
                txtDocumento.Text = Documetno;
                txtDireccion.Text = Direccion;
                txtCPostal.Text = CPosta;
                txtEmail.Text = Email;
                txtTelFijo.Text = TelefonoFijo;
                txtTelMovil.Text = TelefonoMovil;
                cboProvincia.SelectedValue = Convert.ToInt32(IdProvincia);
                txtCodEmpleado.Text = Convert.ToString(IDEmpleado);
                richTextBoxNotas.Text = Notas;
                richTextBoxAusencias.Text = Ausencias;
                richTextBoxVacaciones.Text = Vacaciones;
                txtCiudad.Text = Ciudad;

            }

        }
    }
}
