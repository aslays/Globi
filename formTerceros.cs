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
    public partial class formTerceros : Form
    {
        BaseDatos Datos = new BaseDatos(@"Data Source=CASA06;Initial Catalog=Globi;Integrated Security=True");

        DataSet resultados = new DataSet();
        DataView mifiltro;

        public formTerceros()
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
            dt = Datos.Leer("select * from Terceros " + tabla);

            dgv.DataSource = dt;
        }

        

        private void btnAltaContactos_Click(object sender, EventArgs e)
        {
            formAltaTerceros AltaTerceros = new formAltaTerceros();

            AltaTerceros.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAltaTerceros_FormClosed);
            bool nuevo = true;
            AltaTerceros.Nuevo = nuevo;

            AltaTerceros.ShowDialog();
        }

        private void formAltaTerceros_FormClosed(object sender, FormClosedEventArgs e)
        {
            //CargarLista("Medicos", dgvMedicos);

            this.leer_datos("select Apellido'Apellido', nombre'Nombre', Email, TelFijo'Telefomo Fijo', TelMovil'Telefono Movil',ciudad, idTercero from Terceros", ref resultados, "Terceros");
            this.mifiltro = ((DataTable)resultados.Tables["Terceros"]).DefaultView;
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

        private void formTerceros_Load(object sender, EventArgs e)
        {
            this.leer_datos("select Apellido'Apellido', nombre'Nombre', Email, TelFijo'Telefomo Fijo', TelMovil'Telefono Movil',ciudad 'Ciudad', idTercero'ID' from Terceros", ref resultados, "Terceros");
            this.mifiltro = ((DataTable)resultados.Tables["Terceros"]).DefaultView;
            this.dgvMedicos.DataSource = mifiltro;
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarTercero();
            }

            string salida_datos = "";
            string[] palabras_busqueda = this.txtBuscar.Text.Split(' ');

            foreach (string palabra in palabras_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    salida_datos = "(APELLIDO LIKE '%" + palabra + "%' OR NOMBRE LIKE '%" + palabra + "%')";
                }
                else
                {
                    salida_datos += " AND (APELLIDO LIKE '%" + palabra + "%'OR NOMBRE LIKE '%" + palabra + "%')";
                }
            }
            this.mifiltro.RowFilter = salida_datos;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarTercero();
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

        private void cargarTercero()
        {
            idTercero = Convert.ToInt32(this.dgvMedicos.CurrentRow.Cells[6].Value.ToString());

            Datos.LeerDataReader("select * from Terceros where idTercero =" + idTercero);

            while (Datos.pDr.Read())
            {
                if (!Datos.pDr.IsDBNull(0))
                {
                    idtercero = Datos.pDr.GetInt32(0);
                }
                if (!Datos.pDr.IsDBNull(1))
                {
                    apellido = Datos.pDr.GetString(1);
                }
                if (!Datos.pDr.IsDBNull(2))
                {
                    nombre = Datos.pDr.GetString(2);
                }
                if (!Datos.pDr.IsDBNull(3))
                {
                    direccion = Datos.pDr.GetString(3);
                }
                if (!Datos.pDr.IsDBNull(4))
                {
                    cpostal = Datos.pDr.GetString(4);
                }
                if (!Datos.pDr.IsDBNull(5))
                {
                    email = Datos.pDr.GetString(5);
                }
                if (!Datos.pDr.IsDBNull(6))
                {
                    idprovincia = Datos.pDr.GetInt32(6);
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

            formAltaTerceros AltaTerceros = new formAltaTerceros();

            AltaTerceros.IDTerceros = idtercero;
            AltaTerceros.apellido = apellido;
            AltaTerceros.nombre = nombre;
            AltaTerceros.direccion = direccion;
            AltaTerceros.cpostal = cpostal;
            AltaTerceros.email = email;
            AltaTerceros.idprovincia = idprovincia;
            AltaTerceros.ciudad = ciudad;
            AltaTerceros.telfijo = telfijo;
            AltaTerceros.telmovil = telmovil;
            AltaTerceros.descripcion = descripcion;
            AltaTerceros.notas = notas;
            

            AltaTerceros.Nuevo = false;

            DialogResult res = AltaTerceros.ShowDialog();


        }

        public int idTercero { get; set; }
        public int idtercero { get; set; }
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

        private void dgvMedicos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarTercero();
        }

        private void dgvMedicos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarTercero();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cargarTercero();
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
                CargarLista("Terceros", dgvMedicos);
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
