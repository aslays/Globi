using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globi
{
    class Tercero
    {
        string Apellido;
        string Nombre;
        string Direccion;
        string Email;
        int Provincia;
        string Ciudad;
        string TelefonoFijo;
        string TelefonoMovil;
        string CPostal;
        string Notas;
        int IdTercero;
        string descripcion;

        public int pIdTercero
        {
            set { IdTercero = value; }
            get { return IdTercero; }
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

         public Tercero(string Apellido,string Nombre,string Direccion,string Email,int Provincia,string Ciudad,string TelefonoFijo, string TelefonoMovil,string CPostal,string Notas,int IdTercero, string descripcion)
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
            this.IdTercero = IdTercero;
            this.descripcion = descripcion;
            
        }
        public Tercero()
        {
            Apellido="";
            Nombre = "";
            Direccion = "";
            Email = "";
            Provincia = 0;
            Ciudad = "";
            TelefonoMovil = "";
            TelefonoFijo = "";
            IdTercero = 0;
            descripcion = "";
            CPostal = "";
            Notas = "";
         }

    }
}
