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
    public partial class formAltaProveedores : Form
    {
        BaseDatos Datos = new BaseDatos(@"Data Source=CASA06;Initial Catalog=Globi;Integrated Security=True");

        public formAltaProveedores()
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

        private void cargarProveedor(Proveedor P)
        {
            P.pNombre = txtNombre.Text;
            P.pNombreCom = txtNComercial.Text;
            P.pDireccion = txtDireccion.Text;
            P.pEmail = txtEmail.Text;
            P.pidProvincia = Convert.ToInt32(cboProvincia.SelectedValue);
            //P.pidProveedor = Convert.ToInt32(txtIDProv.Text);
            P.pDescripcion = txtDescripcion.Text;
            P.pCiudad = txtCiudad.Text;
            P.pCPostal = txtCPostal.Text;
            P.pTelFijo = txtTelFijo.Text;
            P.pTelMovil = txtTelMovil.Text;
            P.pNotas = txtNotas.Text;
        }

        private void Guardar()
        {
            string query = "";
            Proveedor P = new Proveedor();
            cargarProveedor(P);

            if (Nuevo == true)
            {
                query = "insert into Proveedores (Nombre,NombreComercial,Direccion,CPostal,Email,idProvincia,Ciudad,TelFijo,TelMovil,Descripcion,Notas) values ('" + P.pNombre + "','" + P.pNombreCom + "','" + P.pDireccion + "','" + P.pCPostal + "','" + P.pEmail + "'," + P.pidProvincia + ",'" + P.pCiudad + "','" + P.pTelFijo + "','" + P.pTelMovil + "','" + P.pDescripcion + "','" + P.pNotas + "')";
            }

            if (Nuevo == false)
            {
                P.pidProveedor=Convert.ToInt32(txtIDProv.Text);
                query = "update Proveedores set Nombre = '"+P.pNombre+"' ,NombreComercial ='"+P.pNombreCom+"', Direccion= '"+P.pDireccion+"', CPostal= '"+P.pCPostal+"', Email= '"+P.pEmail+"', idProvincia= "+P.pidProvincia+ ", Ciudad= '"+P.pCiudad+"', TelFijo= '"+P.pTelFijo+"', TelMovil= '"+P.pTelMovil+"', Descripcion= '"+P.pDescripcion+"', Notas='"+P.pNotas+"' where idProveedor= "+P.pidProveedor; 
            }

            Datos.Actualizar(query);
        }



        public bool Nuevo { get; set; }
        public int IDProvedor { get; set; }
        public string Nombre { get; set; }
        public string NombreCom { get; set; }
        public string Direccion { get; set; }
        public string CPostal { get; set; }
        public string Email { get; set; }
        public int IDProvincia { get; set; }
        public string Ciudad { get; set; }
        public string TelFijo { get; set; }
        public string TelMovil { get; set; }
        public string Descripcion { get; set; }
        public string Notas { get; set; }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            this.Close();
        }

        private void formAltaProveedores_Load(object sender, EventArgs e)
        {
            if (Nuevo == false)
            {
                txtNombre.Text = Nombre;
                txtNComercial.Text = NombreCom;
                txtDireccion.Text = Direccion;
                txtCiudad.Text = Ciudad;
                txtDescripcion.Text = Descripcion;
                txtEmail.Text = Email;
                txtIDProv.Text = Convert.ToString(IDProvedor);
                txtNotas.Text = Notas;
                txtTelFijo.Text = TelFijo;
                txtTelMovil.Text = TelMovil;
                cboProvincia.SelectedValue = IDProvincia;
                txtCPostal.Text = CPostal;
            }

        }
    }
}
