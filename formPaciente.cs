using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace Globi
{
    public partial class formPaciente : Form
    {
        //Globi.DataBase Datos = new Globi.DataBase(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Ariel\Documents\Pacientes.mdb");
        BaseDatos Datos = new BaseDatos(@"Data Source=CASA06;Initial Catalog=Globi;Integrated Security=True");
        //Paciente[]PA = new Paciente[100];

        public formPaciente()
        {
            InitializeComponent();
            //CargarLista("Pacientes", dgvPacientes);
            
            
                        
        }
        
        DataSet resultados = new DataSet();
        DataView mifiltro;

        public void leer_datos(string query, ref DataSet dstprincipal, string tabla)
        {
            try
            {
                string cadena = @"Data Source=CASA06;Initial Catalog=Globi;Integrated Security=True";
                SqlConnection cn = new SqlConnection(cadena);
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dstprincipal, tabla);
                da.Dispose();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


        }
        

        private void CargarLista(string tabla, DataGridView dgv)
        {
            DataTable dt = new DataTable();
            dt = Datos.Leer("select * from " + tabla);

            dgv.DataSource = dt;
        }

        private void btnAltaPacientes_Click(object sender, EventArgs e)
        {

            altaPaciente();
            
            
        }
        private void altaPaciente()
        {
            formAltaPacientes Altapacientes = new formAltaPacientes();

            Altapacientes.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAltaPacientes_FormClosed);

            bool nuevo = true;
            Altapacientes.Nuevo = nuevo;

            Altapacientes.Show();

            

        }

        private void formAltaPacientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            //CargarLista("Pacientes", dgvPacientes);

            //this.leer_datos("SELECT Documento, Apellido, Nombre, Ciudad, Email, TelefonoF'Telefono Fijo', TelefonoM'Telefono Movil', FechaAlta, idPaciente  FROM Pacientes", ref resultados, "Pacientes");
            //this.mifiltro = ((DataTable)resultados.Tables["pacientes"]).DefaultView;
            //this.dgvPacientes.DataSource = mifiltro;

            RemoveDuplicate(dgvPacientes);
                         
                       
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            //this.leer_datos("SELECT idPaciente,Documento, Apellido, Nombre, Ciudad, Email, TelefonoF'Telefono Fijo', TelefonoM'Telefono Movil', FechaAlta  FROM Pacientes", ref resultados, "Pacientes");
            //this.mifiltro = ((DataTable)resultados.Tables["pacientes"]).DefaultView;
            //this.dgvPacientes.DataSource = mifiltro;
            if (dgvPacientes.RowCount==0)
            {
                CargarLista("Pacientes",dgvPacientes);
            }
            

            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //Recorremos el DataGridView rellenando la hoja de trabajo
                int ColumnIndex = 0;

                foreach (DataGridViewColumn col in dgvPacientes.Columns)
                {

                    ColumnIndex++;

                    hoja_trabajo.Cells[1, ColumnIndex] = col.Name;

                }

                int rowIndex = 0;

                foreach (DataGridViewRow row in dgvPacientes.Rows)
                {

                    rowIndex++;

                    ColumnIndex = 0;

                    foreach (DataGridViewColumn col in dgvPacientes.Columns)
                    {

                        ColumnIndex++;

                        hoja_trabajo.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;

                    }

                }
                libros_trabajo.SaveAs(fichero.FileName,Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                hoja_trabajo.Columns.AutoFit(); //Ajusta ancho de todas las columnas 
                libros_trabajo.Close(true);
                //aplicacion.Visible = true; 
                aplicacion.Quit();
                dgvPacientes.DataSource = null;

                
            }

                      
        }

        private void btnCancelarPac_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dgvPacientes.Width, this.dgvPacientes.Height);
            dgvPacientes.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvPacientes.Width, this.dgvPacientes.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void btnImprimPac_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }


        

        private void formPaciente_Load(object sender, EventArgs e)
        {
            //this.leer_datos("SELECT Documento, Apellido, Nombre, Ciudad, Email, TelefonoF'Telefono Fijo', TelefonoM'Telefono Movil', FechaAlta, idPaciente  FROM Pacientes", ref resultados, "Pacientes");
            //this.mifiltro = ((DataTable)resultados.Tables["pacientes"]).DefaultView;
            //this.dgvPacientes.DataSource = mifiltro;
            
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {

            
            if (e.KeyCode == Keys.Back)
            {
                RemoveDuplicate(dgvPacientes);
                dgvPacientes.DataSource = null;
            }
            if (e.KeyCode == Keys.Delete)
            {
                RemoveDuplicate(dgvPacientes);
                dgvPacientes.DataSource = null;
            }

            if (txtBuscar.Text.Length >= 2)
            {
                this.leer_datos("SELECT Documento, Apellido, Nombre, Ciudad, Email, TelefonoF'Telefono Fijo', TelefonoM'Telefono Movil', FechaAlta, idPaciente  FROM Pacientes", ref resultados, "Pacientes");
                this.mifiltro = ((DataTable)resultados.Tables["pacientes"]).DefaultView;
                this.dgvPacientes.DataSource = mifiltro;



                string salida_datos = "";
                string[] palabras_busqueda = this.txtBuscar.Text.Split(' ');

                foreach (string palabra in palabras_busqueda)
                {
                    if (salida_datos.Length == 0)
                    {
                        salida_datos = "(APELLIDO LIKE '%" + palabra + "%'OR Documento LIKE '%" + palabra + "%' OR NOMBRE LIKE '%" + palabra + "%')";
                    }
                    else
                    {
                        salida_datos += " AND (APELLIDO LIKE '%" + palabra + "%'OR Documento LIKE '%" + palabra + "%'OR NOMBRE LIKE '%" + palabra + "%')";
                    }
                }
                this.mifiltro.RowFilter = salida_datos;
                RemoveDuplicate(dgvPacientes);

                if (e.KeyCode == Keys.Enter)
                {
                    cargarConsulta();
                }
            }
        }

        private void dgvPacientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            cargarConsulta();
            
        }

        public void RemoveDuplicate(DataGridView dgvPacientes)
        {
            for (int currentRow = 0; currentRow < dgvPacientes.Rows.Count - 1; currentRow++)
            {
                DataGridViewRow rowToCompare = dgvPacientes.Rows[currentRow];

                for (int otherRow = currentRow + 1; otherRow < dgvPacientes.Rows.Count; otherRow++)
                {
                    DataGridViewRow row = dgvPacientes.Rows[otherRow];

                    bool duplicateRow = true;

                    for (int cellIndex = 0; cellIndex < row.Cells.Count; cellIndex++)
                    {
                        if (!rowToCompare.Cells[cellIndex].Value.Equals(row.Cells[cellIndex].Value))
                        {
                            duplicateRow = false;
                            break;
                        }
                    }

                    if (duplicateRow)
                    {
                        dgvPacientes.Rows.Remove(row);
                        otherRow--;
                    }
                }
            }
        }

        private void cargarConsulta()
        {
            idPac = Convert.ToInt32(this.dgvPacientes.CurrentRow.Cells[8].Value.ToString()); 

            Datos.LeerDataReader("select * from Pacientes where idPaciente ="+idPac);

            while (Datos.pDr.Read())
            {
                if (!Datos.pDr.IsDBNull(1))
                {
                    apellidoPac = Datos.pDr.GetString(1);
                }
                if (!Datos.pDr.IsDBNull(2))
                {
                    nombrePac = Datos.pDr.GetString(2);
                }
                if (!Datos.pDr.IsDBNull(3))
                {
                    documentoPac = Datos.pDr.GetString(3);
                }
                if (!Datos.pDr.IsDBNull(4))
                {
                    direccionPac = Datos.pDr.GetString(4);
                }
                if (!Datos.pDr.IsDBNull(5))
                {
                    cpostalPac = Datos.pDr.GetString(5);
                }
                if (!Datos.pDr.IsDBNull(6))
                {
                    provinciaPac = Datos.pDr.GetInt32(6);
                }
                if (!Datos.pDr.IsDBNull(7))
                {
                    ciudadPac = Datos.pDr.GetString(7);
                }
                if (!Datos.pDr.IsDBNull(8))
                {
                    telefonofijoPac = Datos.pDr.GetString(8);
                }
                if (!Datos.pDr.IsDBNull(9))
                {
                    telefonomovilPac = Datos.pDr.GetString(9);
                }
                if (!Datos.pDr.IsDBNull(10))
                {
                    emailPac = Datos.pDr.GetString(10);
                }
                if (!Datos.pDr.IsDBNull(11))
                {
                    obrasocPac = Datos.pDr.GetInt32(11);
                }
                if (!Datos.pDr.IsDBNull(12))
                {
                    idObrasocialPac = Datos.pDr.GetInt32(12);
                }
                if (!Datos.pDr.IsDBNull(13))
                {
                    nroAfiliadoPac = Datos.pDr.GetString(13);
                }
                if (!Datos.pDr.IsDBNull(14))
                {
                    fechaaltaPac = Datos.pDr.GetDateTime(14);
                }
                if (!Datos.pDr.IsDBNull(15))
                {
                    sexo = Datos.pDr.GetInt32(15);
                }
                if (!Datos.pDr.IsDBNull(16))
                {
                    fechanac = Datos.pDr.GetDateTime(16);
                }
            }
            Datos.pDr.Close();
            Datos.Desconectar();

            //idPac = Convert.ToInt32(this.dgvPacientes.CurrentRow.Cells[0].Value.ToString());
            //nombrePac = this.dgvPacientes.CurrentRow.Cells[2].Value.ToString();
            //apellidoPac = this.dgvPacientes.CurrentRow.Cells[1].Value.ToString();
            //documentoPac = this.dgvPacientes.CurrentRow.Cells[3].Value.ToString();
            //direccionPac = this.dgvPacientes.CurrentRow.Cells[4].Value.ToString();
            //cpostalPac = this.dgvPacientes.CurrentRow.Cells[5].Value.ToString();
            //provinciaPac = Convert.ToInt32(this.dgvPacientes.CurrentRow.Cells[6].Value.ToString());
            //ciudadPac = this.dgvPacientes.CurrentRow.Cells[7].Value.ToString();
            //emailPac = this.dgvPacientes.CurrentRow.Cells[10].Value.ToString();
            //telefonofijoPac = this.dgvPacientes.CurrentRow.Cells[8].Value.ToString();
            //telefonomovilPac = this.dgvPacientes.CurrentRow.Cells[9].Value.ToString();
            //nroAfiliadoPac = this.dgvPacientes.CurrentRow.Cells[13].Value.ToString();
            //obrasocPac = Convert.ToInt32(this.dgvPacientes.CurrentRow.Cells[11].Value.ToString());
            //fechaaltaPac = Convert.ToDateTime(this.dgvPacientes.CurrentRow.Cells[14].Value.ToString());
            //idObrasocialPac = Convert.ToInt32(this.dgvPacientes.CurrentRow.Cells[12].Value.ToString());


            formAltaPacientes Altapacientes = new formAltaPacientes();
            
            Altapacientes.NombrePac = nombrePac;
            Altapacientes.ApellidoPac = apellidoPac;
            Altapacientes.Documento = documentoPac;
            Altapacientes.Direccion = direccionPac;
            Altapacientes.cPostal = cpostalPac;
            Altapacientes.Email = emailPac;
            Altapacientes.TelefonoF = telefonofijoPac;
            Altapacientes.TelefonoM = telefonomovilPac;
            Altapacientes.IDpaciente = idPac;
            Altapacientes.ObraSocial = obrasocPac;
            Altapacientes.NroAfiliado = nroAfiliadoPac;
            Altapacientes.FechaAlta = fechaaltaPac;
            Altapacientes.IDObrasocial = idObrasocialPac;

            Altapacientes.Provincia = provinciaPac;
            Altapacientes.Ciudad = ciudadPac;
            Altapacientes.Sexo = sexo;
            Altapacientes.fechaNac = fechanac;

            Altapacientes.Nuevo = false;


            DialogResult res = Altapacientes.ShowDialog();
            

            if (res == DialogResult.OK)
            {
                

                //this.leer_datos("SELECT Apellido, Nombre, Documento, Ciudad, Email, TelefonoF'Telefono Fijo', TelefonoM'Telefono Movil', FechaAlta, idPaciente  FROM Pacientes", ref resultados, "Pacientes");
                //this.mifiltro = ((DataTable)resultados.Tables["pacientes"]).DefaultView;
                //CargarLista("Pacientes", dgvPacientes);
                //this.dgvPacientes.DataSource = mifiltro;

                //RemoveDuplicate(dgvPacientes);
            }

        }


        
        public string nombrePac { get; set; }
        public string apellidoPac { get; set; }
        public string documentoPac { get; set; }
        public string direccionPac { get; set; }
        public string cpostalPac { get; set; }
        public string emailPac { set; get; }
        public string ciudadPac { set; get; }
        public int provinciaPac { set; get; }
        public string telefonofijoPac { set; get; }
        public string telefonomovilPac { set; get; }
        public int idPac { set; get; }
        public int obrasocPac {set; get;}
        public string nroAfiliadoPac { set; get; }
        public DateTime fechaaltaPac { set; get; }
        public int idObrasocialPac { set; get; }
        public int sexo { set; get; }
        public DateTime fechanac { set; get; }

        private void dgvPacientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarConsulta();
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                RemoveDuplicate(dgvPacientes);
            }
            if (e.KeyCode == Keys.Delete)
            {
                RemoveDuplicate(dgvPacientes);
            }
            if (e.KeyCode == Keys.Control)
            {
                dgvPacientes.DataSource = null;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cargarConsulta();
        }
    }
    
}
