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
    public partial class formAltaPacientes : Form
    {
        const int tam = 500;
        Consulta[] VP = new Consulta[tam];

        BaseDatos Datos = new BaseDatos(@"Data Source=CASA06;Initial Catalog=Globi;Integrated Security=True");

        public formAltaPacientes()
        {
            InitializeComponent();
            CargarCombo("Provincias", cboProvincia);
            CargarCombo("ObrasSociales",cboObrasocial);

            //CargarCombo("Practicas", cboPracticas);
            //CargarCombo("Diagnosticos", cboDiagnostico);
            
        }
        private void CargarCombo(string tabla, ComboBox cbox)
        {
            DataTable dt = new DataTable();
            dt = Datos.Leer("select * from " + tabla);
            cbox.DataSource = dt;
            cbox.ValueMember = dt.Columns[0].ColumnName;
            cbox.DisplayMember = dt.Columns[1].ColumnName;
        }
        private void CargarComboMedico(string tabla, ComboBox cbox)
        {
            DataTable dt = new DataTable();
            dt = Datos.Leer("select * from " + tabla + " where idEspecialidad = " + EspecialidadSeleccionada);
            cbox.DataSource = dt;
            cbox.ValueMember = dt.Columns[0].ColumnName;
            cbox.DisplayMember = dt.Columns[3].ColumnName;
        }
        private void CargarComboPracticas(string tabla, ComboBox cbox)
        {
            DataTable dt = new DataTable();
            dt = Datos.Leer("select * from " + tabla + " where idEspecialidad = " + EspecialidadSeleccionada);
            cbox.DataSource = dt;
            cbox.ValueMember = dt.Columns[0].ColumnName;
            cbox.DisplayMember = dt.Columns[1].ColumnName;
        }
        private void CargarComboDiagnosticos(string tabla, ComboBox cbox)
        {
            DataTable dt = new DataTable();
            dt = Datos.Leer("select * from " + tabla + " where idEspecialidad = " + EspecialidadSeleccionada);
            cbox.DataSource = dt;
            cbox.ValueMember = dt.Columns[0].ColumnName;
            cbox.DisplayMember = dt.Columns[1].ColumnName;
        }

        private void CargarPaciente(Paciente P)
        {
            //P.pIdPaciente = txtNroPac.Text;

            

            P.pApellido = txtApellido.Text;
            P.pNombre = txtNombre.Text;
            P.pDocumento = txtDocumento.Text;
            P.pDireccion = txtDireccion.Text;
            
            P.pCPostal = txtCPostal.Text;
            P.pProvincia = Convert.ToInt32(cboProvincia.SelectedValue);
            P.pCiudad = txtCiudad.Text;
            P.pTelefonoF = txtTelefonoF.Text;
            P.pTelefonoM = txtTelefonoM.Text;
            P.pEmail = txtEmail.Text;
            
            P.pNroAfiliado = txtNroafiliado.Text;
            P.pFechaAlta = dtpFechaalta.Value.Date;

            if (txtaaaa.Text.Length != 0 && txtdd.Text.Length != 0 && txtmm.Text.Length != 0)
            {
                int dd = Convert.ToInt32(txtdd.Text);
                int mm = Convert.ToInt32(txtmm.Text);
                int aaaa = Convert.ToInt32(txtaaaa.Text);
            

            P.pFechaNac = Convert.ToDateTime(dd + "/" + mm + "/" + aaaa);
            }

            
            P.pObraSocial = 1;
            

            if (rbtnMasculino.Checked)
                P.pSexo = 1;
            else P.pSexo = 2;

            P.pIdObrasocial = Convert.ToInt32(cboObrasocial.SelectedValue);
                        

        }

        private void CargarConsulta(Consulta C)
        {
            C.pMotivo = richTextBox1.Text;
            C.pidDiagnostico = Convert.ToInt32(cboDiagnostico.SelectedValue);
            C.pidPractica = Convert.ToInt32(cboPracticas.SelectedValue);
            C.pAclaraciones = richTextBox3.Text;
            C.pIdMedico = Convert.ToInt32(cboMedico.SelectedValue);
            
            C.pFechaConsulta = dateTimePicker1.Value;

            
            C.pIdPaciente = Convert.ToInt32(txtNroPac.Text);

            C.pMotivo = richTextBox1.Text;
            C.pAclaraciones = richTextBox3.Text;
        }

        bool cerrar;
        private void Guardar()
        {


            string query = "";
            Paciente P = new Paciente();
            CargarPaciente(P);
            //MessageBox.Show(Convert.ToString(P.pFechaNac));

            if (Nuevo == true)
            {
                if (validar())
                {
                    query = "insert into Pacientes (Apellido,Nombre,Documento,Direccion,CPostal,IdProvincia,Ciudad,TelefonoF,TelefonoM,Email,ObraSocial,IdObrasocial,NroAfiliado,FechaAlta,idSexo,FechaNac) values ('" + P.pApellido + "', '" + P.pNombre + "', '" + P.pDocumento + "', '" + P.pDireccion + "', '" + P.pCPostal + "'," + P.pProvincia + ", '" + P.pCiudad + "','" + P.pTelefonoF + "', '" + P.pTelefonoM + "', '" + P.pEmail + "', " + P.pObraSocial + "," + P.pIdObrasocial + ",'" + P.pNroAfiliado + "','" + P.pFechaAlta + "'," + P.pSexo + ",'" + P.pFechaNac + "')";
                    Datos.Actualizar(query);
                    cerrar = true;
                }
                
            }

            if (Nuevo == false)
            {
                P.pIdPaciente = Convert.ToInt32(IDpaciente);

                query = "update Pacientes set Apellido='" + P.pApellido + "',Nombre='" + P.pNombre + "',Documento='" + P.pDocumento + "',Direccion='" + P.pDireccion + "',CPostal='" + P.pCPostal + "',IdProvincia=" + P.pProvincia + ",Ciudad='" + P.pCiudad + "',TelefonoF='" + P.pTelefonoF + "',TelefonoM='" + P.pTelefonoM + "',Email='" + P.pEmail + "',ObraSocial=" + P.pObraSocial + ",IdObrasocial=" + P.pIdObrasocial + ",NroAfiliado='" + P.pNroAfiliado + "',FechaAlta='" + P.pFechaAlta +"',idSexo= "+ P.pSexo+",FechaNac= '"+P.pFechaNac+"' where idPaciente =" + P.pIdPaciente;
                Datos.Actualizar(query);
            }

            

            

            //this.Close();
            

        }
        private void GuardarConsulta()
        {
            if (nuevaConsulta == true)
            {
                string queryConsulta = "";
                Consulta C = new Consulta();
                CargarConsulta(C);

                queryConsulta = "insert into Consulta(idPaciente,idMedico,idPractica,idDiagnostico,fechaConsulta,motivo,aclaraciones) values(" + C.pIdPaciente + "," + C.pIdMedico + "," + C.pidPractica + "," + C.pidDiagnostico + ",'" + C.pFechaConsulta + "','"+C.pMotivo+"','"+C.pAclaraciones+"')";


                Datos.Actualizar(queryConsulta);
            }
            
        }
        private bool validar()
        {
            string apellido = null;
            Datos.LeerDataReader("select Apellido from Pacientes where Documento ='"+txtDocumento.Text+"'");

            while (Datos.pDr.Read())
            {

                if (!Datos.pDr.IsDBNull(0))
                {
                    apellido = Datos.pDr.GetString(0);
                }

            }
            Datos.pDr.Close();
            Datos.Desconectar();

            if (apellido != null)
            {
                MessageBox.Show("Ya se encuentra un Paciente registrado con ese DNI");
                return false;
            }

            return true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            
            Guardar();
            GuardarConsulta();
            
            if (cerrar)
            {
                this.Close();
            }
        }
                
        



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formAltaPacientes_Load(object sender, EventArgs e)
        {


            rbtnMasculino.Checked = true;
            

            if (Nuevo==false)
            {
                txtNroPac.Text = Convert.ToString(IDpaciente);
                txtNombre.Text = NombrePac;
                txtApellido.Text = ApellidoPac;
                txtDocumento.Text = Documento;
                txtDireccion.Text = Direccion;
                txtCPostal.Text = cPostal;
                txtTelefonoF.Text = TelefonoF;
                txtTelefonoM.Text = TelefonoM;
                txtCiudad.Text = Ciudad;
                txtNroafiliado.Text = NroAfiliado;
                txtEmail.Text = Email;
                
                //txtFecha.Text = Convert.ToString(FechaAlta);
                dtpFechaalta.Value = Convert.ToDateTime(FechaAlta);
                cboObrasocial.SelectedIndex = Convert.ToInt32(IDObrasocial)-1;
                cboProvincia.SelectedIndex = Convert.ToInt32(Provincia)-1;

                

                if (Sexo == 1)
                {
                    rbtnMasculino.Checked = true;
                }
                if (Sexo == 2)
                {
                    rbtnFemenino.Checked = true;
                }

                txtaaaa.Text = txtdd.Text = txtmm.Text = "";

                string formatdd = ("dd");
                string formatmm = ("MM");
                string formataaaa = ("yyyy");

                txtdd.Text = fechaNac.ToString(formatdd);
                txtmm.Text = fechaNac.ToString(formatmm);
                txtaaaa.Text = fechaNac.ToString(formataaaa);
               
            }
            if (Nuevo == true)
            {
                Datos.LeerDataReader("select max(idPaciente) from pacientes");

                while (Datos.pDr.Read())
                {

                    if (!Datos.pDr.IsDBNull(0))
                    {
                        posibleID = Convert.ToString(Datos.pDr.GetInt32(0)+1);
                    }

                }
                Datos.pDr.Close();
                Datos.Desconectar();
                txtNroPac.Text = posibleID;
            }

            





        }

        private void cbxObrasocial_CheckStateChanged(object sender, EventArgs e)
        {

        }



        public string NombrePac { get; set; }
        public string ApellidoPac { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string cPostal { get; set; }
        public string Email { get; set; }
        public string Ciudad { get; set; }
        public string TelefonoF { get; set; }
        public string TelefonoM { get; set; }
        public int IDpaciente { get; set; }
        public int ObraSocial { get; set; }
        public string NroAfiliado { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Sexo { get; set; }
        
        public int Provincia { get; set; }

        public int IDObrasocial { get; set; }

        public bool Nuevo { get; set; }
        
        public string posibleID { get; set; }

        private void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
            //Guardar();


            if (richTextBox1.Enabled == false)
            {
                label19.Enabled = true;
                label20.Enabled = true;
                label19.BackColor = Color.White;
                label20.BackColor = Color.White;
                CargarCombo("Especialidad", cboEspecialidad);
                EspecialidadSeleccionada = Convert.ToInt32(cboEspecialidad.SelectedValue);
                CargarComboMedico("Medicos", cboMedico);
                CargarComboPracticas("Practicas", cboPracticas);
                CargarComboDiagnosticos("Diagnosticos", cboDiagnostico);
                label16.Enabled = true;
                label28.Enabled = true;
                label18.Enabled = true;
                cboMedico.Enabled = true;
                cboEspecialidad.Enabled = true;
                dateTimePicker1.Enabled = true;
                richTextBox3.Enabled = true;
                richTextBox1.Enabled = true;
                cboDiagnostico.Enabled = true;
                cboPracticas.Enabled = true;
                nuevaConsulta = true;
            }
            else
            {
                label19.Enabled = false;
                label20.Enabled = false;
                label19.BackColor = Color.WhiteSmoke;
                label20.BackColor = Color.WhiteSmoke;
                label16.Enabled = false;
                label18.Enabled = false;
                cboMedico.Enabled = false;
                cboEspecialidad.Enabled = false;
                label28.Enabled = false;
                dateTimePicker1.Enabled = false;
                richTextBox3.Enabled = false;
                richTextBox1.Enabled = false;
                cboDiagnostico.Enabled = false;
                cboPracticas.Enabled = false;
                nuevaConsulta = false;
            }

            
        }

        private void CargarLista(string tabla)
        {
            int c = 0;
            string fechaConsulta = "" ;
            Datos.LeerDataReader("select fechaConsulta, ApellidoMedico,  motivo,  practica, diagnostico, aclaraciones from Medicos m, Consulta c, practicas p, diagnosticos d where m.idMedico = c.idMedico and p.idPractica = c.idPractica and d.idDiagnostico = c.idDiagnostico and c.idPaciente =" + IDpaciente);
            
            lstFechas.Items.Clear();

            while (Datos.pDr.Read())
            {
                VP[c] = new Consulta();
                
                if (!Datos.pDr.IsDBNull(0))
                {
                    VP[c].pFechaConsulta = Datos.pDr.GetDateTime(0);
                    fechaConsulta = Convert.ToString(VP[c].pFechaConsulta);
                }
                if (!Datos.pDr.IsDBNull(1))
                {
                    VP[c].pApeMedico = Datos.pDr.GetString(1);
                }
                if (!Datos.pDr.IsDBNull(2))
                {
                    VP[c].pMotivo = Datos.pDr.GetString(2);
                }
                if (!Datos.pDr.IsDBNull(3))
                {
                    VP[c].pPrestacion = Datos.pDr.GetString(3);
                }
                if (!Datos.pDr.IsDBNull(4))
                {
                    VP[c].pDiagnostico = Datos.pDr.GetString(4);
                }
                if (!Datos.pDr.IsDBNull(5))
                {
                    VP[c].pAclaraciones = Datos.pDr.GetString(5);
                }

                c++;
            }

            Datos.pDr.Close();
            Datos.Desconectar();
            lstFechas.Items.Clear();
            for (int i = 0; i < c; i++)
            {
                lstFechas.Items.Add(VP[i].pFechaConsulta);
                
                
            }
            lstFechas.SelectedIndex = c - 1;
            
            
        }


        bool nuevaConsulta = false;

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLista("Consulta");
        }

        private void lstFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAntecedentes(lstFechas.SelectedIndex);
        }
        private void CargarAntecedentes(int posicion)
        {
            richTextBox2.Text = " Atendido por el Doctor: " + VP[posicion].pApeMedico + "\n\n"
                + VP[posicion].pMotivo + "\n\n"
                + " Prestacion realizada: " + VP[posicion].pPrestacion + "\n\n"
                + " Diagnostico: " + VP[posicion].pDiagnostico + "\n\n"
                + VP[posicion].pAclaraciones + "\n\n";

                
        }


        public DateTime fechaNac { get; set; }

        public int EspecialidadSeleccionada { get; set; }

        private void cboEspecialidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EspecialidadSeleccionada = Convert.ToInt32(cboEspecialidad.SelectedValue);
            CargarComboMedico("Medicos", cboMedico);
            cboPracticas.DataSource = null;
            CargarComboPracticas("Practicas", cboPracticas);
            cboDiagnostico.DataSource = null;
            CargarComboDiagnosticos("Diagnosticos", cboDiagnostico);
        }
    }
}
