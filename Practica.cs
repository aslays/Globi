using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Globi
{
    class Practica
    {
        string descPractica;

        public string pPractica
        {
            set { descPractica = value; }
            get { return descPractica; }
        }

        public Practica(string descPractica)
        {
            this.descPractica = descPractica;
            
        }
        public Practica()
        {
            descPractica = "";
            
        }
        public string toString()
        {
            return descPractica;
        }
    }
}
