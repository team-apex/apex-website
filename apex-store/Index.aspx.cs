using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace apex_store
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Page Visits
            int counter;

            if (Request.Cookies["counter"] == null)
            {
                counter = 0;
            }
            else
            {
                counter = int.Parse(Request.Cookies["counter"].Value);
            }
            counter++;

            Response.Cookies["counter"].Value = counter.ToString();
            Response.Cookies["counter"].Expires = DateTime.Now.AddMonths(18);
            #endregion

        }
    }
}