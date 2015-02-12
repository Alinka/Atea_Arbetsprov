using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

namespace WebApplication
{
    public class DBAdapter
    {
        private string connectionString = @"Data Source = D:\Visual Studio\VS Workspace\Atea_Prov\WebApplication\App_Data\Messages.sdf; Persist Security Info=False;";
       
        internal string Write(DateTime date, string str)
        {
            string inserQry = "INSERT INTO message_list(date_stamp, message)VALUES('" + date + "', @msg)";
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                using (SqlCeCommand cmd = new SqlCeCommand(inserQry, connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@msg", str);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        return "Your message was saved";
                    }
                    catch (SqlCeException ex)
                    {
                        return ex.ToString();
                    }
                }
            }
        }

        internal DataSet Read()
        {
            string selectQry = "SELECT date_stamp, message FROM message_list ORDER BY date_stamp DESC";
            DataSet dataMessages = new DataSet();
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                using (SqlCeCommand cmd = new SqlCeCommand(selectQry, connection))
                {
                    using (SqlCeDataAdapter adapter = new SqlCeDataAdapter())
                    {
                        try
                        {
                            cmd.Connection.Open();
                            adapter.SelectCommand = cmd;
                            adapter.Fill(dataMessages, "Messages");
                            return dataMessages;
                        }
                        catch (SqlCeException ex)
                        {
                            HttpContext.Current.Response.Write(ex.Message);
                            return null;
                        }
                    }
                }
            }
        }
    }
}