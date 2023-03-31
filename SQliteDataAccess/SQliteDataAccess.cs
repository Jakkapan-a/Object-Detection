using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Object_Detection.SQliteDataAccess
{
    public class SQliteDataAccess
    {
        public static List<T> GetAll<T>(string tableName, int limit = 100)
        {
            var sql = $"SELECT * FROM {tableName} ORDER BY id DESC LIMIT @Limit";
            var parameters = new { Limit = limit };
            return ExecuteQuery<T>(sql, parameters);
        }

        public static List<T> GetRow<T>(string sql)
        {
            return ExecuteQuery<T>(sql);
        }

        public static void Execute(string sql, Dictionary<string, object>? parameters = null)
        {
            try
            {
                using (IDbConnection con = new SQLiteConnection(LoadConnectionString()))
                {
                    con.Execute(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return "Data Source=" + System.IO.Directory.GetCurrentDirectory() + "\\" + ConfigurationManager.ConnectionStrings[id];
        }

        public static string GetDateTimeNow()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static List<T> Query<T>(string sql, Dictionary<string, object>? parameters = null) => ExecuteQuery<T>(sql, parameters);

        public static bool IsExist(string sql)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query(sql, new DynamicParameters());
                    return output.ToList().Count > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static List<T> ExecuteQuery<T>(string sql, object parameters = null)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    return cnn.Query<T>(sql, parameters).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }
    }

}
