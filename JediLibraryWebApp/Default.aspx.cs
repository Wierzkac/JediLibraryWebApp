using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace JediLibraryWebApp
{
    public partial class _Default : Page
    {
        string connetionString = null;
        SqlConnection connectionSQL;
        protected void Page_Load(object sender, EventArgs e)
        {

            //connetionString = "Data Source=tcp:LENOVOY50,33306; Initial Catalog=JediLibraryDB;User ID=Yoda;Password=Plagiacik13";
            //string nameOfPermission ="insert into Users values ('Kacper', 'kacper', 1);";
            connetionString = "Data Source=localhost; Initial Catalog=JediLibraryDB;User ID=Yoda;Password=Plagiacik12";
            connectionSQL = new SqlConnection(connetionString);
            Session["Connection"] = connectionSQL;
            connectionSQL.Open();
            Label2.Text = "Connection Opened!";

            
            if (Session["ID"] != null)
            {
                Label3.Text += Session["Name"];
                Label3.Visible = true;
                MyDiv.Visible = false;
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string login = TextBox1.Text;
            string password = TextBox2.Text;
            string nameOfPermission = "Select Name from JediLibraryDB.dbo.Permissions" +
                                 " Where PermId = (Select ClassID From Users" +
                                                    " Where Username='" + login + "' and HashedPassword='" + password + "');";
            string IDOfPermission = "Select ClassID From Users Where Username='" + login + "' and HashedPassword='" + password + "';";

            try
            {
                SqlCommand command = new SqlCommand(nameOfPermission, connectionSQL);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Label3.Text += reader[0];
                Session["Name"] = reader[0];
                Label3.Visible = true;
                MyDiv.Visible = false;

                reader.Close();

                command = new SqlCommand(IDOfPermission, connectionSQL);
                reader = command.ExecuteReader();
                reader.Read();
                Session["ID"] =reader[0];
                reader.Close();
                connectionSQL.Close();
            }
            catch (Exception ex)
            {
                Label2.Text = "Cannot open connection! "+ex.Message;
            }


        }
    }
}