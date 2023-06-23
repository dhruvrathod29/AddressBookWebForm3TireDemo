using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VersionSystem3Tire.BAL;

public partial class AdminPanel_LOC_State_LOC_StateList : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillStateGridView();
        }
    }
    #endregion

    #region FillStateGridView
    private void FillStateGridView()
    {
        LOC_StateBAL balLOC_State = new LOC_StateBAL();
        DataTable dtLOC_State = new DataTable();
        dtLOC_State = balLOC_State.SelectAll();

        if (dtLOC_State != null && dtLOC_State.Rows.Count > 0)
        {
            gvLOC_State.DataSource = dtLOC_State;
            gvLOC_State.DataBind(); 
        }

    }
    #endregion

    #region gvState_RowCommand
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                LOC_StateBAL balLOC_State = new LOC_StateBAL();
                if (balLOC_State.Delete(Convert.ToInt32(e.CommandArgument.ToString())))
                {
                    FillStateGridView(); 
                }
                else
                {
                    lblMessage.Text = balLOC_State.Message;
                    divMessage.Visible = true;  

                }
            }
        }
    }
    #endregion
}