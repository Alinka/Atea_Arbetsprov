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
            using (WebSiteService service = new WebSiteService())
            {
                //Fill the DataSet
                using (DataSet dataSetMessages = service.ReadMessage())
                {
                    //Loop through the DataSet
                    foreach (DataRow row in dataSetMessages.Tables["Messages"].Rows)
                    {
                        //Retrieve data from DataSet, format it and add it to the bullet list
                        BulletedList.Items.Add(String.Format("{0:HH:mm}", row["date_stamp"]) + " - " + row["message"].ToString());
                    }
                }
            }
            
        }
    }
}