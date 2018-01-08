using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace JKLibrary
{
    // 提供执行方法
    public class SQLHelper
    {
        public static int id;
        public static string username;


        // 连接字符串
        static string connStr = "server=localhost;port=3306;User Id=root;password=123123;Database=note";
            //ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
        /// <summary>
        /// 实现非查询操作，增删改返回受影响行数，否则返回-1
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params MySqlParameter[] ps)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string sql, params MySqlParameter[] ps)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(ps);
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static MySqlDataReader ExecuteReader(string sql, params MySqlParameter[] ps)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(ps);
                    conn.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
            }
            catch (Exception ex)
            {
                conn.Dispose();
                throw ex;
            }
        }
        public static DataSet GetDataSet(string sql, params MySqlParameter[] ps)
        {
            DataSet ds = new DataSet();
            using (MySqlDataAdapter sda = new MySqlDataAdapter(sql, connStr))
            {
                if (ps != null)
                {
                    sda.SelectCommand.Parameters.AddRange(ps);
                }

                sda.Fill(ds);
            }
            return ds;
        }
    }
}
