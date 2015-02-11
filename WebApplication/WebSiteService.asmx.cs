using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;


namespace WebApplication
{
    /// <summary>
    /// Summary description for WebSiteService
    /// </summary>
    [WebService(Namespace = "http://localhost/message")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebSiteService : System.Web.Services.WebService
    {
        
        public SqlCeConnection connection = new SqlCeConnection(@"Data Source = D:\Visual Studio\VS Workspace\Atea_Prov\WebApplication\App_Data\Messages.sdf; Persist Security Info=False;");
            
        [WebMethod(Description = "Save to database")]
        public void WriteInDb(DateTime date, string str)
        {
            string inserQry = "INSERT INTO message_list(date_stamp, message)VALUES('" + date + "', @msg)";
            try
            {
                connection.Open();
                SqlCeCommand cmd = connection.CreateCommand();
                cmd.CommandText = inserQry;
                cmd.Parameters.AddWithValue("@msg", str);
                cmd.ExecuteNonQuery();
                
            }
            catch (SqlCeException ex)
            {
                ex.ToString();
            }
            finally
            {
                connection.Close();
            }
        }

        [WebMethod(Description = "I came I saw I conquered")]
        public DataSet Read()
        {
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            string selectQry = "SELECT date_stamp, message FROM message_list ORDER BY date_stamp DESC";
            DataSet dataMessages = new DataSet();

            try
            {
                connection.Open();
                SqlCeCommand cmd = connection.CreateCommand();
                cmd.CommandText = selectQry;
                adapter.SelectCommand = cmd;
                adapter.Fill(dataMessages, "Messages");
                return dataMessages;

            }
            catch (SqlCeException ex)
            {
                System.Web.HttpContext.Current.Response.Write(ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
            //return "Veni Vidi Vici";
        }
    }
}
