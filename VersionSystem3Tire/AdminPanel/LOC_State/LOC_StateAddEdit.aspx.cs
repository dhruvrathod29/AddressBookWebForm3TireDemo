using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VersionSystem3Tire;
using VersionSystem3Tire.BAL;
using VersionSystem3Tire.ENT;

public partial class AdminPanel_LOC_State_LOC_StateAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            if (Request.QueryString["StateID"]!=null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["StateID"]));
            }
        }
    }
    #endregion

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server side Validation
        String strErrorMessage = "";
        if(ddlCountryID.SelectedIndex==0)
        {
            strErrorMessage += "-Select Country <br/>";
        }
        if (txtStateName.Text.Trim() == "")
        {
            strErrorMessage += "-Enter the StateName <br/>";
        }
        if (txtStateCode.Text.Trim() == "")
        {
            strErrorMessage += "-Enter the StateCode <br/>";
        }
        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            divMessage.Visible = true;
            return;
        }
        #endregion

        #region Collect Form Data 
       
        LOC_StateENT entLOC_State = new LOC_StateENT();
       
        if (ddlCountryID.SelectedIndex>0)
        {
            entLOC_State.CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
        }
        if (txtStateName.Text.Trim()!="")
        {
            entLOC_State.StateName = txtStateName.Text.Trim();
        }
        if (txtStateCode.Text.Trim()!="")
        {
            entLOC_State.StateCode = txtStateCode.Text.Trim();
        }
        #endregion

        #region Call BAL LOC_State

        LOC_StateBAL balLOC_State = new LOC_StateBAL();
      
        if (Request.QueryString["StateID"] == null)
        {
            if (balLOC_State.Insert(entLOC_State))
            {
                ClearControls();
                lblMessage.Text = "Data Inserted Successfully";
                divMessage.Visible = true;

            }
            else
            {
                lblMessage.Text = balLOC_State.Message;
                divMessage.Visible = true;
            }
        }
        else
        {
            entLOC_State.StateID = Convert.ToInt32(Request.QueryString["StateID"]);
            if (balLOC_State.UpdateByPK(entLOC_State))
            {
                ClearControls();

                Response.Redirect("~/AdminPanel/LOC_State/LOC_StateList.aspx", true);
            }
            else
            {
                lblMessage.Text = balLOC_State.Message;
                divMessage.Visible = true;
            }
        }
        #endregion
    }
    #endregion

    #region FillDropDownList

    private void FillDropDownList()
    {
        CommonFillMethod.FillDropDownListCountry(ddlCountryID);   
    }

    #endregion

    #region Clear Controls
    private void ClearControls()
    {
        ddlCountryID.SelectedIndex = 0;
        txtStateName.Text = "";
        txtStateCode.Text = "";
        ddlCountryID.Focus();

    }
    #endregion

    #region FillControls
    private void FillControls(SqlInt32 StateID)
    {
        LOC_StateENT entLOC_State = new LOC_StateENT();
        LOC_StateBAL balLOC_State = new LOC_StateBAL();

        entLOC_State = balLOC_State.SelectByPK(StateID);

        if (entLOC_State.StateName != null)
        {
            txtStateName.Text = entLOC_State.StateName.ToString();
        }
        if (entLOC_State.StateCode != null)
        {
            txtStateCode.Text = entLOC_State.StateCode.ToString();

        }
        if (entLOC_State.CountryID.Value.ToString() != null)
        {
            ddlCountryID.SelectedValue = entLOC_State.CountryID.Value.ToString();
        }
    }

    #endregion
}