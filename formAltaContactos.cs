using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Globi
{
    public partial class formAltaContactos : Form
    {
        BaseDatos Datos = new BaseDatos(@"Data Source=CASA06;Initial Catalog=Globi;Integrated Security=True");

        public formAltaContactos()
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
        private void CargarContacto(Contacto C)
        {
            C.pApellido = txtApellido.Text;
            C.pNombre = txtNombre.Text;
            C.pDireccion = txtDireccion.Text;
            C.pCPostal = txtCPostal.Text;
            C.pProvincia = Convert.ToInt32(cboProvincia.SelectedValue);
            C.pCiudad = txtCiudad.Text;
            C.pEmail = txtEmail.Text;
            //T.pIdTercero = Convert.ToInt32(txtCodigo.Text);
            C.pNotas = txtNotas.Text;
            C.pDescripcion = txtDescripcion.Text;
            C.pTelefonoFijo = txtTelFijo.Text;
            C.pTelefonoMovil = txtTelMovil.Text;

        }
        private void Guardar()
        {
            string query = "";
            Contacto C = new Contacto();
            CargarContacto(C);

            if (Nuevo == true)
            {
                query = "insert into Contactos (Apellido,Nombre,Direccion,CPostal,Email,idProvincia,Ciudad,TelFijo,TelMovil,Descripcion,Notas) values ('" + C.pApellido + "', '" + C.pNombre + "', '" + C.pDireccion + "', '" + C.pCPostal + "', '" + C.pEmail + "'," + C.pProvincia + ", '" + C.pCiudad + "','" + C.pTelefonoFijo + "', '" + C.pTelefonoMovil + "', '" + C.pDescripcion + "', '" + C.pNotas + "')";
            }
            if (Nuevo == false)
            {
                C.pIdContacto = Convert.ToInt32(txtID.Text);

                query = "update Contactos set Apellido='" + C.pApellido + "',Nombre='" + C.pNombre + "',Direccion='" + C.pDireccion + "',CPostal=" + C.pCPostal + ",Email='" + C.pEmail + "',idProvincia=" + C.pProvincia + ",Ciudad='" + C.pCiudad + "',TelFijo='" + C.pTelefonoFijo + "',TelMovil=" + C.pTelefonoMovil + ",Descripcion='" + C.pDescripcion + "',Notas='" + C.pNotas + "' where idContacto =" + C.pIdContacto;
            }

            Datos.Actualizar(query);

        }

        private void formAltaContactos_Load(object sender, EventArgs e)
        {
            if (Nuevo == false)
            {
                txtApellido.Text = apellido;
                txtNombre.Text = nombre;
                txtEmail.Text = email;
                txtDireccion.Text = direccion;
                txtCPostal.Text = cpostal;
                txtDescripcion.Text = descripcion;
                txtID.Text = Convert.ToString(IDContactos);
                txtNotas.Text = notas;
                txtTelFijo.Text = telfijo;
                txtTelMovil.Text = telmovil;
                txtCiudad.Text = ciudad;
                cboProvincia.SelectedValue = idprovincia;
            }

        }

        public bool Nuevo { get; set; }
        public int IDContactos { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string cpostal { get; set; }
        public string email { get; set; }
        public int idprovincia { get; set; }
        public string ciudad { get; set; }
        public string telfijo { get; set; }
        public string telmovil { get; set; }
        public string descripcion { get; set; }
        public string notas { get; set; }

        private void button1_Click(object sender, EventArgs e)
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
