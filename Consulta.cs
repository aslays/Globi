using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globi
{
    class Consulta
    {
        string motivo;
        string aclaraciones;
        DateTime fechaConsulta;
        int idDiagnostico;
        int idPractica;
        int idPaciente;
        int idMedico;
        string ApeMedico;
        string Prestacion;
        string Diagnostico;


        public int pIdPaciente
        {
            set { idPaciente = value; }
            get { return idPaciente; }
        }
        public int pIdMedico
        {
            set { idMedico = value; }
            get { return idMedico; }
        }
        public int pidPractica
        {
            set { idPractica = value; }
            get { return idPractica; }
        }
        public int pidDiagnostico
        {
            set { idDiagnostico = value; }
            get { return idDiagnostico; }
        }
        public DateTime pFechaConsulta
        {
            set { fechaConsulta = value; }
            get { return fechaConsulta; }
        }
        public string pMotivo
        {
            set { motivo = value; }
            get { return motivo; }
        }
        public string pAclaraciones
        {
            set { aclaraciones = value; }
            get { return aclaraciones; }
        }
        public string pApeMedico
        {
            set { ApeMedico = value; }
            get { return ApeMedico; }
        }
        public string pPrestacion
        {
            set { Prestacion = value; }
            get { return Prestacion; }
        }
        public string pDiagnostico
        {
            set { Diagnostico = value; }
            get { return Diagnostico; }
        }

        public Consulta()
        {
            idPractica = 0;
            idPaciente = 0;
            idDiagnostico = 0;
            idMedico = 0;
            motivo = "";
            aclaraciones = "";
            fechaConsulta = DateTime.Today;
            ApeMedico = "";
            Prestacion = "";
        }
        public Consulta(int idPractica, int idPaciente, int idDiagnostico, int idMedico, string aclaraciones, string motivo, DateTime fechaConsulta, string ApeMedico, string Prestacion)
        {
            this.idPractica = idPractica;
            this.idPaciente = idPaciente;
            this.idMedico = idMedico;
            this.idDiagnostico = idDiagnostico;
            this.motivo = motivo;
            this.aclaraciones = aclaraciones;
            this.fechaConsulta = fechaConsulta;
            this.ApeMedico = ApeMedico;
            this.Prestacion = Prestacion;

        }

    }
}
