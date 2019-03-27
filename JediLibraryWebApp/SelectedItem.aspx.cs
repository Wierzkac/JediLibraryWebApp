using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace JediLibraryWebApp
{
    public partial class SelectedItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            edycja.Visible = false;
            wlaczonaEdycja.Visible = false;
            SqlConnection connectionSQL;
            connectionSQL = (SqlConnection)Session["Connection"];
            string nameTable = Request.QueryString["name"];
            string id = Request.QueryString["id"];
            string query = "select * from " + nameTable + " where ClassID >=" + Session["ID"] + " and ID=" + id + ";";
            SqlCommand command = new SqlCommand(query, connectionSQL);
            SqlDataReader reader = null;
            try
            {
                connectionSQL.Open();
                reader = command.ExecuteReader();
                reader.Read();
                if (nameTable == "Missions")
                {
                    var title = new HtmlGenericControl("h1");
                    title.InnerHtml = reader[2].ToString();
                    var year = new HtmlGenericControl("h3");
                    year.InnerHtml = "Year: " + reader[1].ToString();
                    var planets = new HtmlGenericControl("p");
                    planets.InnerHtml = "Planets: ";
                    var knights = new HtmlGenericControl("p");
                    knights.InnerHtml = "Knights: ";
                    query = "select Knights.Name, Knights.ClassOfJediOrder from Knights, MissionMembership MM where MM.KnightID = Knights.ID and MM.MissionID = " + id + ";";
                    command = new SqlCommand(query, connectionSQL);
                    reader.Close();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        knights.InnerHtml += reader[0].ToString() + " (" + reader[1].ToString() + "), ";
                    }
                    reader.Close();
                    query = "select Planets.Name, Planets.Sector from Planets, PlaceOfMission POM where Planets.ID = POM.PlanetID and POM.MissionID =" + id + ";";
                    command = new SqlCommand(query, connectionSQL);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        planets.InnerHtml += reader[0].ToString() + " (" + reader[1].ToString() + "), ";
                    }
                    MyDiv.Controls.Add(title);
                    MyDiv.Controls.Add(year);
                    MyDiv.Controls.Add(planets);
                    MyDiv.Controls.Add(knights);

                }
                else if (nameTable == "Holocrons")
                {
                    var title = new HtmlGenericControl("h1");
                    title.InnerHtml = reader[1].ToString();
                    var year = new HtmlGenericControl("h3");
                    year.InnerHtml = "Year: " + reader[2].ToString();
                    var author = new HtmlGenericControl("p");
                    author.InnerHtml = "Author: " + reader[4].ToString();
                    var content = new HtmlGenericControl("p");
                    content.InnerHtml = "Content: " + reader[3].ToString();

                    MyDiv.Controls.Add(title);
                    MyDiv.Controls.Add(year);
                    MyDiv.Controls.Add(author);
                    MyDiv.Controls.Add(content);
                    var tmp = new TextBox();
                    tmp.Text = reader[1].ToString();
                    wlaczonaEdycja.Controls.Add(tmp);
                    var enter = new HtmlGenericControl("br");
                    wlaczonaEdycja.Controls.Add(enter);

                    tmp = new TextBox();
                    tmp.Text = reader[2].ToString();
                    wlaczonaEdycja.Controls.Add(tmp);
                    enter = new HtmlGenericControl("br");
                    wlaczonaEdycja.Controls.Add(enter);

                    tmp = new TextBox();
                    tmp.Text = reader[4].ToString();
                    wlaczonaEdycja.Controls.Add(tmp);
                    enter = new HtmlGenericControl("br");
                    wlaczonaEdycja.Controls.Add(enter);

                    
                    var tmp2 = new HtmlGenericControl("textarea");
                    tmp2.InnerHtml = reader[3].ToString();
                    tmp2.Attributes["rows"] = "30";
                    tmp2.Attributes["cols"] = "1000";

                    wlaczonaEdycja.Controls.Add(tmp2);
                    enter = new HtmlGenericControl("br");
                    wlaczonaEdycja.Controls.Add(enter);

                    tmp = new TextBox();
                    tmp.Text = reader[5].ToString();
                    wlaczonaEdycja.Controls.Add(tmp);
                    enter = new HtmlGenericControl("br");
                    wlaczonaEdycja.Controls.Add(enter);

                }
                reader.Close();
                connectionSQL.Close();
            }
            catch (Exception ar)
            {
                errors.InnerText = ar.Message;
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            MyDiv.Visible = false;
            wlaczonaEdycja.Visible = true;
            edycja.Visible = true;
            widok.Visible = false;
        }
    }
}