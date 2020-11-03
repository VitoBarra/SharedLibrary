using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SharedLibrary.GeneralUse.MySqlTool
{


    class MySqlReaderTool
    {
        MySqlConnection conn;
        MySqlCommand com;
        public MySqlDataReader reader;



        public MySqlReaderTool(string SqlConnStr)
        {
            conn = new MySqlConnection(SqlConnStr);
            Connection();
        }




        public void Connection()
        {
            try
            {
                conn.Open();
            }
            catch
            {
            }
        }



        public void ReadFrom(string colonne, string nomeTabella, string whereInfo = null)
        {
            if (conn.State == ConnectionState.Open)
            {
                if (string.IsNullOrEmpty(whereInfo))
                    com = new MySqlCommand("SELECT " + colonne + "  FROM " + nomeTabella, conn);
                else
                    com = new MySqlCommand("SELECT " + colonne + "  FROM " + nomeTabella + " WHERE " + whereInfo, conn);
                reader = com.ExecuteReader();
            }
        }
    }


    class MySqlWriterTool
    {
        MySqlConnection conn;
        MySqlCommand com;

        public MySqlWriterTool(string SqlConnStr)
        {
            conn = new MySqlConnection(SqlConnStr);

            Connection();
        }


        public void Connection()
        {
            try
            {
                conn.Open();
            }
            catch
            {
            }
        }


        public void ExecuteWriteCommand(string sqlCommand)
        {
            if (conn.State == ConnectionState.Open)
            {
                com = new MySqlCommand(sqlCommand, conn);
                com.ExecuteNonQuery();
            }
        }

    }
}

