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
using System.Configuration;

namespace Globi
{
    public partial class formEmpleados : Form
    {
        BaseDatos Datos = new BaseDatos(@"Data Source=CASA06;Initial Catalog=Globi;Integrated Security=True");

        DataSet resultados = new DataSet();
        DataView mifiltro;

        public formEmpleados()
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
            dt = Datos.Leer("select Apellido, nombre'Nombre', Email, TelefonoF'Telefomo Fijo', TelefonoM'Telefono Movil',ciudad,idEmpleado from Empleados " + tabla);

            dgv.DataSource = dt;
        }



        private void btnAltaEmpleado_Click(object sender, EventArgs e)
        {
            formAltaEmpleado AltaEmpleado = new formAltaEmpleado();

            AltaEmpleado.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAltaEmpleados_FormClosed);
            bool nuevo = true;
            AltaEmpleado.Nuevo = nuevo;


            AltaEmpleado.ShowDialog();
        }
        private void formAltaEmpleados_FormClosed(object sender, FormClosedEventArgs e)
        {
            //CargarLista("Medicos", dgvMedicos);

            this.leer_datos("select Apellido, Nombre,  Email, TelefonoF'Telefomo Fijo', TelefonoM'Telefono Movil',ciudad'Ciudad', idEmpleado'NroEmpleado' from Empleados", ref resultados, "Empleados");
            this.mifiltro = ((DataTable)resultados.Tables["Empleados"]).DefaultView;
            this.dgvEmpleados.DataSource = mifiltro;

            RemoveDuplicate(dgvEmpleados);

        }
        public void RemoveDuplicate(DataGridView dgvEmpleados)
        {
            for (int currentRow = 0; currentRow < dgvEmpleados.Rows.Count - 1; currentRow++)
            {
                DataGridViewRow rowToCompare = dgvEmpleados.Rows[currentRow];

                for (int otherRow = currentRow + 1; otherRow < dgvEmpleados.Rows.Count; otherRow++)
                {
                    DataGridViewRow row = dgvEmpleados.Rows[otherRow];

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
                        dgvEmpleados.Rows.Remove(row);
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

        private void formEmpleados_Load(object sender, EventArgs e)
        {
            this.leer_datos("select Apellido, Nombre,  Email, TelefonoF'Telefomo Fijo', TelefonoM'Telefono Movil',ciudad'Ciudad', idEmpleado from Empleados", ref resultados, "Empleados");
            this.mifiltro = ((DataTable)resultados.Tables["Empleados"]).DefaultView;
            this.dgvEmpleados.DataSource = mifiltro;
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //cargarMedico();
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
                //cargarMedico();
            }
            if (e.KeyCode == Keys.Back)
            {
                RemoveDuplicate(dgvEmpleados);
            }
            if (e.KeyCode == Keys.Delete)
            {
                RemoveDuplicate(dgvEmpleados);
            }
        }

        private void cargarEmpleado()
        {
            idEmpleado = Convert.ToInt32(this.dgvEmpleados.CurrentRow.Cells[6].Value.ToString());

            Datos.LeerDataReader("select * from Empleados where idEmpleado =" + idEmpleado);

            while (Datos.pDr.Read())
            {
                if (!Datos.pDr.IsDBNull(0))
                {
                    idemple = Datos.pDr.GetInt32(0);
                }
                if (!Datos.pDr.IsDBNull(1))
                {
                    apellidoemple = Datos.pDr.GetString(1);
                }
                if (!Datos.pDr.IsDBNull(2))
                {
                    nombreemple = Datos.pDr.GetString(2);
                }
                if (!Datos.pDr.IsDBNull(3))
                {
                    docemple = Datos.pDr.GetString(3);
                }
                if (!Datos.pDr.IsDBNull(4))
                {
                    direemple = Datos.pDr.GetString(4);
                }
                if (!Datos.pDr.IsDBNull(5))
                {
                    telefonofemple = Datos.pDr.GetString(5);
                }
                if (!Datos.pDr.IsDBNull(6))
                {
                    telefonomemple = Datos.pDr.GetString(6);
                }
                if (!Datos.pDr.IsDBNull(7))
                {
                    emailemple = Datos.pDr.GetString(7);
                }
                if (!Datos.pDr.IsDBNull(8))
                {
                    cpostalemple = Datos.pDr.GetString(8);
                }
                if (!Datos.pDr.IsDBNull(9))
                {
                    ciudademple = Datos.pDr.GetString(9);
                }
                if (!Datos.pDr.IsDBNull(10))
                {
                    idProvemple = Datos.pDr.GetInt32(10);
                }
                if (!Datos.pDr.IsDBNull(11))
                {
                    notas = Datos.pDr.GetString(11);
                }
                if (!Datos.pDr.IsDBNull(12))
                {
                    ausencias = Datos.pDr.GetString(12);
                }
                if (!Datos.pDr.IsDBNull(13))
                {
                    vacaciones = Datos.pDr.GetString(13);
                }


            }
            Datos.pDr.Close();
            Datos.Desconectar();

            formAltaEmpleado AltaEmpleado = new formAltaEmpleado();

            AltaEmpleado.IDEmpleado = idemple;
            AltaEmpleado.Apellido = apellidoemple;
            AltaEmpleado.Nombre = nombreemple;
            AltaEmpleado.Documetno = docemple;
            AltaEmpleado.Direccion = direemple;
            AltaEmpleado.TelefonoFijo = telefonofemple;
            AltaEmpleado.TelefonoMovil = telefonomemple;
            AltaEmpleado.Email = emailemple;
            AltaEmpleado.CPosta = cpostalemple;
            AltaEmpleado.Ciudad = ciudademple;
            AltaEmpleado.IdProvincia = idProvemple;
            AltaEmpleado.Notas = notas;
            AltaEmpleado.Ausencias = ausencias;
            AltaEmpleado.Vacaciones = vacaciones;

            AltaEmpleado.Nuevo = false;

            DialogResult res = AltaEmpleado.ShowDialog();

        }



        public int idEmpleado { get; set; }
        public int idemple { get; set; }
        public string apellidoemple { get; set; }
        public string nombreemple { get; set; }
        public string docemple { get; set; }
        public string direemple { get; set; }
        public string telefonofemple { get; set; }
        public string telefonomemple { get; set; }
        public string emailemple { get; set; }
        public string cpostalemple { get; set; }
        public string ciudademple { get; set; }
        public int idProvemple { get; set; }
        public string notas { get; set; }
        public string ausencias { get; set; }
        public string vacaciones { get; set; }

        private void dgvEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarEmpleado();
        }

        private void dgvEmpleados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarEmpleado();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cargarEmpleado();
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
            if (dgvEmpleados.RowCount == 0)
            {
                CargarLista("Empleados", dgvEmpleados);
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

                foreach (DataGridViewColumn col in dgvEmpleados.Columns)
                {

                    ColumnIndex++;

                    hoja_trabajo.Cells[1, ColumnIndex] = col.Name;

                }

                int rowIndex = 0;

                foreach (DataGridViewRow row in dgvEmpleados.Rows)
                {

                    rowIndex++;

                    ColumnIndex = 0;

                    foreach (DataGridViewColumn col in dgvEmpleados.Columns)
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
