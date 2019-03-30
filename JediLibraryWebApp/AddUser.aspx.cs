using System;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace JediLibraryWebApp
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            SqlConnection connectionSQL = (SqlConnection)Session["Connection"];

            string login = UsernameBox.Text;
            string password = SecurePasswordHasher.Hash(PasswordBox.Text);

            try
            {
                string query = "Select ID From Users Where Username='" + login + "';";

                SqlCommand command = new SqlCommand(query, connectionSQL);
                connectionSQL.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                var tmp = reader[0];
                reader.Close();
                connectionSQL.Close();
                LogLabel.Text = "User with that name already exists. Please choose another name!";
                return;
            }
            catch (Exception ar)
            {
                connectionSQL.Close();
            }


            try
            {
                string query = "insert into Users values ( '" + login +
                    "', '" + password +
                    "', '" + PermissionsBox.Text +
                    "');";
                SqlCommand command = new SqlCommand(query, connectionSQL);
                connectionSQL.Open();
                command.ExecuteReader();
                connectionSQL.Close();
                Response.Redirect("~/Default.aspx");
            }
            catch (Exception ar)
            {
                connectionSQL.Close();
            }
        }
    }
}