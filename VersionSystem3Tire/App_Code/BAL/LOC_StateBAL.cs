using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using VersionSystem3Tire.DAL;
using VersionSystem3Tire.ENT;

/// <summary>
/// Summary description for LOC_StateBAL
/// </summary>
/// 

namespace VersionSystem3Tire.BAL
{
    public class LOC_StateBAL
    {
        #region Local Veriable

        protected string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        #endregion

        #region LOC_State Constructore
        public LOC_StateBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Insert Operation
        public Boolean Insert(LOC_StateENT entLOC_State)
        {
            LOC_StateDAL dalLOC_State = new LOC_StateDAL();
            if (dalLOC_State.Insert(entLOC_State))
            {
                return true;
            }
            else
            {
                Message = dalLOC_State.Message;
                return false;   
            }
        }
        #endregion

        #region Update Operation
        public Boolean UpdateByPK(LOC_StateENT entLOC_State)
        {
            LOC_StateDAL dalLOC_State = new LOC_StateDAL();
            if (dalLOC_State.UpdateByPK(entLOC_State))
            {
                return true;
            }
            else
            {
                Message = dalLOC_State.Message;
                return false;
            }
        }
        #endregion

        #region Delete Operation
        public Boolean Delete(SqlInt32 StateID)
        {
            LOC_StateDAL dalLOC_State = new LOC_StateDAL();
            if (dalLOC_State.Delete(StateID))
            {
                return true;
            }
            else
            {
                Message = dalLOC_State.Message;
                return false;   
            }
           

        }
        #endregion

        #region Select Operation

        #region Select All
        public DataTable SelectAll()
        {
            LOC_StateDAL dalLOC_State = new LOC_StateDAL();
            return dalLOC_State.SelectAll();

        }
        #endregion

        #region SelectForDropDown
        public DataTable SelectForDropDown()
        {
            LOC_StateDAL dalLOC_State = new LOC_StateDAL();
            return dalLOC_State.SelectForDropDown();
        }
        #endregion

        #region SelecByPK
        public LOC_StateENT SelectByPK(SqlInt32 StateID)
        {
            LOC_StateDAL dalLOC_State = new LOC_StateDAL();
            return dalLOC_State.SelectByPK(StateID);    

        }
        #endregion

        #endregion
    }
}
