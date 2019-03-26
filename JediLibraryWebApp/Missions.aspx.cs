using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace JediLibraryWebApp
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connectionSQL;
            string query = "select * from Missions where ClassID >"+Session["ID"]+";";
            connectionSQL = (SqlConnection)Session["Connection"];
            SqlCommand command = new SqlCommand(query, connectionSQL);
            SqlDataReader reader = null;
            try
            {
                connectionSQL.Open();
                reader = command.ExecuteReader();
                int j = 0;
                while (reader.Read())
                {
                    TableRow r = new TableRow();
                    for (int i = 0; i < 4; i++)
                    {
                        TableCell c = new TableCell();
                        c.Text = reader[i].ToString();
                        r.Cells.Add(c);
                    }
                    Table1.Rows.Add(r);
                    j++;
                }
                reader.Close();
                connectionSQL.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}