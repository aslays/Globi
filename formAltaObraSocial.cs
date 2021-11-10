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
    public partial class formAltaObraSocial : Form
    {
        BaseDatos Datos = new BaseDatos(@"Data Source=CASA06;Initial Catalog=Globi;Integrated Security=True");

        public formAltaObraSocial()
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

        private void cargarObrasocial(ObraSocial O)
        {
            O.pNombre = txtNombre.Text;
            O.pNombreCom = txtNombreLegal.Text;
            O.pDireccion = txtDireccion.Text;
            O.pEmail = txtEmail.Text;
            O.pFax = txtFax.Text;
            O.pTelefono1 = txtTelefono1.Text;
            O.pTelefono2 = txtTelefono2.Text;
            O.pCiudad = txtCiudad.Text;
            O.pCuit = txtCuit.Text;
            O.pProvincia = Convert.ToInt32(cboProvincia.SelectedValue);
            O.pWeb = txtWeb.Text;
            O.pNotas = txtNotas.Text;
            O.pCpostal = txtCpostal.Text;
        }
        private void Guardar()
        {
            string query = "";
            ObraSocial O = new ObraSocial();
            cargarObrasocial(O);

            if (Nuevo == true)
            {
                query = "insert into ObrasSociales (Nombre,NombreLegal,Cuit,Direccion,Telefono1,Telefono2,TelefonoFax,Cpostal,Email,idProvincia,Ciudad,Web,Notas) values ('" + O.pNombre + "', '" + O.pNombreCom + "', '" + O.pCuit + "', '" + O.pDireccion + "', '" + O.pTelefono1 + "','" + O.pTelefono2 + "', '" + O.pFax + "','" + O.pCpostal + "', '" + O.pEmail + "'," + O.pProvincia + ", '" + O.pCiudad + "','"+O.pWeb+"','"+O.pNotas+"')";
            }
            if (Nuevo == false)
            {
                O.pCodigo = Convert.ToInt32(txtId.Text);

                query = "update ObrasSociales set nombre='" + O.pNombre + "',NombreLegal='" + O.pNombreCom + "',Cuit='" + O.pCuit + "',Direccion='" + O.pDireccion + "',Telefono1='" + O.pTelefono1 + "',Telefono2='" + O.pTelefono2 + "',TelefonoFax='" + O.pFax + "',Cpostal='" + O.pCpostal + "',Email='" + O.pEmail + "',idProvincia=" + O.pProvincia + ",Ciudad='" + O.pCiudad + "',web='" + O.pWeb + "',Notas='" + O.pNotas + "' where idObraSocial =" + O.pCodigo;
            }

            Datos.Actualizar(query);
        }
        private void formAltaObraSocial_Load(object sender, EventArgs e)
        {
            if (Nuevo == false)
            {
                txtId.Text = Convert.ToString(idObraSocial);
                txtNombre.Text = nombre;
                txtNombreLegal.Text = nombrelegal;
                txtDireccion.Text = direccion;
                txtEmail.Text = email;
                txtFax.Text = telefonofax;
                txtTelefono1.Text = telefono1;
                txtTelefono2.Text = telefono2;
                txtNotas.Text = notas;
                txtCiudad.Text = ciudad;
                txtCuit.Text = cuit;
                txtCpostal.Text = cpostal;
                cboProvincia.SelectedValue = idprovincia;
                txtWeb.Text = notas;

            }
        }

        public bool Nuevo { get; set; }
        public int idObraSocial { get; set; }
        public string nombrelegal { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string cpostal { get; set; }
        public string email { get; set; }
        public int idprovincia { get; set; }
        public string ciudad { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string telefonofax { get; set; }
        public string notas { get; set; }
        public string web { get; set; }
        public string cuit { get; set; }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        
    }
}
