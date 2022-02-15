using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace WinSqlTest
{
    class DBHelp
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["MySqlDBConnect"].ToString();
        private static MySqlConnection mySqlConnection = null;
        private static MySqlCommand mySqlCommand = null;
        private static MySqlDataReader mySqlDataReader = null;

        private static MySqlDataAdapter mySqlDataAdapter = null;
        private static DataSet dataSet = null;

        private static int i = 0;

        public static MySqlConnection ExecuteMySqlConnection()
        {
            try
            {
                if (mySqlConnection == null || mySqlConnection.State != ConnectionState.Open)
                {
                    mySqlConnection = new MySqlConnection(connString);
                    mySqlConnection.Open();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return mySqlConnection;
        }

        private static MySqlCommand ExecuteMySqlCommand(string sql, CommandType commandType, MySqlParameter[] mySqlParameter)
        {
            try
            {
                mySqlConnection = ExecuteMySqlConnection();
                mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                if (mySqlParameter != null && mySqlParameter.Length > 0)
                {
                    mySqlCommand.Parameters.AddRange(mySqlParameter);
                }
                mySqlCommand.CommandType = commandType;
            }
            catch (Exception)
            {

                throw;
            }
            return mySqlCommand;
        }

        protected static MySqlDataReader ExecuteMySqlDataReader(string sql)
        {
            return ExecuteMySqlDataReader(sql, CommandType.Text, null);
        }
        protected static MySqlDataReader ExecuteMySqlDataReader(string sql, CommandType commandType, MySqlParameter[] mySqlParameter)
        {
            try
            {
                mySqlCommand = ExecuteMySqlCommand(sql, commandType, mySqlParameter);
                mySqlDataReader = mySqlCommand.ExecuteReader();
            }
            catch (Exception)
            {

                throw;
            }
            return mySqlDataReader;
        }

        public static DataTable ExecuteDataTable(string sql)
        {
            return ExecuteDataTable(sql, CommandType.Text, null);
        }
        public static DataTable ExecuteDataTable(string sql, CommandType commandType, MySqlParameter[] mySqlParameter)
        {
            dataSet = new DataSet();
            try
            {
                mySqlCommand = ExecuteMySqlCommand(sql, commandType, mySqlParameter);
                mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static int ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, CommandType.Text, null);
        }
        public static int ExecuteScalar(string sql, CommandType commandType, MySqlParameter[] mySqlParameter)
        {
            try
            {
                mySqlCommand = ExecuteMySqlCommand(sql, commandType, mySqlParameter);
                i = int.Parse(mySqlCommand.ExecuteScalar().ToString());
            }
            catch (Exception)
            {
                throw;
            }
            return i;
        }

        public static int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, CommandType.Text, null);
        }
        public static int ExecuteNonQuery(string sql, CommandType commandType, MySqlParameter[] mySqlParameter)
        {
            try
            {
                mySqlCommand = ExecuteMySqlCommand(sql, commandType, mySqlParameter);
                i = mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public static void CloseConnection(MySqlConnection mySqlConnection)
        {
            try
            {
                if (mySqlConnection != null)
                {
                    mySqlConnection = null;
                    mySqlConnection.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void CloseDataReader(MySqlDataReader mySqlDataReader)
        {
            try
            {
                if (mySqlDataReader != null)
                {
                    mySqlDataReader = null;
                    mySqlDataReader.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
