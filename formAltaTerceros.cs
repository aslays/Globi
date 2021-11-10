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
    public partial class formAltaTerceros : Form
    {
        BaseDatos Datos = new BaseDatos(@"Data Source=CASA06;Initial Catalog=Globi;Integrated Security=True");

        public formAltaTerceros()
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
        private void CargarTercero(Tercero T)
        {
            T.pApellido = txtApellido.Text;
            T.pNombre = txtNombre.Text;
            T.pDireccion = txtDireccion.Text;
            T.pCPostal = txtCpostal.Text;
            T.pProvincia = Convert.ToInt32(cboProvincia.SelectedValue);
            T.pCiudad = txtCiudad.Text;
            T.pEmail = txtEmail.Text;
            //T.pIdTercero = Convert.ToInt32(txtCodigo.Text);
            T.pNotas = txtNotas.Text;
            T.pDescripcion = txtDescripcion.Text;
            T.pTelefonoFijo = txtTelfijo.Text;
            T.pTelefonoMovil = txtTelmovil.Text;

        }
        private void Guardar()
        {
            string query = "";
            Tercero T = new Tercero();
            CargarTercero(T);

            if (Nuevo == true)
            {
                query = "insert into Terceros (Apellido,Nombre,Direccion,CPosta,Email,idProvincia,Ciudad,TelFijo,TelMovil,Descripcion,Notas) values ('" + T.pApellido + "', '" + T.pNombre + "', '" + T.pDireccion + "', '" + T.pCPostal + "', '" + T.pEmail + "'," + T.pProvincia + ", '" + T.pCiudad + "','" + T.pTelefonoFijo + "', '" + T.pTelefonoMovil + "', '" + T.pDescripcion + "', '" + T.pNotas + "')";
            }
            if (Nuevo == false)
            {
                T.pIdTercero = Convert.ToInt32(txtCodigo.Text);

                query = "update Terceros set Apellido='" + T.pApellido + "',Nombre='" + T.pNombre + "',Direccion='" + T.pDireccion + "',CPostal=" + T.pCPostal + ",Email='" + T.pEmail + "',idProvincia=" + T.pProvincia + ",Ciudad='" + T.pCiudad + "',TelFijo='" + T.pTelefonoFijo + "',TelMovil=" + T.pTelefonoMovil +  ",Descripcion='" + T.pDescripcion + "',Notas='" + T.pNotas + "' where idTercero =" + T.pIdTercero;
            }

            Datos.Actualizar(query);
            
        }


        public bool Nuevo { get; set; }
        public int IDTerceros { get; set; }
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

        private void formAltaTerceros_Load(object sender, EventArgs e)
        {
            if (Nuevo == false)
            {
                txtApellido.Text = apellido;
                txtNombre.Text = nombre;
                txtEmail.Text = email;
                txtDireccion.Text = direccion;
                txtCpostal.Text = cpostal;
                txtDescripcion.Text = descripcion;
                txtCodigo.Text = Convert.ToString(IDTerceros);
                txtNotas.Text = notas;
                txtTelfijo.Text = telfijo;
                txtTelmovil.Text = telmovil;
                txtCiudad.Text = ciudad;
                cboProvincia.SelectedValue = idprovincia;
            }
        }

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
