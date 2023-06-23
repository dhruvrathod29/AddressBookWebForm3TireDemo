using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VersionSystem3Tire.BAL;

public partial class AdminPanel_LOC_Country_LOC_CountryList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            FillCountryGridView();
        }
    }
    #endregion

    #region FillCountryGridView
    private void FillCountryGridView()
    {
        LOC_CountryBAL balLOC_Country = new LOC_CountryBAL();   
        DataTable dtLOC_Country = new DataTable();
        
        dtLOC_Country = balLOC_Country.SelectAll();

        if (dtLOC_Country != null  && dtLOC_Country.Rows.Count>0)
        {
            gvLOC_Country.DataSource = dtLOC_Country;
            gvLOC_Country.DataBind();   
        }

    }
    #endregion

    #region gvLOC_Country_RowCommand 
    protected void gvLOC_Country_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                LOC_CountryBAL balLOC_Country = new LOC_CountryBAL();
                
                if (balLOC_Country.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillCountryGridView();
                }
                else
                {
                    lblMessage.Text = balLOC_Country.Message;
                    divMessage.Visible = true;
                    
                }
            }
        }
    }
    #endregion

}