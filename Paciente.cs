using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globi
{
    class Paciente
    {
        int IdPaciente;
        string Nombre;
        string Apellido;
        string Documento;
        string Direccion;
        string CPostal;
        string TelefonoF;
        string TelefonoM;
        string NroAfiliado;
        string Ciudad;
        string Email;
        int Provincia;
        int ObraSocial;
        int IdObrasocial;
        DateTime FechaAlta;
        int sexo;
        DateTime fechaNac;

        public int pIdPaciente
        {
            set { IdPaciente = value; }
            get { return IdPaciente; }
        }
        public string pNombre
        {
            set { Nombre = value; }
            get { return Nombre; }
        }
        public string pApellido
        {
            set { Apellido = value; }
            get { return Apellido; }
        }
        public string pDocumento
        {
            set { Documento = value; }
            get { return Documento; }
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
        public string pTelefonoF
        {
            set { TelefonoF = value; }
            get { return TelefonoF; }
        }
        public string pTelefonoM
        {
            set { TelefonoM = value; }
            get { return TelefonoM; }
        }
        public string pNroAfiliado
        {
            set { NroAfiliado = value; }
            get { return NroAfiliado; }
        }
        public string pCiudad
        {
            set { Ciudad = value; }
            get { return Ciudad; }
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
        public int pObraSocial
        {
            set { ObraSocial = value; }
            get { return ObraSocial; }
        }
        public int pIdObrasocial
        {
            set { IdObrasocial = value; }
            get { return IdObrasocial; }
        }
        public DateTime pFechaAlta
        {
            set { FechaAlta = value; }
            get { return FechaAlta; }
        }
        public DateTime pFechaNac
        {
            set { fechaNac = value; }
            get { return fechaNac; }
        }
        public int pSexo
        {
            set { sexo = value; }
            get { return sexo; }
        }


        public Paciente()
        {
            IdPaciente =0;
            Nombre = "";
            Apellido = "";
            Documento = "";
            Direccion = "";
            CPostal = "";
            TelefonoF = "";
            TelefonoM = "";
            NroAfiliado = "";
            Ciudad = "";
            Email = "";
            Provincia = 0;
            ObraSocial = 0;
            IdObrasocial = 0;
            FechaAlta = DateTime.Today;
            sexo = 0;
            fechaNac = DateTime.Today;

        }

        public Paciente(int IdPaciente, string Nombre, string Apellido, string Documento, string Direccion, string CPostal, string TelefonoF, string TelefonoM, string NroAfiliado, string Ciudad, string Email, int Provincia, int ObraSocial, int IdObrasocial, DateTime FechaAlta, int sexo, DateTime fechaNac)
        {
            this.IdPaciente = IdPaciente;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Documento = Documento;
            this.Direccion = Direccion;
            this.CPostal = CPostal;
            this.TelefonoF = TelefonoF;
            this.TelefonoM = TelefonoM;
            this.NroAfiliado = NroAfiliado;
            this.Ciudad = Ciudad;
            this.Email = Email;
            this.Provincia = Provincia;
            this.ObraSocial = ObraSocial;
            this.IdObrasocial = IdObrasocial;
            this.FechaAlta = FechaAlta;
            this.fechaNac = fechaNac;
            this.sexo = sexo;
        }
    }
}
