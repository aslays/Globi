using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Globi
{
    class BaseDatos
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader dr;

        public SqlDataReader pDr
        {
            get { return dr; }
            set { dr = value; }
        }



        public BaseDatos(string stringConexion)
        {
            conexion = new SqlConnection(stringConexion);
            comando = new SqlCommand();
        }
        public void Conectar()
        {
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }
        public void Desconectar()
        {
            conexion.Close();
        }
        public DataTable Leer(string query)
        {
            DataTable dt = new DataTable(query);
            Conectar();
            comando.Connection = conexion;
            comando.CommandText = query;
            dt.Load(comando.ExecuteReader());
            Desconectar();
            return dt;
        }
        public void Actualizar(string query)
        {
            Conectar();
            comando.CommandText = query;
            comando.ExecuteNonQuery();
            Desconectar();
        }

        public DataTable LeerDataTable(string selectquery)
        {
            DataTable dTable = new DataTable();
            Conectar();
            comando.CommandText = selectquery;
            dTable.Load(comando.ExecuteReader());
            Desconectar();
            return dTable;
        }

        public void LeerDataReader(string query)
        {
            Conectar();
            comando.CommandText = "" + query;
            dr = comando.ExecuteReader();
        }
        
    }
}
