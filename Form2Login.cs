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
    public partial class Form2Login : Form
    {
        BaseDatos Datos = new BaseDatos(@"Data Source=CASA06;Initial Catalog=Globi;Integrated Security=True");

        string userBD="";
        string passBD="";
        int rolBD;

        string userEsc;
        string passEsc;

        public Form2Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Ingresar();

        }
        private void Ingresar()
        {
            userEsc = Convert.ToString(txtUsuario.Text);
            passEsc = Convert.ToString(txtContraseña.Text);

            Datos.LeerDataReader("select * from Usuarios where Username = '" + userEsc + "'");

            while (Datos.pDr.Read())
            {
                if (!Datos.pDr.IsDBNull(1))
                {
                    userBD = Datos.pDr.GetString(1);
                }
                if (!Datos.pDr.IsDBNull(2))
                {
                    passBD = Datos.pDr.GetString(2);
                }
                if (!Datos.pDr.IsDBNull(3))
                {
                    rolBD = Datos.pDr.GetInt32(3);
                }
            }
            Datos.pDr.Close();
            Datos.Desconectar();

            if (String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(txtContraseña.Text))
            {
                MessageBox.Show("Datos Incorrectos");
            }

            else if (userEsc != userBD || passBD != passEsc)
            {
                MessageBox.Show("Datos Incorrectos");
            }

            else if (userEsc == userBD && passEsc == passBD)
            {

                if (rolBD == 1)
                {
                    this.DialogResult = DialogResult.OK;
                    return;
                }

                if (rolBD == 2)
                {
                    this.DialogResult = DialogResult.Ignore;
                    return;
                }

                //Form1 Aplicacion = new Form1();

                //Aplicacion.Rol = rolBD;


                //Aplicacion.Show();


            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Ingresar();
            }
        }

        private void txtContraseña_KeyUp(object sender, KeyEventArgs e)
        {

        }
    
    
    
    
    
    }
}
