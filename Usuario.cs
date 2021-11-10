using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globi
{
    class Usuario
    {
        string user;
        string pass;
        int rol;

        public Usuario(int rol, string user, string pass)
        {
            this.rol = rol;
            this.pass = pass;
            this.user = user;
        }

        public Usuario()
        {
            rol = 0;
            pass = "";
            user = "";
        }

        public string pUser
        {
            set { user = value; }
            get { return user; }
        }

        public string pPass
        {
            set { pass = value; }
            get { return pass; }
        }
        public int pRol
        {
            set { rol = value; }
            get { return rol; }
        }

         public string toString()
        {
            return user;
        }

    }
}
