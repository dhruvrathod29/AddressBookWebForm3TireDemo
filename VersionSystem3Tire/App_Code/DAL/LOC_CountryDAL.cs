using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using VersionSystem3Tire.ENT;

/// <summary>
/// Summary description for LOC_CountryDAL
/// </summary>
/// 


namespace VersionSystem3Tire.DAL
{
    public class LOC_CountryDAL : DatabaseConfig
    {

        #region Local Variables
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

        #region LOC_CountryDAL Constructor
        public LOC_CountryDAL()
        {
            //
            // TODO: Add constructor logic here
            //


        }
        #endregion

        #region Insert Operation
        public Boolean Insert(LOC_CountryENT entLOC_Country)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_LOC_Country_InsertRecord";
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@CountryName", SqlDbType.NChar).Value = entLOC_Country.CountryName;
                        objCmd.Parameters.Add("@CountryCode", SqlDbType.NChar).Value = entLOC_Country.CountryCode;
                        objCmd.Parameters.Add("@CreationDate", SqlDbType.DateTime).Value = entLOC_Country.CreationDate;
                        objCmd.Parameters.Add("@ModificationDate", SqlDbType.NChar).Value = entLOC_Country.ModificationDate;

                        objCmd.ExecuteNonQuery();

                        entLOC_Country.CountryID = (SqlInt32)objCmd.Parameters["CountryID"].Value;
                        return true;
                        #endregion

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        #endregion

        #region Update Operation
        public Boolean UpdateByPK(LOC_CountryENT entLOC_Country)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_LOC_Country_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@CountryID", entLOC_Country.CountryID);
                        objCmd.Parameters.AddWithValue("@CountryName", entLOC_Country.CountryName);
                        objCmd.Parameters.AddWithValue("@CountryCode", entLOC_Country.CountryCode);
                        objCmd.Parameters.AddWithValue("@CreationDate", entLOC_Country.CreationDate);
                        objCmd.Parameters.AddWithValue("@ModificationDate", entLOC_Country.ModificationDate);


                        objCmd.ExecuteNonQuery();

              
                        return true;
                        #endregion

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }

        #endregion

        #region Delete Operation
        public Boolean Delete(SqlInt32 CountryID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_LOC_Country_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
                        objCmd.ExecuteNonQuery();
                        return true;
                        #endregion

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        #endregion

        #region Select Operation

        #region Country_SelectAll
        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand()) 
                {
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_LOC_Country_SelectAll";

                        #endregion


                        #region ReadData And Set Controls

                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }



                  
                }

            }

        }
        #endregion

        #region Country_SelectByPK
        public LOC_CountryENT SelectByPK(SqlInt32 CountryID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_LOC_Country_SelectByPK";
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
                        #endregion

                        #region ReadData And Set Controls
                        
                        LOC_CountryENT entLOC_Country = new LOC_CountryENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                {
                                    entLOC_Country.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                }
                                if (!objSDR["CountryCode"].Equals(DBNull.Value))
                                {
                                    entLOC_Country.CountryCode = Convert.ToString(objSDR["CountryCode"]);

                                }
                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                {
                                    entLOC_Country.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                                }
                                if (!objSDR["ModificationDate"].Equals(DBNull.Value))
                                {
                                    entLOC_Country.ModificationDate = Convert.ToDateTime(objSDR["ModificationDate"]);
                                }
                            }
                        }
                        return entLOC_Country;
                        #endregion

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }




                }

            }

        }
        #endregion


        #endregion

    }


}
