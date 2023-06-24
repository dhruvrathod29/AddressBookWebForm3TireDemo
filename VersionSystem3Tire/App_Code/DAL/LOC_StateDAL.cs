using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using VersionSystem3Tire.ENT;

/// <summary>
/// Summary description for LOC_StateDAL
/// </summary>
/// 

namespace VersionSystem3Tire.DAL
{
    public class LOC_StateDAL : DatabaseConfig
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

        #region LOC_State Constuctore
        public LOC_StateDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Insert Operation
        public Boolean Insert(LOC_StateENT entLOC_State)
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
                        objCmd.CommandText = "[PR_LOC_State_InsertRecord]";
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = entLOC_State.CountryID;
                        objCmd.Parameters.Add("@StateName", SqlDbType.NChar).Value = entLOC_State.StateName;
                        objCmd.Parameters.Add("@StateCode", SqlDbType.NChar).Value = entLOC_State.StateCode;
                       /* objCmd.Parameters.Add("@CreationDate", SqlDbType.DateTime).Value = entLOC_State.CreationDate;
                        objCmd.Parameters.Add("@ModificationDate", SqlDbType.DateTime,DateTime.Now.ToString("dd-MM-yyyy")).Value = entLOC_State.ModificationDate;
*/
                        objCmd.ExecuteNonQuery();

                       /* if (objCmd.Parameters["StateID"] != null)
                        {
                            entLOC_State.StateID = Convert.ToInt32(objCmd.Parameters["StateID"].Value);
                        }*/
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
        public Boolean UpdateByPK(LOC_StateENT entLOC_State)
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
                        objCmd.CommandText = "PR_LOC_State_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@StateID", entLOC_State.StateID);
                        objCmd.Parameters.AddWithValue("@CountryID", entLOC_State.CountryID);
                        objCmd.Parameters.AddWithValue("@StateName", entLOC_State.StateName);
                        objCmd.Parameters.AddWithValue("@StateCode", entLOC_State.StateCode);
                    
                        objCmd.Parameters.AddWithValue("@ModificationDate", entLOC_State.ModificationDate);


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

        #region Delete Operration
        public Boolean Delete(SqlInt32 StateID)
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
                        objCmd.CommandText = "PR_LOC_State_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@StateID", StateID);
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

        #region Select All
        public DataTable SelectAll()
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
                        objCmd.CommandText = "PR_LOC_State_SelectAll";

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

        #region SelectForDropDown
        public DataTable SelectForDropDown()
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
                        objCmd.CommandText = "PR_LOC_Country_SelectForDropDown";

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

        #region SelectByPk
        public LOC_StateENT SelectByPK(SqlInt32 StateID)
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
                        objCmd.CommandText = "PR_LOC_State_SelectByPK";
                        objCmd.Parameters.AddWithValue("@StateID", StateID);   

                        #endregion

                        #region ReadData And Set Controls
                        LOC_StateENT entLOC_State = new LOC_StateENT();  
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                {
                                    entLOC_State.StateID = Convert.ToInt32(objSDR["StateID"]);
                                }
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                {
                                    entLOC_State.CountryID = Convert.ToInt32(objSDR["CountryID"]);                                   
                                }
                                if (!objSDR["StateName"].Equals(DBNull.Value))
                                {
                                    entLOC_State.StateName = Convert.ToString(objSDR["StateName"]);
                                }
                                if (!objSDR["StateCode"].Equals(DBNull.Value))
                                {
                                    entLOC_State.StateCode = Convert.ToString(objSDR["StateCode"]);
                                }
                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                {
                                    entLOC_State.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                                }
                                if (!objSDR["ModificationDate"].Equals(DBNull.Value))
                                {
                                    entLOC_State.ModificationDate = Convert.ToDateTime(objSDR["ModificationDate"]);
                                }
                            }
                        }
                        return entLOC_State;
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
