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
        public DBAdapter dba = new DBAdapter();

        [WebMethod(Description = "Save to database")]
        public string SendMessage(DateTime date, string str)
        {
            return dba.Write(date, str);
        }
       
        [WebMethod(Description = "Read from database")]
        public DataSet ReadMessage()
        {
            return dba.Read();
        }
    }
}
