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
    public partial class formMedicos : Form
    {
        BaseDatos Datos = new BaseDatos(@"Data Source=CASA06;Initial Catalog=Globi;Integrated Security=True");

        DataSet resultados = new DataSet();
        DataView mifiltro;

        public formMedicos()
        {
            InitializeComponent();
        }
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
            dt = Datos.Leer("select ApellidoMedico'Apellido', nombre'Nombre', Especialidad, Email, TelefonoF'Telefomo Fijo', TelefonoM'Telefono Movil',ciudad from Medicos m, Especialidad E where m.idEspecialidad= e.idEspecialidad " + tabla);

            dgv.DataSource = dt;
        }
        private void btnAltaMedico_Click(object sender, EventArgs e)
        {
            formAltaMedicos AltaMedico = new formAltaMedicos();

            AltaMedico.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAltaMedicos_FormClosed);
            bool nuevo = true;
            AltaMedico.Nuevo = nuevo;


            AltaMedico.ShowDialog();
        }

        private void formAltaMedicos_FormClosed(object sender, FormClosedEventArgs e)
        {
            //CargarLista("Medicos", dgvMedicos);

            this.leer_datos("select ApellidoMedico'Apellido', nombre'Nombre', Especialidad, Email, TelefonoF'Telefomo Fijo', TelefonoM'Telefono Movil',ciudad, idMedico from Medicos m, Especialidad E where m.idEspecialidad= e.idEspecialidad", ref resultados, "Medicos");
            this.mifiltro = ((DataTable)resultados.Tables["Medicos"]).DefaultView;
            this.dgvMedicos.DataSource = mifiltro;

            RemoveDuplicate(dgvMedicos);
            
        }

        public void RemoveDuplicate(DataGridView dgvMedicos)
        {
            for (int currentRow = 0; currentRow < dgvMedicos.Rows.Count - 1; currentRow++)
            {
                DataGridViewRow rowToCompare = dgvMedicos.Rows[currentRow];

                for (int otherRow = currentRow + 1; otherRow < dgvMedicos.Rows.Count; otherRow++)
                {
                    DataGridViewRow row = dgvMedicos.Rows[otherRow];

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
                        dgvMedicos.Rows.Remove(row);
                        otherRow--;
                    }
                }
            }
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

        private void formMedicos_Load(object sender, EventArgs e)
        {
            this.leer_datos("select ApellidoMedico'Apellido', nombre'Nombre', Especialidad, Email, TelefonoF'Telefomo Fijo', TelefonoM'Telefono Movil',ciudad, idMedico from Medicos m, Especialidad E where m.idEspecialidad= e.idEspecialidad", ref resultados, "Medicos");
            this.mifiltro = ((DataTable)resultados.Tables["Medicos"]).DefaultView;
            this.dgvMedicos.DataSource = mifiltro;
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarMedico();
            }

            string salida_datos = "";
            string[] palabras_busqueda = this.txtBuscar.Text.Split(' ');

            foreach (string palabra in palabras_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    salida_datos = "(APELLIDO LIKE '%" + palabra  + "%' OR NOMBRE LIKE '%" + palabra + "%')";
                }
                else
                {
                    salida_datos += " AND (APELLIDO LIKE '%" + palabra  + "%'OR NOMBRE LIKE '%" + palabra + "%')";
                }
            }
            this.mifiltro.RowFilter = salida_datos;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarMedico();
            }
            if (e.KeyCode == Keys.Back)
            {
                RemoveDuplicate(dgvMedicos);
            }
            if (e.KeyCode == Keys.Delete)
            {
                RemoveDuplicate(dgvMedicos);
            }
        }

        private void cargarMedico()
        {
            idMed = Convert.ToInt32(this.dgvMedicos.CurrentRow.Cells[7].Value.ToString());

            Datos.LeerDataReader("select * from Medicos where idMedico =" + idMed);

            while (Datos.pDr.Read())
            {
                if (!Datos.pDr.IsDBNull(0))
                {
                    idmedico = Datos.pDr.GetInt32(0);
                }
                if (!Datos.pDr.IsDBNull(1))
                {
                    matricula = Datos.pDr.GetString(1);
                }
                if (!Datos.pDr.IsDBNull(2))
                {
                    nombreMed = Datos.pDr.GetString(2);
                }
                if (!Datos.pDr.IsDBNull(3))
                {
                    apellidoMed = Datos.pDr.GetString(3);
                }
                if (!Datos.pDr.IsDBNull(4))
                {
                    docMed = Datos.pDr.GetString(4);
                }
                if (!Datos.pDr.IsDBNull(5))
                {
                    direMed = Datos.pDr.GetString(5);
                }
                if (!Datos.pDr.IsDBNull(6))
                {
                    cpostalMed = Datos.pDr.GetString(6);
                }
                if (!Datos.pDr.IsDBNull(7))
                {
                    emailMed = Datos.pDr.GetString(7);
                }
                if (!Datos.pDr.IsDBNull(8))
                {
                    idProvmed = Datos.pDr.GetInt32(8);
                }
                if (!Datos.pDr.IsDBNull(9))
                {
                    ciudadMed = Datos.pDr.GetString(9);
                }
                if (!Datos.pDr.IsDBNull(10))
                {
                    telefonoFMed = Datos.pDr.GetString(10);
                }
                if (!Datos.pDr.IsDBNull(11))
                {
                    telefonoMMed = Datos.pDr.GetString(11);
                }
                if (!Datos.pDr.IsDBNull(12))
                {
                    idEspMed = Datos.pDr.GetInt32(12);
                }
                if (!Datos.pDr.IsDBNull(13))
                {
                    notas = Datos.pDr.GetString(13);
                }
                if (!Datos.pDr.IsDBNull(14))
                {
                    ausencias = Datos.pDr.GetString(14);
                }
                if (!Datos.pDr.IsDBNull(15))
                {
                    vacaciones = Datos.pDr.GetString(15);
                }
            }
            Datos.pDr.Close();
            Datos.Desconectar();

            formAltaMedicos AltaMedicos = new formAltaMedicos();

            AltaMedicos.IDMedico = idmedico;
            AltaMedicos.ApellidoMedico = apellidoMed;
            AltaMedicos.Matricula = matricula;
            AltaMedicos.Nombre = nombreMed;
            AltaMedicos.DocMed = docMed;
            AltaMedicos.DireMed = direMed;
            AltaMedicos.CPostal = cpostalMed;
            AltaMedicos.Email = emailMed;
            AltaMedicos.IDprov = idProvmed;
            AltaMedicos.Ciudad = ciudadMed;
            AltaMedicos.TelFijo = telefonoFMed;
            AltaMedicos.TelMovil = telefonoMMed;
            AltaMedicos.IDEspecialidad = idEspMed;
            AltaMedicos.Notas = notas;
            AltaMedicos.Ausencias = ausencias;
            AltaMedicos.Vacaciones = vacaciones;

            AltaMedicos.Nuevo = false;

            DialogResult res = AltaMedicos.ShowDialog();


        }

        public int idMed { set; get; }
        public string apellidoMed { get; set; }
        public int idmedico { get; set; }
        public string matricula { get; set; }
        public string nombreMed { get; set; }
        public string docMed { get; set; }
        public string direMed { get; set; }
        public string cpostalMed { get; set; }
        public string emailMed { get; set; }
        public int idProvmed { get; set; }
        public string ciudadMed { get; set; }
        public string telefonoFMed { get; set; }
        public string telefonoMMed { get; set; }
        public int idEspMed { get; set; }
        public string notas { get; set; }
        public string ausencias { get; set; }
        public string vacaciones { get; set; }

        private void dgvMedicos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarMedico();
        }

        private void dgvMedicos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarMedico();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cargarMedico();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            //this.leer_datos("SELECT idPaciente,Documento, Apellido, Nombre, Ciudad, Email, TelefonoF'Telefono Fijo', TelefonoM'Telefono Movil', FechaAlta  FROM Pacientes", ref resultados, "Pacientes");
            //this.mifiltro = ((DataTable)resultados.Tables["pacientes"]).DefaultView;
            //this.dgvPacientes.DataSource = mifiltro;
            if (dgvMedicos.RowCount == 0)
            {
                CargarLista("Medicos", dgvMedicos);
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

                foreach (DataGridViewColumn col in dgvMedicos.Columns)
                {

                    ColumnIndex++;

                    hoja_trabajo.Cells[1, ColumnIndex] = col.Name;

                }

                int rowIndex = 0;

                foreach (DataGridViewRow row in dgvMedicos.Rows)
                {

                    rowIndex++;

                    ColumnIndex = 0;

                    foreach (DataGridViewColumn col in dgvMedicos.Columns)
                    {

                        ColumnIndex++;

                        hoja_trabajo.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;

                    }

                }
                libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                hoja_trabajo.Columns.AutoFit(); //Ajusta ancho de todas las columnas 
                libros_trabajo.Close(true);
                //aplicacion.Visible = true; 
                aplicacion.Quit();
                //dgvProveedores.DataSource = null;


            }
        }
    }
}
