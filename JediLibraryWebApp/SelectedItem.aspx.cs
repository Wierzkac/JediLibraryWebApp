﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Text;

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
            if (Convert.ToInt32(id_uprawnien) < 3)
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
                    wlaczonaEdycja.Visible = false;
                    widok.Visible = false;

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
                    tmp.ID = "TitleBox";
                    wlaczonaEdycja.Controls.Add(tmp);
                    var enter = new HtmlGenericControl("br");
                    wlaczonaEdycja.Controls.Add(enter);

                    text = new HtmlGenericControl("p");
                    text.InnerHtml = "Year: ";
                    wlaczonaEdycja.Controls.Add(text);
                    tmp = new TextBox();
                    tmp.Text = reader[2].ToString();
                    tmp.ID = "YearBox";
                    wlaczonaEdycja.Controls.Add(tmp);
                    enter = new HtmlGenericControl("br");
                    wlaczonaEdycja.Controls.Add(enter);

                    text = new HtmlGenericControl("p");
                    text.InnerHtml = "Author: ";
                    wlaczonaEdycja.Controls.Add(text);
                    tmp = new TextBox();
                    tmp.ID = "AuthorBox";
                    tmp.Text = reader[4].ToString();
                    wlaczonaEdycja.Controls.Add(tmp);
                    enter = new HtmlGenericControl("br");
                    wlaczonaEdycja.Controls.Add(enter);


                    text = new HtmlGenericControl("p");
                    text.InnerHtml = "Content: ";
                    wlaczonaEdycja.Controls.Add(text);
                    tmp = new TextBox();
                    tmp.ID = "ContentBox";
                    tmp.TextMode = TextBoxMode.MultiLine;
                    tmp.Style.Add("min-width", "100%");
                    tmp.Style.Add("height", "200px");
                    tmp.Text = reader[3].ToString();
                    wlaczonaEdycja.Controls.Add(tmp);
                    enter = new HtmlGenericControl("br");
                    wlaczonaEdycja.Controls.Add(enter);

                    text = new HtmlGenericControl("p");
                    text.InnerHtml = "Poziom dostępu: ";
                    wlaczonaEdycja.Controls.Add(text);
                    tmp = new TextBox();
                    tmp.Text = reader[5].ToString();
                    tmp.ID = "PoziomDostepuBox";
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

            string title = ((TextBox)wlaczonaEdycja.FindControl("TitleBox")).Text;
            string year = ((TextBox)wlaczonaEdycja.FindControl("YearBox")).Text;
            string content = ((TextBox)wlaczonaEdycja.FindControl("ContentBox")).Text;
            string author = ((TextBox)wlaczonaEdycja.FindControl("AuthorBox")).Text;

           
            if (title.Contains("'")) title = title.Replace("'", "''");
            if (year.Contains("'")) year = year.Replace("'", "''");
            if (content.Contains("'")) content = content.Replace("'", "''");
            if (author.Contains("'")) author = author.Replace("'", "''");




            string query = "update " + nameTable + 
                " set Title = '"+ title +
                "', YearOfPublish = '"+ year +
                "', Content = '" + content + 
                "', Author = '" + author + 
                "', ClassID = '" + ((TextBox)wlaczonaEdycja.FindControl("PoziomDostepuBox")).Text + 
                "' where ID=" + id + ";";

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
                connectionSQL.Close();
                errors.InnerText = ar.Message;
            }
        }
    }
}