using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevOne.Security.Cryptography.BCrypt;

namespace apex_store
{
    public partial class Login1 : System.Web.UI.Page
    {
        // connection to database
        static string connString = WebConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string select = "SELECT * FROM [Customers] WHERE Email = @Email";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand(select, conn);

                    cmd.Parameters.AddWithValue("@Email", tbxEmail.Text);

                    conn.Open();

                    // initialise reader and execute command
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // check if user exists
                        if (!reader.HasRows)
                        {
                            // no user exists
                        }
                        else
                        {
                            lbl1.Text = Convert.ToString(reader["Email"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = "Insert error: ";
                throw new Exception(msg += ex.Message);
            }
        }

        //#region Password decrypt
        //public static bool ValidatePassword(string password, string correctHash)
        //{
        //    return BCryptHelper.CheckPassword(password, correctHash);
        //}
        //#endregion
    }
}