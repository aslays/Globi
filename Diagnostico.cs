using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Globi
{
    class Diagnostico
    {
        string descDiagnostico;

        public string pDiagnostico
        {
            set { descDiagnostico = value; }
            get { return descDiagnostico; }
        }

        public Diagnostico(string descPractica)
        {
            this.descDiagnostico = descPractica;
            
        }
        public Diagnostico()
        {
            descDiagnostico = "";
            
        }
        public string toString()
        {
            return descDiagnostico;
        }

    }
}
