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
        private SqlConnection connectionSQL;
        private string nameTable;
        private string id;
        private string id_uprawnien;

        protected void Page_Load(object sender, EventArgs e)
        {
            edycja.Visible = false;
            wlaczonaEdycja.Visible = false;
            connectionSQL = (SqlConnection)Session["Connection"];
            id_uprawnien = Session["ID"].ToString();
            nameTable = Request.QueryString["name"];
            id = Request.QueryString["id"];
            string query = "select * from " + nameTable + " where ClassID >=" + Session["ID"] + " and ID=" + id + ";";
            if (Convert.ToInt32(id_uprawnien) == 1)
            {
                DeleteButton.Visible = true;
            }
            else if (Convert.ToInt32(id_uprawnien) < 3)
            {
                EditButton.Visible = true;
            }
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

                    var text = new HtmlGenericControl("p");
                    text.InnerHtml = "Title: ";
                    wlaczonaEdycja.Controls.Add(text);
                    var tmp = new TextBox();
                    tmp.Text = reader[1].ToString();
                    tmp.ID = "Title";
                    wlaczonaEdycja.Controls.Add(tmp);
                    var enter = new HtmlGenericControl("br");
                    wlaczonaEdycja.Controls.Add(enter);

                    text = new HtmlGenericControl("p");
                    text.InnerHtml = "Year: ";
                    wlaczonaEdycja.Controls.Add(text);
                    tmp = new TextBox();
                    tmp.Text = reader[2].ToString();
                    tmp.ID = "Year";
                    wlaczonaEdycja.Controls.Add(tmp);
                    enter = new HtmlGenericControl("br");
                    wlaczonaEdycja.Controls.Add(enter);

                    text = new HtmlGenericControl("p");
                    text.InnerHtml = "Author: ";
                    wlaczonaEdycja.Controls.Add(text);
                    tmp = new TextBox();
                    tmp.ID = "Author";
                    tmp.Text = reader[4].ToString();
                    wlaczonaEdycja.Controls.Add(tmp);
                    enter = new HtmlGenericControl("br");
                    wlaczonaEdycja.Controls.Add(enter);


                    text = new HtmlGenericControl("p");
                    text.InnerHtml = "Content: ";
                    wlaczonaEdycja.Controls.Add(text);
                    var tmp2 = new HtmlGenericControl("textarea");
                    tmp2.InnerHtml = reader[3].ToString();
                    tmp2.Attributes["rows"] = "10";
                    tmp2.Attributes["cols"] = "1000";
                    wlaczonaEdycja.Controls.Add(tmp2);
                    tmp2.ID = "Content";
                    enter = new HtmlGenericControl("br");
                    wlaczonaEdycja.Controls.Add(enter);

                    text = new HtmlGenericControl("p");
                    text.InnerHtml = "Poziom dostępu: ";
                    wlaczonaEdycja.Controls.Add(text);
                    tmp = new TextBox();
                    tmp.Text = reader[5].ToString();
                    tmp.ID = "PoziomDostepu";
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            MyDiv.Visible = true;
            wlaczonaEdycja.Visible = false;
            edycja.Visible = false;
            widok.Visible = true;

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            string query = "delete from " + nameTable + " where ID=" + id + ";";

            SqlCommand command = new SqlCommand(query, connectionSQL);
            try
            {
                connectionSQL.Open();
                command.ExecuteReader();
                connectionSQL.Close();

                Response.Redirect("~/"+nameTable);



            }
            catch (Exception ar)
            {
                errors.InnerText = ar.Message;
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string query = "update " + nameTable + " set Title = 'Zmiana', YearOfPublish = 'Zmiana', Content = 'Zmiana', Author = 'Zmiana', ClassID = '2'" +" where ID=" + id + ";";

            SqlCommand command = new SqlCommand(query, connectionSQL);
            try
            {
                connectionSQL.Open();
                command.ExecuteReader();
                connectionSQL.Close();

                Response.Redirect("~/" + nameTable);



            }
            catch (Exception ar)
            {
                errors.InnerText = ar.Message;
            }
        }
    }
}