using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevOne.Security.Cryptography.BCrypt;

namespace apex_store
{
    public partial class Login : System.Web.UI.Page
    {
        // connection to database
        static string connectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //string password = tbxPassword.Text + "^Y8~JJ"; // making it a little harder for hackers
            //string hashedPassword = BCryptHelper.HashPassword(password, BCryptHelper.GenerateSalt(12));
            //byte[] arr = System.Text.Encoding.ASCII.GetBytes(hashedPassword);

            if (IsValid)
            {
                #region Input Reads

                string fName = tbxFname.Text;
                string lName = tbxLname.Text;
                string email = tbxEmail.Text;
                string hashedPassword = CreateHash(tbxPassword.Text);
                string gender = rbnGender.SelectedValue;
                DateTime dob = Convert.ToDateTime(tbxDob.Text);

                #endregion

                if (tbxPassword.Text == tbxConfirmPassword.Text)
                {
                    #region Insert User

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("Insert_User", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = fName;
                            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lName;
                            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = hashedPassword;
                            cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = gender;
                            cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = dob;

                            var outparam = new SqlParameter("@UserExists", SqlDbType.Int);
                            outparam.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(outparam);

                            try
                            {
                                con.Open();
                                int rowAffected = cmd.ExecuteNonQuery();

                                if ((int) outparam.Value == 1)
                                {
                                    lblMessage.Text = "Sorry, a user with this e-mail address already exists!";
                                }
                                else
                                {
                                    UserCookie();
                                }
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Insert Error: " + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Passwords do not match!!";
                }
            }

            #endregion
        }

        private void UserCookie()
        {
            
        }

        #region Hashing Password
        // Bcrypt hashing function
        public static string GetRandomSalt()
        {
            string salt = BCryptHelper.GenerateSalt(12);
            return salt;
        }

        public static string CreateHash(string password)
        {
            string hash = BCryptHelper.HashPassword(password, GetRandomSalt());
            return hash;
        }
        #endregion

    }
}