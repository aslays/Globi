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
    public partial class formProveedores : Form
    {
        BaseDatos Datos = new BaseDatos(@"Data Source=CASA06;Initial Catalog=Globi;Integrated Security=True");

        DataSet resultados = new DataSet();
        DataView mifiltro;


        public formProveedores()
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
            dt = Datos.Leer("select * from Proveedores" + tabla);

            dgv.DataSource = dt;
        }

        private void btnAltaProveedores_Click(object sender, EventArgs e)
        {
            formAltaProveedores AltaProveedores = new formAltaProveedores();
            AltaProveedores.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAltaProveedores_FormClosed);
            bool nuevo = true;
            AltaProveedores.Nuevo = nuevo;

            AltaProveedores.Show();
        }

        private void formAltaProveedores_FormClosed(object sender, FormClosedEventArgs e)
        {
            //CargarLista("Medicos", dgvMedicos);

            this.leer_datos("select * from Proveedores", ref resultados, "Proveedores");
            this.mifiltro = ((DataTable)resultados.Tables["Proveedores"]).DefaultView;
            this.dgvProveedores.DataSource = mifiltro;

            RemoveDuplicate(dgvProveedores);

        }

        public void RemoveDuplicate(DataGridView dgvProveedores)
        {
            for (int currentRow = 0; currentRow < dgvProveedores.Rows.Count - 1; currentRow++)
            {
                DataGridViewRow rowToCompare = dgvProveedores.Rows[currentRow];

                for (int otherRow = currentRow + 1; otherRow < dgvProveedores.Rows.Count; otherRow++)
                {
                    DataGridViewRow row = dgvProveedores.Rows[otherRow];

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
                        dgvProveedores.Rows.Remove(row);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formProveedores_Load(object sender, EventArgs e)
        {
            this.leer_datos("select * from Proveedores", ref resultados, "Proveedores");
            this.mifiltro = ((DataTable)resultados.Tables["Proveedores"]).DefaultView;
            this.dgvProveedores.DataSource = mifiltro;
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarProveedor();
            }

            string salida_datos = "";
            string[] palabras_busqueda = this.txtBuscar.Text.Split(' ');

            foreach (string palabra in palabras_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    salida_datos = "(NOMBRECOMERCIAL LIKE '%" + palabra + "%' OR NOMBRE LIKE '%" + palabra + "%')";
                }
                else
                {
                    salida_datos += " AND (NOMBRECOMERCIAL LIKE '%" + palabra + "%'OR NOMBRE LIKE '%" + palabra + "%')";
                }
            }
            this.mifiltro.RowFilter = salida_datos;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarProveedor();
            }
            if (e.KeyCode == Keys.Back)
            {
                RemoveDuplicate(dgvProveedores);
            }
            if (e.KeyCode == Keys.Delete)
            {
                RemoveDuplicate(dgvProveedores);
            }
        }

        private void cargarProveedor()
        {
            idProv = Convert.ToInt32(this.dgvProveedores.CurrentRow.Cells[0].Value.ToString());

            Datos.LeerDataReader("select * from Proveedores where idProveedor =" + idProv);

            while (Datos.pDr.Read())
            {
                if (!Datos.pDr.IsDBNull(0))
                {
                    idProveedor = Datos.pDr.GetInt32(0);
                }
                if (!Datos.pDr.IsDBNull(1))
                {
                    nombre = Datos.pDr.GetString(1);
                }
                if (!Datos.pDr.IsDBNull(2))
                {
                    nombreCom = Datos.pDr.GetString(2);
                }
                if (!Datos.pDr.IsDBNull(3))
                {
                    direccion = Datos.pDr.GetString(3);
                }
                if (!Datos.pDr.IsDBNull(4))
                {
                    CPostal = Datos.pDr.GetString(4);
                }
                if (!Datos.pDr.IsDBNull(5))
                {
                    email = Datos.pDr.GetString(5);
                }
                if (!Datos.pDr.IsDBNull(6))
                {
                    idProvincia = Datos.pDr.GetInt32(6);
                }
                if (!Datos.pDr.IsDBNull(7))
                {
                    ciudad = Datos.pDr.GetString(7);
                }
                if (!Datos.pDr.IsDBNull(8))
                {
                    telfijo = Datos.pDr.GetString(8);
                }
                if (!Datos.pDr.IsDBNull(9))
                {
                    telmovil = Datos.pDr.GetString(9);
                }
                if (!Datos.pDr.IsDBNull(10))
                {
                    descripcion = Datos.pDr.GetString(10);
                }
                if (!Datos.pDr.IsDBNull(11))
                {
                    notas = Datos.pDr.GetString(11);
                }
                
            }
            Datos.pDr.Close();
            Datos.Desconectar();

            formAltaProveedores AltaProveedores = new formAltaProveedores();

            AltaProveedores.IDProvedor = idProveedor;
            AltaProveedores.Nombre = nombre;
            AltaProveedores.NombreCom = nombreCom;
            AltaProveedores.Direccion = direccion;
            AltaProveedores.CPostal = CPostal;
            AltaProveedores.Email = email;
            AltaProveedores.IDProvincia = idProvincia;
            AltaProveedores.Ciudad = ciudad;
            AltaProveedores.TelFijo = telfijo;
            AltaProveedores.TelMovil = telmovil;
            AltaProveedores.Descripcion = descripcion;
            AltaProveedores.Notas = notas;
           

            AltaProveedores.Nuevo = false;

            DialogResult res = AltaProveedores.ShowDialog();



        }


        public int idProv { get; set; }
        public int idProveedor { get; set; }
        public string nombre { get; set; }
        public string nombreCom { get; set; }
        public string direccion { get; set; }
        public string CPostal { get; set; }
        public string email { get; set; }
        public int idProvincia { get; set; }
        public string ciudad { get; set; }
        public string telfijo { get; set; }
        public string telmovil { get; set; }
        public string descripcion { get; set; }
        public string notas { get; set; }

        private void dgvProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarProveedor();
        }

        private void dgvProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarProveedor();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cargarProveedor();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            //this.leer_datos("SELECT idPaciente,Documento, Apellido, Nombre, Ciudad, Email, TelefonoF'Telefono Fijo', TelefonoM'Telefono Movil', FechaAlta  FROM Pacientes", ref resultados, "Pacientes");
            //this.mifiltro = ((DataTable)resultados.Tables["pacientes"]).DefaultView;
            //this.dgvPacientes.DataSource = mifiltro;
            if (dgvProveedores.RowCount == 0)
            {
                CargarLista("Proveedores", dgvProveedores);
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

                foreach (DataGridViewColumn col in dgvProveedores.Columns)
                {

                    ColumnIndex++;

                    hoja_trabajo.Cells[1, ColumnIndex] = col.Name;

                }

                int rowIndex = 0;

                foreach (DataGridViewRow row in dgvProveedores.Rows)
                {

                    rowIndex++;

                    ColumnIndex = 0;

                    foreach (DataGridViewColumn col in dgvProveedores.Columns)
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
