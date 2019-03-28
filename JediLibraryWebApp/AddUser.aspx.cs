using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

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


            string query = "insert into Users values ( '" + UsernameBox.Text +
                "', '" + PasswordBox.Text +
                "', '" + PermissionsBox.Text +
                ");";

            SqlCommand command = new SqlCommand(query, connectionSQL);
            try
            {
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