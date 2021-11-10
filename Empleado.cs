using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globi
{
    class Empleado
    {
        string Apellido;
        string Nombre;
        string Documento;
        string Email;
        string CPostal;
        string Direccion;
        string Ciudad;
        string TelefonoFijo;
        string TelefonoMovil;
        int Provincia;
        int CODEmpleado;
        string Notas;
        string Ausencias;
        string Vacaciones;

        public int pCODEmpleado
        {
            set { CODEmpleado = value; }
            get { return CODEmpleado; }
        }

        public string pApellido
        {
            set { Apellido = value; }
            get { return Apellido; }
        }
        public string pNombre
        {
            set { Nombre = value; }
            get { return Nombre; }
        }
        public string pDireccion
        {
            set { Direccion = value; }
            get { return Direccion; }
        }
        public string pDocumento
        {
            set { Documento = value; }
            get { return Documento; }
        }
        public string pEmail
        {
            set { Email = value; }
            get { return Email; }
        }
        public int pProvincia
        {
            set { Provincia = value; }
            get { return Provincia; }
        }
        public string pCiudad
        {
            set { Ciudad = value; }
            get { return Ciudad; }
        }
        public string pCPostal
        {
            set { CPostal = value; }
            get { return CPostal; }
        }
        public string pNotas
        {
            set { Notas = value; }
            get { return Notas; }
        }
        public string pAusencias
        {
            set { Ausencias = value; }
            get { return Ausencias; }
        }
        public string pVacaciones
        {
            set { Vacaciones = value; }
            get { return Vacaciones; }
        }
        public string pTelefonoFijo
        {
            set { TelefonoFijo = value; }
            get { return TelefonoFijo; }
        }
        public string pTelefonoMovil
        {
            set { TelefonoMovil = value; }
            get { return TelefonoMovil; }
        }

        public Empleado(string Apellido,string Nombre,string Direccion,string Documento,string Email,int Provincia,string Ciudad,string TelefonoFijo, string TelefonoMovil,int CODEmpleado,string CPostal,string Notas,string Ausencias,string Vacaciones)
        {
            this.Apellido = Apellido;
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Documento = Documento;
            this.Email = Email;
            this.Provincia = Provincia;
            this.Ciudad = Ciudad;
            this.TelefonoFijo = TelefonoFijo;
            this.TelefonoMovil=TelefonoMovil;
            this.CODEmpleado = CODEmpleado;
            this.CPostal = CPostal;
            this.Notas = Notas;
            this.Ausencias = Ausencias;
            this.Vacaciones = Vacaciones;
                        
        }
        public Empleado()
        {
            Apellido="";
            Nombre = "";
            Direccion = "";
            Documento = "";
            Email = "";
            Provincia = 0;
            Ciudad = "";
            TelefonoMovil = "";
            TelefonoFijo = "";
            CODEmpleado = 0;
            CPostal = "";
            Notas = "";
            Ausencias = "";
            Vacaciones = "";

        }


    }
}
