using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using VersionSystem3Tire.DAL;
using VersionSystem3Tire.ENT;

/// <summary>
/// Summary description for LOC_CountryBAL
/// </summary>
/// 


namespace VersionSystem3Tire.BAL
{
    public class LOC_CountryBAL
    {
        #region Veriable
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

        #region Constructor
        public LOC_CountryBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Select Operation

        #region Select All
        public DataTable SelectAll()
        {
            LOC_CountryDAL dalLOC_Country = new LOC_CountryDAL();   
            return dalLOC_Country.SelectAll();
        }
        #endregion

        #region SelectByPK
        public LOC_CountryENT SelectByPK(SqlInt32 CountryID)
        {
            LOC_CountryDAL dalLOC_Country = new LOC_CountryDAL();
            return dalLOC_Country.SelectByPK(CountryID);    

        }
        #endregion

        #endregion

        #region Delete Operation

        #region Delete
        public Boolean Delete(SqlInt32 CountryID)
        {
            LOC_CountryDAL dalLOC_Country = new LOC_CountryDAL();

            if (dalLOC_Country.Delete(CountryID))
            {
                return true;
            }
            else
            {
                Message = dalLOC_Country.Message;
                return false;
            }
             
        }
        #endregion

        #endregion

        #region Insert Operation

        #region Insert
        public Boolean Insert(LOC_CountryENT entLOC_Country)
        {
            LOC_CountryDAL dalLOC_Country = new LOC_CountryDAL();

            if (dalLOC_Country.Insert(entLOC_Country))
            {
                return true;
            }
            else
            {
                Message = dalLOC_Country.Message;
                return false;
            }
        }
        #endregion

        #endregion

        #region Update Operation

        #region Update 
        public Boolean UpdateByPK(LOC_CountryENT entLOC_Country)
        {
            LOC_CountryDAL dalLOC_Country = new LOC_CountryDAL();
            if (dalLOC_Country.UpdateByPK(entLOC_Country))
            {
                return true;
            }
            else
            {
                Message = dalLOC_Country.Message;

                return false;

            }
        }
        #endregion

        #endregion


    }
}
