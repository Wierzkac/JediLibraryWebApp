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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=192.168.43.215,3306; Network Library = DBMSSOCN; Initial Catalog=JediLibraryDB;User ID=Yoda;Password=Plagiacik12";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                Label2.Text = "Connection Opened!";
                cnn.Close();
            }
            catch (Exception ex)
            {
                Label2.Text = "Cannot open connection! ";
            }


        }
    }
}