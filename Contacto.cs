using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globi
{
    class Contacto
    {
        string Apellido;
        string Nombre;
        
        string Email;
        string CPostal;
        string Direccion;
        string Ciudad;
        string TelefonoFijo;
        string TelefonoMovil;
        int Provincia;
        string Notas;
        int IdContacto;
        string descripcion;

        public int pIdContacto
        {
            set { IdContacto = value; }
            get { return IdContacto; }
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
        public string pDescripcion
        {
            set { descripcion = value; }
            get { return descripcion; }
        }

        public Contacto(string Apellido,string Nombre,string Direccion,string Email,int Provincia,string Ciudad,string TelefonoFijo, string TelefonoMovil,string CPostal,string Notas, int IdContacto, string descripcion )
        {
            this.Apellido = Apellido;
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Email = Email;
            this.Provincia = Provincia;
            this.Ciudad = Ciudad;
            this.TelefonoFijo = TelefonoFijo;
            this.TelefonoMovil=TelefonoMovil;
            this.CPostal = CPostal;
            this.Notas = Notas;
            this.IdContacto = IdContacto;
            this.descripcion = descripcion;          
        }
        public Contacto()
        {
            Apellido="";
            Nombre = "";
            Direccion = "";
            Email = "";
            Provincia = 0;
            Ciudad = "";
            TelefonoMovil = "";
            TelefonoFijo = "";
            IdContacto = 0;
            CPostal = "";
            Notas = "";
            descripcion = "";
         }

    }
}
