using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Tools

{
    /// <summary>
    /// Tools for Database SQL Server Manager
    /// </summary>
    public class DatabaseSQLServerManagerTools
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private string connectionString = ConfigurationTools.ConnectionStringDB;

        public DataTable SelectStoredProcedure(string procedureName, Dictionary<string, object> parameters)
        {
            SqlConnection m_dbConnection = null;

            try
            {
                m_dbConnection = new SqlConnection(connectionString);
                m_dbConnection.Open();
                
                SqlCommand command = new SqlCommand(procedureName, m_dbConnection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<string, object> keyValuePair in parameters)
                {
                    command.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value.ToString());
                }

                SqlDataReader dataReader = command.ExecuteReader();

                DataTable tableToReturn = new DataTable();
                tableToReturn.Load(dataReader);

                return tableToReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                try
                {
                    if (m_dbConnection != null)
                    {
                        m_dbConnection.Close();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public void InsertStoredProcedure(string procedureName, Dictionary<string, object> parameters)
        {
            SqlConnection m_dbConnection = null;

            try
            {
                m_dbConnection = new SqlConnection(connectionString);
                m_dbConnection.Open();

                SqlCommand command = new SqlCommand(procedureName, m_dbConnection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<string, object> keyValuePair in parameters)
                {
                    command.Parameters.AddWithValue("@"+keyValuePair.Key, keyValuePair.Value);
                }

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                try
                {
                    if (m_dbConnection != null)
                    {
                        m_dbConnection.Close();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// Insert or delete.
        /// </summary>
        /// <param name="sqlInsertOrDelete">The SQL insert or delete.</param>
        public void InsertOrDelete(string sqlInsertOrDelete)
        {
            SqlConnection m_dbConnection = null;

            try
            {
                m_dbConnection = new SqlConnection(connectionString);
                m_dbConnection.Open();

                SqlCommand command = new SqlCommand(sqlInsertOrDelete, m_dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                try
                {
                    if (m_dbConnection != null)
                    {
                        m_dbConnection.Close();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// Query select
        /// </summary>
        /// <param name="sqlSelect">The SQL select.</param>
        /// <returns></returns>
        public DataTable Select(string sqlSelect)
        {
            SqlConnection m_dbConnection = null;

            try
            {
                m_dbConnection = new SqlConnection(connectionString);
                m_dbConnection.Open();

                SqlCommand command = new SqlCommand(sqlSelect, m_dbConnection);
                SqlDataReader dataReader = command.ExecuteReader();

                DataTable tableToReturn = new DataTable();
                tableToReturn.Load(dataReader);

                return tableToReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                try
                {
                    if (m_dbConnection != null)
                    {
                        m_dbConnection.Close();
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
