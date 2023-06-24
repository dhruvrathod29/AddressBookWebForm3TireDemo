using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatabaseConfig
/// </summary>
/// 
namespace VersionSystem3Tire
{
    public class DatabaseConfig
    {
        #region DataBaseConfig Constructore
        public DatabaseConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Connection String
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["WebDeveloperConnectionString"].ConnectionString.ToString();
        #endregion
    }


}
