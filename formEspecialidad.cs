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
    public partial class formEspecialidad : Form
    {
        BaseDatos Datos = new BaseDatos(@"Data Source=CASA06;Initial Catalog=Globi;Integrated Security=True");
        const int tam = 50;
        Especialidad[] ES = new Especialidad[tam];
        Practica[] PR = new Practica[tam];
        Diagnostico[] DI = new Diagnostico[tam];
        

        bool nuevo = false;

        public formEspecialidad()
        {
            InitializeComponent();
            
        }

        private void formEspecialidad_Load(object sender, EventArgs e)
        {
            cargarLista();
            habilitar(false);
            nuevo = false;
            
            cargarPracticas();
            cargarDiagnosticos();
            txtItem.Enabled = false;
            btnAgregarItem.Enabled = false;
        }

        private void cargarLista()
        {
            int c = 0;
            Datos.LeerDataReader("select * from Especialidad");

            while (Datos.pDr.Read())
            {
                ES[c] = new Especialidad();
                if (!Datos.pDr.IsDBNull(1))
                {
                    ES[c].pEspecialidad = Datos.pDr.GetString(1);
                }
                
                c++;
            }
            Datos.pDr.Close();
            Datos.Desconectar();

            lstEspecialidades.Items.Clear();
            for (int i = 0; i < c; i++)
                lstEspecialidades.Items.Add(ES[i].toString());
            lstEspecialidades.SelectedIndex = c - 1;

        }
        private void getIdEspecialidad()
        {
            Datos.LeerDataReader("select idEspecialidad from Especialidad where Especialidad ='" + txtEspecialidad.Text + "'");

            while (Datos.pDr.Read())
            {

                if (!Datos.pDr.IsDBNull(0))
                {
                    idEspecialidad = Datos.pDr.GetInt32(0);
                }


            }
            Datos.pDr.Close();
            Datos.Desconectar();
        }
        private void cargarPracticas()
        {
            getIdEspecialidad();

            Datos.pDr.Close();
            Datos.Desconectar();
            
            int c = 0;
            Datos.LeerDataReader("select practica from Practicas where idEspecialidad ="+idEspecialidad);
            
            while (Datos.pDr.Read())
            {
                PR[c] = new Practica();
                
                if (!Datos.pDr.IsDBNull(0))
                {
                    PR[c].pPractica = Datos.pDr.GetString(0);
                }

                c++;
            }
            Datos.pDr.Close();
            Datos.Desconectar();

            lstPracticas.Items.Clear();
            for (int i = 0; i < c; i++)
                lstPracticas.Items.Add(PR[i].toString());
            lstPracticas.SelectedIndex = c - 1;

        }

        private void cargarDiagnosticos()
        {
            int c = 0;
            Datos.LeerDataReader("select Diagnostico from Diagnosticos where idEspecialidad =" + idEspecialidad);

            while (Datos.pDr.Read())
            {
                DI[c] = new Diagnostico();

                if (!Datos.pDr.IsDBNull(0))
                {
                    DI[c].pDiagnostico = Datos.pDr.GetString(0);
                }

                c++;
            }
            Datos.pDr.Close();
            Datos.Desconectar();

            lstDiagnosticos.Items.Clear();
            for (int i = 0; i < c; i++)
                lstDiagnosticos.Items.Add(DI[i].toString());
            lstDiagnosticos.SelectedIndex = c - 1;


        }


        private void habilitar(bool x)
        {
            txtEspecialidad.Enabled = x;
            btnAgregarEspe.Enabled = x;
            
            
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitar(true);
            nuevo = true;
            Limpiar();
            

            panel3.Enabled = false;
            panel4.Enabled = false;
            //lstPracticas.Enabled = false;
            //lstDiagnosticos.Enabled = false;
        }
        private void Limpiar()
        {
            
            txtEspecialidad.Text = "";
        }

        private void lstEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCampos(lstEspecialidades.SelectedIndex);
            habilitar(false);
            nuevo = false;
           
            cargarPracticas();
            cargarDiagnosticos();
            txtItem.Enabled = false;
            btnAgregarItem.Enabled = false;

            panel3.Enabled = true;
            panel4.Enabled = true;

            lstPracticas.Enabled = true;
            lstDiagnosticos.Enabled = true;
            btnBorrarDiag.Enabled = true;
            btnBorrarPrac.Enabled = true;
        }

        private void cargarCampos(int posicion)
        {
            txtEspecialidad.Text = ES[posicion].pEspecialidad;
        }

        private void cargarEspecialidad(Especialidad ES)
        {
            ES.pEspecialidad = txtEspecialidad.Text;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void guardarEspecialidad()
        {
            if (validar())
            {
                string query = "";

                Especialidad E = new Especialidad();
                cargarEspecialidad(E);
                if (nuevo == true)
                {
                    query = "insert into Especialidad (Especialidad) values('" + E.pEspecialidad + "')";
                    MessageBox.Show("Especialidad Creada!");
                    Datos.Actualizar(query);
                }
                if (nuevo == false)
                {
                    int i = lstEspecialidades.SelectedIndex;

                    query = "Update Especialidad set Especialidad ='" + txtEspecialidad.Text +
                                   "' WHERE Especialidad= '" + ES[i].pEspecialidad.ToString() + "'";

                    Datos.Actualizar(query);
                    MessageBox.Show("Datos Actualizados!");

                }

                lstEspecialidades.Items.Clear();
                cargarLista();
                Limpiar();
                habilitar(false);

                panel3.Enabled = true;
                panel4.Enabled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitar(true);
            nuevo = false;
            
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int i = lstEspecialidades.SelectedIndex;

            if (MessageBox.Show("Esta seguro de eliminar a: " + ES[i].toString(),
                                 "Borrando",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question,
                                 MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                string sqlpractica = "delete from Practicas where idEspecialidad = " + idEspecialidad;
                Datos.Actualizar(sqlpractica);
                string sqldiagnostico = "delete from Diagnosticos where idEspecialidad = " + idEspecialidad;
                Datos.Actualizar(sqldiagnostico);
                string sql = "DELETE  FROM Especialidad" +
                                   " WHERE Especialidad= '" + ES[i].pEspecialidad + "'";
                Datos.Actualizar(sql);
                cargarLista();
            }
        }

        private bool validar()
        {
            if (txtEspecialidad.Text == "")
            {
                MessageBox.Show("Debe ingresar una Especialidad");
                txtEspecialidad.Focus();
                return false;
            }
            
            return true;
        }


        public int idEspecialidad { get; set; }

        public string practica { get; set; }

        private void btnEditarPr_Click(object sender, EventArgs e)
        {
            txtItem.Enabled = true;
            btnAgregarItem.Enabled = true;

            lstPracticas.Enabled = true;
            btnBorrarPrac.Enabled = true;

            lstDiagnosticos.Enabled = false;
            btnBorrarDiag.Enabled = false;


        }

        private void btnBorrarPrac_Click(object sender, EventArgs e)
        {
            int i = lstPracticas.SelectedIndex;

            if (MessageBox.Show("Esta seguro de eliminar a: " + PR[i].toString(),
                                 "Borrando",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question,
                                 MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                string sql = "DELETE  FROM Practicas" +
                                   " WHERE practica= '" + PR[i].pPractica + "'";
                Datos.Actualizar(sql);
                lstPracticas.Items.Clear();
                cargarPracticas();
                
            }

        }

        private void cargarPractica(Practica PR)
        {
            PR.pPractica = txtItem.Text;
        }
        private void cargarDiagnostico(Diagnostico DI)
        {
            DI.pDiagnostico = txtItem.Text;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            

            if (txtItem.Text == "")
            {
                MessageBox.Show("Debe completar los campos");
            }
            if (txtItem.Text != "")
            {
                string query = "";

                if (lstPracticas.Enabled == true)
                {
                    Practica P = new Practica();
                    cargarPractica(P);
                    query = "insert into Practicas (practica,idEspecialidad) values('" + P.pPractica + "'," + idEspecialidad + ")";
                    //MessageBox.Show("Practica Creada!");
                    Datos.Actualizar(query);
                }
                if (lstDiagnosticos.Enabled == true)
                {
                    Diagnostico D = new Diagnostico();
                    cargarDiagnostico(D);
                    query = "insert into Diagnosticos (Diagnostico,idEspecialidad) values('" + D.pDiagnostico + "'," + idEspecialidad + ")";
                    //MessageBox.Show("Diagnostico Creado!");
                    Datos.Actualizar(query);
                }

                lstPracticas.Items.Clear();
                cargarPracticas();
                txtItem.Text = "";
                lstDiagnosticos.Items.Clear();
                cargarDiagnosticos();

            }



        }

        private void btnAgregarEspe_Click(object sender, EventArgs e)
        {
            guardarEspecialidad();
        }

        private void btnEditarDiag_Click(object sender, EventArgs e)
        {
            txtItem.Enabled = true;
            btnAgregarItem.Enabled = true;

            lstDiagnosticos.Enabled = true;
            btnBorrarDiag.Enabled = true;

            lstPracticas.Enabled = false;
            btnBorrarPrac.Enabled = false;
        }

        private void btnBorrarDiag_Click(object sender, EventArgs e)
        {
            int i = lstDiagnosticos.SelectedIndex;

            if (MessageBox.Show("Esta seguro de eliminar a: " + DI[i].toString(),
                                 "Borrando",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question,
                                 MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                string sql = "DELETE  FROM Diagnosticos" +
                                   " WHERE Diagnostico= '" + DI[i].pDiagnostico + "'";
                Datos.Actualizar(sql);
                lstDiagnosticos.Items.Clear();
                cargarDiagnosticos();

            }
        }
    }
}
