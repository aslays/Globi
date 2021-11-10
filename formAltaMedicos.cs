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
    public partial class formAltaMedicos : Form
    {
        BaseDatos Datos = new BaseDatos(@"Data Source=CASA06;Initial Catalog=Globi;Integrated Security=True");

        public formAltaMedicos()
        {
            InitializeComponent();
            CargarCombo("Provincias", cboProvincia);
            CargarCombo("Especialidad", cboEspecialidad);
        }
        private void CargarCombo(string tabla, ComboBox cbox)
        {
            DataTable dt = new DataTable();
            dt = Datos.Leer("select * from " + tabla);
            cbox.DataSource = dt;
            cbox.ValueMember = dt.Columns[0].ColumnName;
            cbox.DisplayMember = dt.Columns[1].ColumnName;
        }

        private void CargarMedico(Medico M)
        {
            M.pApellido = txtApellido.Text;
            M.pNombre = txtNombre.Text;
            M.pDocumento = txtDocumento.Text;
            M.pDireccion = txtDireccion.Text;
            M.pTelefonoFijo = txtTelFijo.Text;
            M.pTelefonoMovil = txtTelMovil.Text;
            M.pProvincia = Convert.ToInt32(cboProvincia.SelectedValue);
            M.pCiudad = txtCiudad.Text;
            M.pEmail = txtEmail.Text;
            M.pMatricula = txtMatricula.Text;
           // se crea solo  M.pIDMEdico = Convert.ToInt32(txtID.Text);
            M.pCPostal = txtCPostal.Text;
            M.pEspecialidad = Convert.ToInt32(cboEspecialidad.SelectedValue);
            M.pNotas = richTextBoxNotas.Text;
            M.pAusencias = richTextBoxAusencias.Text;
            M.pVacaciones = richTextBoxVacaciones.Text;
        }

        private void Guardar()
        {
            string query = "";
            Medico M = new Medico();
            CargarMedico(M);
            
            if (Nuevo == true)
            {
                query = "insert into Medicos (Matricula,Nombre,ApellidoMedico,Documento,Direccion,CPostal,Email,IdProvincia,Ciudad,TelefonoF,TelefonoM,idEspecialidad,Notas,Ausencias,Vacaciones) values ('" + M.pMatricula + "', '" + M.pNombre + "', '" + M.pApellido + "', '" + M.pDocumento + "', '" + M.pDireccion + "','" + M.pCPostal + "', '" + M.pEmail + "'," + M.pProvincia + ", '" + M.pCiudad + "', '" + M.pTelefonoFijo + "', '" + M.pTelefonoMovil + "'," + M.pEspecialidad + ",'"+M.pNotas+"','"+M.pAusencias+"','"+M.pVacaciones+"')";
            }
            if (Nuevo == false)
            {
                M.pIDMEdico = Convert.ToInt32(txtID.Text);

                query = "update Medicos set Matricula='" + M.pMatricula + "',Nombre='" + M.pNombre + "',ApellidoMedico='" + M.pApellido + "',Documento='" + M.pDocumento + "',Direccion='" + M.pDireccion + "',CPostal=" + M.pCPostal + ",Email='" + M.pEmail + "',idProvincia=" + M.pProvincia + ",Ciudad='" + M.pCiudad + "',TelefonoF='" + M.pTelefonoFijo + "',TelefonoM=" + M.pTelefonoMovil + ",idEspecialidad=" + M.pEspecialidad + ",Notas='" + M.pNotas + "',Ausencias='" + M.pAusencias +"',Vacaciones='"+M.pVacaciones+ "' where idMedico =" + M.pIDMEdico;
            }

            Datos.Actualizar(query);

        }



        public bool Nuevo { get; set; }
        public int IDMedico { get; set; }
        public string ApellidoMedico { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string DocMed { get; set; }
        public string DireMed { get; set; }
        public string CPostal { get; set; }
        public string Email { get; set; }
        public int IDprov { get; set; }
        public string Ciudad { get; set; }
        public string TelFijo { get; set; }
        public string TelMovil { get; set; }
        public int IDEspecialidad { get; set; }
        public string Notas { get; set; }
        public string Ausencias { get; set; }
        public string Vacaciones { get; set; }

        private void formAltaMedicos_Load(object sender, EventArgs e)
        {
            if (Nuevo == false)
            {
                txtApellido.Text = ApellidoMedico;
                txtNombre.Text = Nombre;
                txtDocumento.Text = DocMed;
                txtMatricula.Text = Matricula;
                txtTelFijo.Text = TelFijo;
                txtTelMovil.Text = TelMovil;
                txtEmail.Text = Email;
                txtCPostal.Text = CPostal;
                txtCiudad.Text = Ciudad;
                txtID.Text = Convert.ToString(IDMedico);
                txtDireccion.Text = DireMed;
                cboEspecialidad.SelectedValue = IDEspecialidad;
                cboProvincia.SelectedValue = IDprov;
                richTextBoxNotas.Text = Notas;
                richTextBoxAusencias.Text = Ausencias;
                richTextBoxVacaciones.Text = Vacaciones;

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
