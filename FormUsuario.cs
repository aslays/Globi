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
    public partial class FormUsuario : Form
    {
        BaseDatos Datos = new BaseDatos(@"Data Source=CASA06;Initial Catalog=Globi;Integrated Security=True");
        const int tam = 50;
        Usuario[] US = new Usuario[tam];

        bool nuevo = false;

        public FormUsuario()
        {
            InitializeComponent();

        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            rbtnUsuario.Checked = true;
            cargarLista();
            habilitar(false);
            nuevo = false;
            btnGuardar.Enabled = false;
        }

        private void cargarLista()
        {
            int c = 0;
            Datos.LeerDataReader("select * from Usuarios");

            while (Datos.pDr.Read())
            {
                US[c] = new Usuario();
                if (!Datos.pDr.IsDBNull(1))
                {
                    US[c].pUser = Datos.pDr.GetString(1);
                }
                if (!Datos.pDr.IsDBNull(2))
                {
                    US[c].pPass = Datos.pDr.GetString(2);
                }
                if (!Datos.pDr.IsDBNull(3))
                {
                    US[c].pRol = Datos.pDr.GetInt32(3);
                }
                c++;
            }
            Datos.pDr.Close();
            Datos.Desconectar();

            lstUsuarios.Items.Clear();
            for (int i = 0; i < c; i++)
                lstUsuarios.Items.Add(US[i].toString());
            lstUsuarios.SelectedIndex = c - 1;

        }

        private void habilitar(bool x)
        {
            txtUser.Enabled = x;
            txtPass.Enabled = x;
            rbtnAdministrador.Enabled = x;
            rbtnUsuario.Enabled = x;
        }
                
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitar(true);
            nuevo = true;
            Limpiar();
            btnGuardar.Enabled = true;
        }

        private void Limpiar()
        {
            txtPass.Text = "";
            txtUser.Text = "";
        }
       
        private void lstUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCampos(lstUsuarios.SelectedIndex);
            habilitar(false);
            nuevo = false;
            btnGuardar.Enabled = false;
        }

        private void cargarCampos(int posicion)
        {
            txtUser.Text = US[posicion].pUser;
            txtPass.Text = US[posicion].pPass;

            if (US[posicion].pRol == 1)
                rbtnAdministrador.Checked = true;
            else
                rbtnUsuario.Checked = true;
        }
        private void cargarUsuario(Usuario U)
        {
            U.pPass = txtPass.Text;
            U.pUser = txtUser.Text;
            if (rbtnAdministrador.Checked)
            {
                U.pRol = 1;
            }
            else U.pRol = 2;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar()==true)
            {
                string query = "";

                Usuario U = new Usuario();
                cargarUsuario(U);
                if (nuevo == true)
                {
                    query = "insert into Usuarios (Username,Pass,rol) values('" + U.pUser + "','" + U.pPass + "'," + U.pRol + ")";
                    MessageBox.Show("Usuario Creado!");
                    Datos.Actualizar(query);
                }
                if (nuevo == false)
                {
                    int i = lstUsuarios.SelectedIndex;

                    query = "Update Usuarios set Username ='" + txtUser.Text +"', Pass='"+ txtPass.Text+
                                   "' ,rol = "+U.pRol+" WHERE Username= '" + US[i].pUser.ToString() +"'";
                                        
                    Datos.Actualizar(query);
                    MessageBox.Show("Datos Actualizados!");

                }

                lstUsuarios.Items.Clear();
                cargarLista();
                Limpiar();
                habilitar(false);
            }
        }
        

        
        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitar(true);
            nuevo = false;
            btnGuardar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int i = lstUsuarios.SelectedIndex;

            if (MessageBox.Show("Esta seguro de eliminar a: " + US[i].toString(),
                                 "Borrando",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question,
                                 MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                string sql = "DELETE  FROM Usuarios" +
                                   " WHERE Username= '" + US[i].pUser +
                                   "' AND Pass='" + US[i].pPass+"'";
                Datos.Actualizar(sql);
                cargarLista();
            }
        }

        private bool validar()
        {
            if (txtUser.Text == "")
            {
                MessageBox.Show("Debe ingresar un Nombre de Usuario");
                txtUser.Focus();
                return false;
            }
            if (txtPass.Text == "")
            {
                MessageBox.Show("Debe ingresar una Contraseña");
                txtPass.Focus();
                return false;
            }
            return true;
        }
    }
}
