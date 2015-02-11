using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class WebPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet dataSetMessages = new DataSet();
            WebSiteService service = new WebSiteService();
            dataSetMessages = service.Read();

            for (int i = 0; i < dataSetMessages.Tables["Messages"].Rows.Count; i++)
            {
                BulletedList.Items.Add(String.Format("{0:HH:mm}",dataSetMessages.Tables[0].Rows[i]["date_stamp"]) + " - " + dataSetMessages.Tables[0].Rows[i]["message"].ToString());
            }
        }
    }
}