using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using VersionSystem3Tire.BAL;

/// <summary>
/// Summary description for CommonFillMethod
/// </summary>
/// 

namespace VersionSystem3Tire 
{
    public class CommonFillMethod
    {
        #region CommonFillMethod Constructore
        public CommonFillMethod()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region FillDropDownList Country 
        public static void FillDropDownListCountry(DropDownList ddl)
        {
            // ama drop down country nu che pan dal state ma thi ave chhe 

            LOC_StateBAL balLOC_State = new LOC_StateBAL();
            ddl.DataSource = balLOC_State.SelectForDropDown();
            ddl.DataValueField = "CountryID";
            ddl.DataTextField = "CountryName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("---Select Country---", "-1"));
        }
        #endregion
    }
}
