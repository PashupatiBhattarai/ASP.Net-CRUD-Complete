using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Complete;

namespace Asp.NetCrud
{
    public partial class Country : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                AmericaData Ada = new AmericaData();
                GridView1.DataSource = Ada.GetAmerica();
                GridView1.DataBind();

            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        
        protected void btngetdetails_Click(object sender, EventArgs e)
        {
            AmericaData obj = new AmericaData();
            obj.Addmore(txtstatename.Text, txtcity.Text, Convert.ToInt32(txtpopulation.Text), Convert.ToDateTime(txtmodified.Text));
            txtlbl.Text = "Data is saved";

            txtstatename.Text = string.Empty;
            txtcity.Text = string.Empty;
            txtpopulation.Text = string.Empty;
            txtmodified.Text = string.Empty;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            AmericaData obj = new AmericaData();
            obj.UpdateMe(Convert.ToInt32(txtStateid.Text), txtstatename.Text, txtcity.Text, Convert.ToInt32(txtpopulation.Text), Convert.ToDateTime(txtmodified.Text));
            txtlbl.Text = "Data is updated";
            txtStateid.Text = string.Empty;
            txtstatename.Text = string.Empty;
            txtcity.Text = string.Empty;
            txtpopulation.Text = string.Empty;
            txtmodified.Text = string.Empty;

        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            AmericaData dbj = new AmericaData();
            dbj.DeleteMe(Convert.ToInt32(txtStateid.Text));
            txtlbl.Text = "data is deleted";
            txtStateid.Text = string.Empty;


        }

        protected void btnfind_Click(object sender, EventArgs e)
        {
            AmericaData ad = new AmericaData();
            int StateID = Convert.ToInt32(txtStateid.Text);
            List<America> lst = ad.GetAmerica().ToList();
            foreach (America item in lst)
            {
                if (item.StateId == StateID)
                {
                    txtstatename.Text = item.StateName;
                    txtcity.Text = item.City;
                    txtpopulation.Text = Convert.ToInt32(item.Population).ToString();
                    txtmodified.Text = Convert.ToDateTime(item.Modifieddate).ToString();
                    txtlbl.Text = "data is  ";
                }
                else
                {
                    txtlbl.Text = "not data";
                }
            }     
            
        }
    }
}
