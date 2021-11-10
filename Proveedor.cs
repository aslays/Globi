using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globi
{
    class Proveedor
    {
        int idProveedor;
        string Nombre;
        string NombreCom;
        string Direccion;
        string CPostal;
        string TelFijo;
        string TelMovil;
        string Ciudad;
        string Descripcion;
        string Notas;
        string Email;
        int idProvincia;

        public int pidProveedor
        {
            set { idProveedor = value; }
            get { return idProveedor; }
        }
        public int pidProvincia
        {
            set { idProvincia = value; }
            get { return idProvincia; }
        }
        public string pNombre
        {
            set { Nombre = value; }
            get { return Nombre; }
        }
        public string pNombreCom
        {
            set { NombreCom = value; }
            get { return NombreCom; }
        }
        public string pDireccion
        {
            set { Direccion = value; }
            get { return Direccion; }
        }
        public string pCPostal
        {
            set { CPostal = value; }
            get { return CPostal; }
        }
        public string pTelFijo
        {
            set { TelFijo = value; }
            get { return TelFijo; }
        }
        public string pTelMovil
        {
            set { TelMovil = value; }
            get { return TelMovil; }
        }
        public string pCiudad
        {
            set { Ciudad = value; }
            get { return Ciudad; }
        }
        public string pDescripcion
        {
            set { Descripcion = value; }
            get { return Descripcion; }
        }
        public string pNotas
        {
            set { Notas = value; }
            get { return Notas; }
        }
        public string pEmail
        {
            set { Email = value; }
            get { return Email; }
        }

        public Proveedor(int idProveedor,string Nombre,string NombreCom,string Direccion,string CPostal,string TelFijo,string TelMovil,string Email,string Notas,string Descripcion, int idProvincia,string Ciudad)
        {
            this.Ciudad = Ciudad;
            this.Descripcion = Descripcion;
            this.Email = Email;
            this.TelFijo = TelFijo;
            this.TelMovil = TelMovil;
            this.Direccion = Direccion;
            this.idProveedor = idProveedor;
            this.idProvincia = idProvincia;
            this.Nombre = Nombre;
            this.Notas = Notas;
            this.CPostal = CPostal;
            this.NombreCom = NombreCom;
        }
        public Proveedor()
        {
            Nombre = "";
            NombreCom = "";
            TelFijo = "";
            TelMovil = "";
            Direccion = "";
            Ciudad = "";
            Email = "";
            idProveedor = 0;
            idProvincia = 0;
            Notas = "";
            Descripcion = "";
            CPostal = "";

        }

    }
}
