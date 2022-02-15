using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WinSqlTest
{
    class MySqlDBhelper
    {
        private static MySqlConnection connection = null;
        private static MySqlDataReader mysqlread = null;
        private static String connectionString = "";

        /// <summary>
        /// 查询语句注值
        /// </summary>
        /// <param name="sql">原始语句</param>
        /// <param name="list">需要注值</param>
        /// <returns>完整语句</returns>
        public static String SqlInject(String sql, List<Object> list)
        {
            MatchCollection match = Regex.Matches(sql, "\\?+");
            if (list == null)
            {
                return sql;
            }
            if (list.Count != match.Count)
            {
                throw new ExecutionEngineException("注值数量不匹配!!!");
            }
            if (match.Count > 0)
            {
                for (int i = 0, len = match.Count; i < len; i++)
                {
                    if (list[i].GetType().ToString().Equals("System.String"))
                    {
                        sql = sql.Substring(0, sql.IndexOf("?")) + "'" + list[i].ToString() + "'" + sql.Substring(sql.IndexOf("?") + 1);
                    }
                    else if (list[i].GetType().ToString().Equals("System.Int16"))
                    {
                        sql = sql.Substring(0, sql.IndexOf("?")) + (Int16)list[i] + sql.Substring(sql.IndexOf("?") + 1);
                    }
                    else if (list[i].GetType().ToString().Equals("System.Int32"))
                    {
                        sql = sql.Substring(0, sql.IndexOf("?")) + (Int32)list[i] + sql.Substring(sql.IndexOf("?") + 1);
                    }
                    else if (list[i].GetType().ToString().Equals("System.Int64"))
                    {
                        sql = sql.Substring(0, sql.IndexOf("?")) + (Int64)list[i] + sql.Substring(sql.IndexOf("?") + 1);
                    }
                    else
                    {
                        throw new ExecutionEngineException("不支持此类值的注入!!!");
                    }
                }
            }
            else
            {
                return sql;
            }
            Console.Write(":-->" + sql + "\n");
            return sql;
        }

        /// <summary>
        /// 数据删除操作
        /// </summary>
        /// <param name="delete"></param>
        /// <param name="list">需要注值</param>
        /// <returns></returns>
        public static int MySqlDelete(String delete, List<Object> list)
        {
            delete = SqlInject(delete, list);
            connection = GetMySqlConnection();
            MySqlCommand command = new MySqlCommand(delete, connection);
            int result = command.ExecuteNonQuery();
            CloseAll(connection, mysqlread);
            return result;
        }

        /// 数据插入操作
        /// </summary>
        /// <param name="insert">插入语句</param>
        /// <param name="list">需要注值</param>
        /// <returns></returns>
        public static int MySqlInsert(String insert, List<Object> list)
        {
            insert = SqlInject(insert, list);
            connection = GetMySqlConnection();
            MySqlCommand command = new MySqlCommand(insert, connection);
            int result = command.ExecuteNonQuery();
            CloseAll(connection, mysqlread);
            return result;
        }

        /// <summary>
        /// 数据更新操作
        /// </summary>
        /// <param name="update">更新语句</param>
        /// <returns></returns>
        public static int MySqlUpdate(String update, List<Object> list)
        {
            update = SqlInject(update, list);
            connection = GetMySqlConnection();
            MySqlCommand command = new MySqlCommand(update, connection);
            int result = command.ExecuteNonQuery();
            CloseAll(connection, mysqlread);
            return result;
        }


        /// <summary>
        /// 数据查询操作
        /// </summary>
        /// <param name="select">查询语句</param>
        /// <param name="list">需要注值</param>
        /// <returns>查询结果</returns>
        public static List<Dictionary<String, Object>> MySqlFind(String select, List<Object> lists)
        {
            select = SqlInject(select, lists);
            connection = GetMySqlConnection();
            MySqlCommand command = new MySqlCommand(select, connection);
            mysqlread = command.ExecuteReader(CommandBehavior.Default);
            List<Dictionary<String, Object>> list = new List<Dictionary<string, object>>();
            Dictionary<String, Object> dictionary = null;
            while (mysqlread.Read())
            {
                dictionary = new Dictionary<string, object>();
                for (int i = 0, len = mysqlread.FieldCount; i < len; i++)
                {
                    if (mysqlread[i].GetType().ToString().Equals("System.String"))
                    {
                        dictionary.Add(mysqlread.GetName(i), mysqlread[i].ToString());
                    }
                    else if (mysqlread[i].GetType().ToString().Equals("System.Char"))
                    {
                        dictionary.Add(mysqlread.GetName(i), (Char)mysqlread[i]);
                    }
                    else if (mysqlread[i].GetType().ToString().Equals("System.Sbyte"))
                    {
                        dictionary.Add(mysqlread.GetName(i), (SByte)mysqlread[i]);
                    }
                    else if (mysqlread[i].GetType().ToString().Equals("System.Int16"))
                    {
                        dictionary.Add(mysqlread.GetName(i), (Int16)mysqlread[i]);
                    }
                    else if (mysqlread[i].GetType().ToString().Equals("System.Int32"))
                    {
                        dictionary.Add(mysqlread.GetName(i), (Int32)mysqlread[i]);
                    }
                    else if (mysqlread[i].GetType().ToString().Equals("System.Int64"))
                    {
                        dictionary.Add(mysqlread.GetName(i), (Int64)mysqlread[i]);
                    }
                }
                list.Add(dictionary);
            }
            CloseAll(connection, mysqlread);
            return list;
        }

        /// <summary>
        /// 关闭所有
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="mysqlread"></param>
        private static void CloseAll(MySqlConnection connection, MySqlDataReader mysqlread)
        {
            if (connection != null)
            {
                try
                {
                    connection.Close();
                }
                catch (Exception e)
                {

                }
            }
            if (mysqlread != null)
            {
                try
                {
                    mysqlread.Close();
                }
                catch (Exception e)
                {

                }
            }
        }

        /// <summary>
        /// 获取数据库连接信息
        /// </summary>
        /// <returns>连接信息</returns>
        private static String GetConnectionInfo()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                //根据自己电脑的实际情况更改连接属性
                return "server=localhost;user id=root;password=admin;database=rfid";
            }
            else
            {
                return connectionString;
            }

            //FileStream file = null;
            //StreamReader reader = null;
            //StreamWriter write = null;
            //if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "config.txt"))
            //{
            //    //Directory.CreateDirectory("G:\\MySqlDataBase");
            //    File.CreateText("config.txt");
            //    file = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "config.txt", FileMode.Create);
            //    write = new StreamWriter(file);
            //    write.WriteLine("server=localhost;user id=root;password=1234;database=myspace");
            //    write.Flush();
            //    write.Close();
            //    CloseFileOperation(file, reader, write);
            //    return "server=localhost;user id=root;password=1234;database=myspace";
            //}
            //else
            //{
            //    file = new FileStream("G:\\MySqlDataBase\\config.txt", FileMode.Open);
            //    reader = new StreamReader(file);
            //    String config = "";
            //    while (reader.ReadLine() != null)
            //    {
            //        config = reader.ReadLine().ToString();
            //    }
            //    if ("".Equals(""))
            //    {
            //        throw new Exception("文件配置错误 -->位于G:\\MySqlDataBase\\config.txt ");
            //    }
            //    CloseFileOperation(file, reader, write);
            //    return config;
            //}
        }

        /// <summary>
        /// 关闭文件操作
        /// </summary>
        /// <param name="file">文件流</param>
        /// <param name="reader">文件读取流</param>
        /// <param name="write">文件写入流</param>
        private static void CloseFileOperation(FileStream file, StreamReader reader, StreamWriter write)
        {
            if (write != null)
            {
                write.Close();
            }
            if (file != null)
            {
                file.Close();
            }
            if (reader != null)
            {
                reader.Close();
            }
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns>据库连接</returns>
        private static MySqlConnection GetMySqlConnection()
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                String config = GetConnectionInfo();
                connection = new MySqlConnection(config);
                connection.Open();
                return connection;
            }
            return connection;
        }


        #region 存储过程
        /// <summary>
        ///         利用存储过程 返回受影响行数  添加  删除  修改
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="procName"></param>
        /// <returns></returns>
        public static int ProcProcExecuteNonQuery(CommandType commType,string procName, MySqlParameter[] parm=null)
        {
            using (MySqlConnection conn=new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(procName);
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandType = commType;
                if (parm!=null )
                {
                    cmd.Parameters.AddRange(parm);
                }
                int i = cmd.ExecuteNonQuery();
                return i;
            }
            

        }

        /// <summary>
        ///         利用存储过程,返回一行一列
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static object ProcExecuteScalar(CommandType commType, string procName, MySqlParameter[] parm = null)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(procName);
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandType = commType;
                if (parm != null)
                {
                    cmd.Parameters.AddRange(parm);
                }
                object  obj = cmd.ExecuteScalar();
                return obj;
            }
        }

        /// <summary> 
        ///         利用存储过程,获取数据表  查询  显示
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="parm"></param>
        /// <returns></returns>
        public static DataTable ProcDataAdapter(CommandType commType, string procName, MySqlParameter[] parm = null)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                DataTable dt = new DataTable("com");
                MySqlCommand cmd = new MySqlCommand(procName);
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandType = commType;
                if (parm != null)
                {
                    cmd.Parameters.AddRange(parm);
                }
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
    }
}
