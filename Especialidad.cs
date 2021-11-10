using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globi
{
    class Especialidad
    {
        string descEspecialidad;
        int idEspecialidad;

        public string pEspecialidad
        {
            set { descEspecialidad = value; }
            get { return descEspecialidad; }
        }
        public int pIdEspecialidad
        {
            set { idEspecialidad = value; }
            get { return idEspecialidad; }
        }
        public Especialidad(string Especialidad, int idEspecialidad)
        {
            this.descEspecialidad = Especialidad;
            this.idEspecialidad = idEspecialidad;
        }
        public Especialidad()
        {
            descEspecialidad = "";
            idEspecialidad = 0;
        }
        public string toString()
        {
            return descEspecialidad;
        }
    }
}
