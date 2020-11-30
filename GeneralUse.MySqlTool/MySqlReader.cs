using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SharedLibrary.GeneralUse.MySqlTool
{


    public class MySqlReader
    {
        MySqlConnection Connection;
        MySqlCommand Command;
        public MySqlDataReader DataReader;



        public MySqlReader(string SqlConnStr)
        {
            Connection = new MySqlConnection(SqlConnStr);
            OpenConnection();
        }

        public void OpenConnection()
        {
            try
            {
                Connection.Open();
            }
            catch
            {
            }
        }

        public void ReadFrom(string colonne, string nomeTabella, string whereInfo = null)
        {
            if (Connection.State == ConnectionState.Open)
            {
                if (string.IsNullOrEmpty(whereInfo))
                    Command = new MySqlCommand("SELECT " + colonne + "  FROM " + nomeTabella, Connection);
                else
                    Command = new MySqlCommand("SELECT " + colonne + "  FROM " + nomeTabella + " WHERE " + whereInfo, Connection);
                DataReader = Command.ExecuteReader();
            }
        }


        public void ReadFromRaw(string Raw)
        {
            Command = new MySqlCommand(Raw, Connection);
            DataReader = Command.ExecuteReader();
        }

    }


    
}

