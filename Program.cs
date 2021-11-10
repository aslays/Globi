using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Globi
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            SplashScreen sp = new SplashScreen();
            if (sp.ShowDialog() == DialogResult.OK)
            {
                ////sin login
                //Application.Run(new Form1());
                ////sin login

                //login switch
                Form2Login formLogin = new Form2Login();

                DialogResult result = formLogin.ShowDialog();
                switch (result)
                {
                    case DialogResult.Ignore:
                        {
                            Form1 form1 = new Form1();
                            form1.Rol = 2;
                            Application.Run(form1);
                            return;
                        }
                    case DialogResult.OK:
                        {
                            Form1 form1 = new Form1();
                            form1.Rol = 1;
                            Application.Run(form1);
                            return;
                        }

                }
                //fin login switch

                

                ////login
                //Form2Login formLogin = new Form2Login();

                //if (formLogin.ShowDialog() == DialogResult.Ignore)
                //{
                //    Form1 form1 = new Form1();
                //    form1.Rol = 2;
                //    Application.Run(form1);
                //    return;

                //}
                //else if(formLogin.ShowDialog() == DialogResult.OK)
                //{
                //    Form1 form1 = new Form1();
                //    form1.Rol = 1;
                //    Application.Run(form1);
                //    return;

                //}
                ////fin login
                



                //else if (formLogin.ShowDialog() == DialogResult.OK)
                //{

                //}
                
                //formLogin.ShowDialog();
                ////Application.Run(new Form2Login());

                //Application.Run(new Form1());
            }
        }
    }
}
