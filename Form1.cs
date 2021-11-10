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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient)
                    c.BackColor = Color.White;
                
            }
         
        }
        private formPaciente Pacientesform = null;
        private formMedicos Medicosform = null;
        private formEmpleados Empleadosform = null;
        private formContactos Contactosform = null;
        private formObraSocial ObraSocialform = null;
        private formTerceros Tercerosform = null;
        private formProveedores Proveedoresform = null;

        private formProveedores FormInstanceProveedores
        {
            get
            {
                if (Proveedoresform == null)
                {
                    Proveedoresform = new formProveedores();
                    Proveedoresform.Disposed += new EventHandler(formProveedores_FormClosed);
                }

                return Proveedoresform;
            }
        }
        private formTerceros FormInstanceTerceros
        {
            get
            {
                if (Tercerosform == null)
                {
                    Tercerosform = new formTerceros();
                    Tercerosform.Disposed += new EventHandler(formTerceros_FormClosed);
                }

                return Tercerosform;
            }
        }
        private formEmpleados FormInstanceEmpleados
        {
            get
            {
                if (Empleadosform == null)
                {
                    Empleadosform = new formEmpleados();
                    Empleadosform.Disposed += new EventHandler(formEmpleados_FormClosed);
                }

                return Empleadosform;
            }
        }

        
        private formMedicos FormInstanceMedicos
        {
            get
            {
                if (Medicosform == null)
                {
                    Medicosform = new formMedicos();
                    Medicosform.Disposed += new EventHandler(formMedicos_FormClosed);
                }

                return Medicosform;
            }
        }
        private formPaciente FormInstancePacientes
        {
            get
            {
                if (Pacientesform == null)
                {
                    Pacientesform = new formPaciente();
                    Pacientesform.Disposed += new EventHandler(formPacientes_FormClosed);
                }

                return Pacientesform;
            }
        }
        private formContactos FormInstanceContactos
        {
            get
            {
                if (Contactosform == null)
                {
                    Contactosform = new formContactos();
                    Contactosform.Disposed += new EventHandler(formContactos_FormClosed);
                }

                return Contactosform;
            }
        }
        private formObraSocial FormInstanceObraSocial
        {
            get
            {
                if (ObraSocialform == null)
                {
                    ObraSocialform = new formObraSocial();
                    ObraSocialform.Disposed += new EventHandler(formObraSocial_FormClosed);
                }

                return ObraSocialform;
            }
        }
        private void formProveedores_FormClosed(object sender, EventArgs e)
        {
            Proveedoresform = null;
        }
        private void formTerceros_FormClosed(object sender, EventArgs e)
        {
            Tercerosform = null;
        }
        private void formObraSocial_FormClosed(object sender, EventArgs e)
        {
            ObraSocialform = null;
        }
        private void formMedicos_FormClosed(object sender, EventArgs e)
        {
            Medicosform = null;
        }
        private void formPacientes_FormClosed(object sender, EventArgs e)
        {
            Pacientesform = null;
        }
        private void formEmpleados_FormClosed(object sender, EventArgs e)
        {
            Empleadosform = null;
        }
        private void formContactos_FormClosed(object sender, EventArgs e)
        {
            Contactosform = null;
        }    
             
        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPaciente frm = this.FormInstancePacientes;
            frm.MdiParent = this;
            frm.Show();

            frm.BringToFront();
           
        }
   
        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = @"Calendar\Calendar.exe";
            p.Start();
            
            //p.WaitForExit();
           // @"C:\Users\Ariel\Documents\Visual Studio 2012\Globi\GlobiAgenda\GlobiAgenda\bin\Debug\GlobiAgenda.exe";
            //@"GlobiAgenda\GlobiAgenda\bin\Debug\GlobiAgenda.exe";
            //C:\Users\Ariel\Documents\Visual Studio 2012\Globi\Globi\Globi\bin\Debug\Calendar
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formEmpleados frm = this.FormInstanceEmpleados;
            frm.MdiParent = this;
            frm.Show();

            frm.BringToFront();
        }

        private void obrasSocialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formObraSocial frm = this.FormInstanceObraSocial;
            frm.MdiParent = this;
            frm.Show();

            frm.BringToFront();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formProveedores frm = this.FormInstanceProveedores;
            frm.MdiParent = this;
            frm.Show();

            frm.BringToFront();
        }

        private void contactosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formContactos frm = this.FormInstanceContactos;
            frm.MdiParent = this;
            frm.Show();

            frm.BringToFront();
        }

        private void tercerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formTerceros frm = this.FormInstanceTerceros;
            frm.MdiParent = this;
            frm.Show();

            frm.BringToFront();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void medicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formMedicos frm = this.FormInstanceMedicos;
            frm.MdiParent = this;
            frm.Show();

            frm.BringToFront();
        }

        public int Rol { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Rol == 2)
            {
                empleadosToolStripMenuItem.Visible = false;
                configuracionToolStripMenuItem1.Visible = false;
            }
            
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuario formUser = new FormUsuario();
            formUser.ShowDialog();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formEspecialidad especialidades = new formEspecialidad();
            especialidades.ShowDialog();
        }

        
    }
}
