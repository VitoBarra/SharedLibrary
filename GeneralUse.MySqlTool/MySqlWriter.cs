using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SharedLibrary.GeneralUse.MySqlTool
{
    public class MySqlWriter
    {
        MySqlConnection Connection;
        MySqlCommand Command;

        public MySqlWriter(string SqlConnStr)
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


        public void ExecuteWriteCommand(string sqlCommand)
        {
            if (Connection.State == ConnectionState.Open)
            {
                Command = new MySqlCommand(sqlCommand, Connection);
                Command.ExecuteNonQuery();
            }
        }

    }
}
