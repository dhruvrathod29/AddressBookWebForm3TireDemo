using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LOC_StateENT
/// </summary>
/// 

namespace VersionSystem3Tire.ENT
{
    public class LOC_StateENT
    {
        #region LOC_State Constuctore
        public LOC_StateENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region StateID
        protected SqlInt32 _StateID;
        public SqlInt32 StateID
        {
            get
            {
                return _StateID;
            }
            set
            {
                _StateID = value;
            }

        }
        #endregion

        #region CountryID
        protected SqlInt32 _CountryID;
        public SqlInt32 CountryID
        {
            get
            {
                return _CountryID;
            }
            set { _CountryID = value; }
        }
        #endregion

        #region StateName
        protected string _StateName;
        public string StateName
        {
            get
            {
                return _StateName;
            }
            set
            {
                _StateName = value;
            }
        }
        #endregion

        #region StateCode
        protected string _StateCode;
        public string StateCode
        {
            get
            {
                return _StateCode;
            }
            set 
            { 
                _StateCode = value;
            }
        }
        #endregion

        #region Creation Date
        protected SqlDateTime _CreationDate;
        public SqlDateTime CreationDate
        {
            get
            {
                return _CreationDate;
            }
            set 
            { 
                _CreationDate = value;
            }
        }
        #endregion

        #region ModificationDate
        protected SqlDateTime _ModificationDate;
        public SqlDateTime ModificationDate
        {
            get
            {
                return _ModificationDate;
            }
            set
            {
                _ModificationDate = value;
            }
        }
        #endregion
    }
}
