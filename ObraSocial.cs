using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globi
{
    class ObraSocial
    {
        string nombre;
        string nombreCom;
        string cuit;
        string direccion;
        string cpostal;
        string email;
        int provincia;
        string ciudad;
        string telefono1;
        string telefono2;
        string fax;
        int codigo;
        string web;
        string notas;

        public string pNombre
        {
            set { nombre = value; }
            get { return nombre; }
        }
        public string pNombreCom
        {
            set { nombreCom = value; }
            get { return nombreCom; }
        }
        public string pCuit
        {
            set { cuit = value; }
            get { return cuit; }
        }
        public string pDireccion
        {
            set { direccion = value; }
            get { return direccion; }
        }
        public string pCpostal
        {
            set { cpostal = value; }
            get { return cpostal; }
        }
        public string pEmail
        {
            set { email = value; }
            get { return email; }
        }
        public int pProvincia
        {
            set { provincia = value; }
            get { return provincia; }
        }
        public string pCiudad
        {
            set { ciudad = value; }
            get { return ciudad; }
        }
        public string pTelefono1
        {
            set { telefono1 = value; }
            get { return telefono1; }
        }
        public string pTelefono2
        {
            set { telefono2 = value; }
            get { return telefono2; }
        }
        public string pFax
        {
            set { fax = value; }
            get { return fax; }
        }
        public int pCodigo      
        {
            set { codigo = value; }
            get { return codigo; }
        }
        public string pWeb
        {
            set { web = value; }
            get { return web; }
        }
        public string pNotas
        {
            set { notas = value; }
            get { return notas; }
        }

        public ObraSocial()
        {
             nombre="";
             nombreCom="";
             cuit="";
             direccion="";
             cpostal="";
             email="";
             provincia=0;
             ciudad="";
             telefono1="";
             telefono2="";
             fax="";
             codigo=0;
             web="";
             notas = "";
        }
        public ObraSocial(string nombre, string nombreCom, string cuit, string direccion, string cpostal, string email, int provincia, string ciudad, string telefono1, string telefono2, string fax, int codigo, string web,string notas)
        {
            this.nombre = nombre;
            this.nombreCom = nombreCom;
            this.email = email;
            this.cuit = cuit;
            this.web = web;
            this.direccion = direccion;
            this.telefono1 = telefono1;
            this.telefono2 = telefono2;
            this.fax = fax;
            this.cpostal = cpostal;
            this.provincia = provincia;
            this.codigo = codigo;
            this.ciudad = ciudad;
            this.notas = notas;
        }
    
    }
}
