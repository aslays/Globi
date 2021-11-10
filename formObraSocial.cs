using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.SqlClient;


namespace Globi
{
    public partial class formObraSocial : Form
    {
        BaseDatos Datos = new BaseDatos(@"Data Source=CASA06;Initial Catalog=Globi;Integrated Security=True");

        DataSet resultados = new DataSet();
        DataView mifiltro;

        public formObraSocial()
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
            dt = Datos.Leer("select * from ObrasSociales " + tabla);

            dgv.DataSource = dt;
        }

        private void btnAltaObraSocial_Click(object sender, EventArgs e)
        {
            formAltaObraSocial AltaObraSocial = new formAltaObraSocial();
            AltaObraSocial.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAltaObraSocial_FormClosed);
            bool nuevo = true;
            AltaObraSocial.Nuevo = nuevo;

            AltaObraSocial.ShowDialog();
        }
        private void formAltaObraSocial_FormClosed(object sender, FormClosedEventArgs e)
        {
            //CargarLista("Medicos", dgvMedicos);

            this.leer_datos("select Nombre,Nombrelegal'Nombre Legal',Telefono1'Telefono 1',Telefono2'Telefono 2', Email, web, Direccion,idObraSocial'ID' from ObrasSociales", ref resultados, "ObrasSociales");
            this.mifiltro = ((DataTable)resultados.Tables["ObrasSociales"]).DefaultView;
            this.dgvObraSocial.DataSource = mifiltro;

            RemoveDuplicate(dgvObraSocial);

        }

        public void RemoveDuplicate(DataGridView dgvObraSocial)
        {
            for (int currentRow = 0; currentRow < dgvObraSocial.Rows.Count - 1; currentRow++)
            {
                DataGridViewRow rowToCompare = dgvObraSocial.Rows[currentRow];

                for (int otherRow = currentRow + 1; otherRow < dgvObraSocial.Rows.Count; otherRow++)
                {
                    DataGridViewRow row = dgvObraSocial.Rows[otherRow];

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
                        dgvObraSocial.Rows.Remove(row);
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

        private void formObraSocial_Load(object sender, EventArgs e)
        {
            this.leer_datos("select Nombre,Nombrelegal'Nombre Legal',Telefono1'Telefono 1',Telefono2'Telefono 2', Email, web, Direccion,idObraSocial'ID' from ObrasSociales", ref resultados, "ObrasSociales");
            this.mifiltro = ((DataTable)resultados.Tables["ObrasSociales"]).DefaultView;
            this.dgvObraSocial.DataSource = mifiltro;
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarObraSocial();
            }

            string salida_datos = "";
            string[] palabras_busqueda = this.txtBuscar.Text.Split(' ');

            foreach (string palabra in palabras_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    salida_datos = "(Nombre LIKE '%" + palabra + "%')";
                }
                else
                {
                    salida_datos += " AND (Nombre LIKE '%" + palabra + "%')";
                }
            }
            this.mifiltro.RowFilter = salida_datos;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarObraSocial();
            }
            if (e.KeyCode == Keys.Back)
            {
                RemoveDuplicate(dgvObraSocial);
            }
            if (e.KeyCode == Keys.Delete)
            {
                RemoveDuplicate(dgvObraSocial);
            }
        }

        private void CargarObraSocial()
        {
            idObraSocial = Convert.ToInt32(this.dgvObraSocial.CurrentRow.Cells[7].Value.ToString());

            Datos.LeerDataReader("select * from ObrasSociales where idObraSocial =" + idObraSocial);

            while (Datos.pDr.Read())
            {
                
                if (!Datos.pDr.IsDBNull(1))
                {
                    nombre = Datos.pDr.GetString(1);
                }
                if (!Datos.pDr.IsDBNull(2))
                {
                    nombrelegal = Datos.pDr.GetString(2);
                }
                if (!Datos.pDr.IsDBNull(3))
                {
                    cuit = Datos.pDr.GetString(3);
                }
                if (!Datos.pDr.IsDBNull(4))
                {
                    direccion = Datos.pDr.GetString(4);
                }
                if (!Datos.pDr.IsDBNull(5))
                {
                    telefono1 = Datos.pDr.GetString(5);
                }
                if (!Datos.pDr.IsDBNull(5))
                {
                    telefono2 = Datos.pDr.GetString(5);
                }
                if (!Datos.pDr.IsDBNull(7))
                {
                    telefonofax = Datos.pDr.GetString(7);
                }
                if (!Datos.pDr.IsDBNull(8))
                {
                    cpostal = Datos.pDr.GetString(8);
                }
                if (!Datos.pDr.IsDBNull(9))
                {
                    email = Datos.pDr.GetString(9);
                }
                if (!Datos.pDr.IsDBNull(10))
                {
                    idprovincia = Datos.pDr.GetInt32(10);
                }
                if (!Datos.pDr.IsDBNull(11))
                {
                    ciudad = Datos.pDr.GetString(11);
                }
                if (!Datos.pDr.IsDBNull(12))
                {
                    web = Datos.pDr.GetString(12);
                }
                if (!Datos.pDr.IsDBNull(13))
                {
                    notas = Datos.pDr.GetString(13);
                }

            }
            Datos.pDr.Close();
            Datos.Desconectar();

            formAltaObraSocial AltaObraSocial = new formAltaObraSocial();

            AltaObraSocial.idObraSocial = idObraSocial;
            AltaObraSocial.nombrelegal = nombrelegal;
            AltaObraSocial.nombre = nombre;
            AltaObraSocial.direccion = direccion;
            AltaObraSocial.cpostal = cpostal;
            AltaObraSocial.email = email;
            AltaObraSocial.idprovincia = idprovincia;
            AltaObraSocial.ciudad = ciudad;
            AltaObraSocial.telefono1 = telefono1;
            AltaObraSocial.telefono2 = telefono2;
            AltaObraSocial.telefonofax = telefonofax;
            AltaObraSocial.notas = notas;
            AltaObraSocial.web = web;
            AltaObraSocial.cuit = cuit;


            AltaObraSocial.Nuevo = false;

            DialogResult res = AltaObraSocial.ShowDialog();
        }

        public int idObraSocial { get; set; }
        public string nombre { get; set; }
        public string nombrelegal { get; set; }
        public string cuit { get; set; }
        public string direccion { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string telefonofax { get; set; }
        public string cpostal { get; set; }
        public string email { get; set; }
        public int idprovincia { get; set; }
        public string ciudad { get; set; }
        public string web { get; set; }
        public string notas { get; set; }

        private void dgvObraSocial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarObraSocial();
        }

        private void dgvObraSocial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarObraSocial();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            CargarObraSocial();
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
            if (dgvObraSocial.RowCount == 0)
            {
                CargarLista("ObrasSociales", dgvObraSocial);
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

                foreach (DataGridViewColumn col in dgvObraSocial.Columns)
                {

                    ColumnIndex++;

                    hoja_trabajo.Cells[1, ColumnIndex] = col.Name;

                }

                int rowIndex = 0;

                foreach (DataGridViewRow row in dgvObraSocial.Rows)
                {

                    rowIndex++;

                    ColumnIndex = 0;

                    foreach (DataGridViewColumn col in dgvObraSocial.Columns)
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
