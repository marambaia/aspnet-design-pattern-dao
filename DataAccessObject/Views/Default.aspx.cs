using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessObject.Entities;
using DataAccessObject.Business;

namespace DataAccessObject.Views
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id;
                    int.TryParse(Request.QueryString["id"], out id);

                    Films filmsBO = new Films();
                    Film film = filmsBO.ListUser(id);

                    hdfId.Value = film.id.ToString();
                    txtName.Text = film.name;
                    txtPrice.Text = Convert.ToString(film.price.ToString());
                    txtYear.Text = film.year;
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Film film = new Film();

            film.id = int.Parse(hdfId.Value);
            film.name = txtName.Text;
            film.price = Convert.ToDouble(txtPrice.Text);
            film.year = txtYear.Text;

            Films filmsBO = new Films();

            bool saved = filmsBO.Save(film);

            if (saved)
            {
                Response.Redirect("~/Views/Default.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Default.aspx");
        }
    }
}