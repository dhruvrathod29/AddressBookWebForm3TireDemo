using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VersionSystem3Tire.BAL;
using VersionSystem3Tire.ENT;

public partial class AdminPanel_LOC_Country_LOC_CountryAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CountryID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
            }
        }

    }
    #endregion

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server side Validation
        String strErrorMessage = "";
      
        if (txtCountryName.Text.Trim() == "")
        {
            strErrorMessage += "-Enter the CountryName <br/>";
        }
        if (txtCountryCode.Text.Trim() == "")
        {
            strErrorMessage += "-Enter the CountryCode <br/>";
        }
        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            divMessage.Visible = true;
            return;
        }
        #endregion

        #region Collect Form Data 

        LOC_CountryENT entLOC_Country = new LOC_CountryENT();

        
        if (txtCountryName.Text.Trim() != "")
        {
            entLOC_Country.CountryName = txtCountryName.Text.Trim();
        }
        if (txtCountryCode.Text.Trim() != "")
        {
            entLOC_Country.CountryCode = txtCountryCode.Text.Trim();
        }
        #endregion

        #region Call BAL LOC_State

        LOC_CountryBAL balLOC_Country = new LOC_CountryBAL();

        if (Request.QueryString["CountryID"] == null)
        {
            if (balLOC_Country.Insert(entLOC_Country))
            {
                ClearControls();
                lblMessage.Text = "Data Inserted Successfully";
                divMessage.Visible = true;

            }
            else
            {
                lblMessage.Text = balLOC_Country.Message;
                divMessage.Visible = true;
            }
        }
        else
        {
            entLOC_Country.CountryID = Convert.ToInt32(Request.QueryString["CountryID"]);
            if (balLOC_Country.UpdateByPK(entLOC_Country))
            {
                ClearControls();

                Response.Redirect("~/AdminPanel/LOC_Country/LOC_CountryList.aspx", true);
            }
            else
            {
                lblMessage.Text = balLOC_Country.Message;
                divMessage.Visible = true;
            }
        }
        #endregion
    }
    #endregion

    #region Clear Controls
    private void ClearControls()
    {
        txtCountryName.Text = "";
        txtCountryCode.Text = "";
        txtCountryName.Focus();

    }
    #endregion

    #region FillControls
    private void FillControls(SqlInt32 CountryID)
    {
        LOC_CountryENT entLOC_Country = new LOC_CountryENT();
        LOC_CountryBAL balLOC_Country = new LOC_CountryBAL();

        entLOC_Country = balLOC_Country.SelectByPK(CountryID);

        if (!entLOC_Country.CountryName.IsNull)
        {
            txtCountryName.Text = entLOC_Country.CountryName.Value.ToString();
        }
        if (!entLOC_Country.CountryCode.IsNull)
        {
            txtCountryCode.Text = entLOC_Country.CountryCode.Value.ToString();

        }
        
    }

    #endregion
}