using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VersionSystem3Tire;

public partial class AdminPanel_LOC_State_LOC_StateAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();

        }
    }
    #endregion

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region FillDropDownList

    private void FillDropDownList()
    {
        CommonFillMethod.FillDropDownListCountry(ddlCountryID);   
    }

    #endregion
}