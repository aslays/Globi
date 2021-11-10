using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Globi
{
    class DataBase
    {
        OleDbConnection conexion;
        OleDbCommand comando;
        OleDbDataReader dreader;

        public DataBase(string stringconnection)
        {
            conexion = new OleDbConnection(stringconnection);
            comando = new OleDbCommand();
        }

        public OleDbDataReader pdreader
        {
            set { dreader = value; }
            get { return dreader; }
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

        public void LeerDatareader(string query)
        {
            Conectar();
            comando.CommandText = "select * from " + query;
            dreader = comando.ExecuteReader();
        }
    }
}
