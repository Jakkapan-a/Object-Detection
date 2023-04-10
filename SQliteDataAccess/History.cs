using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Detection.SQliteDataAccess
{
    public class History
    {
        public int id { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public string image_path_master { get; set; }
        public string image_path_result { get; set; }
        public string result { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public History(){
            string sql = @"CREATE TABLE IF NOT EXISTS history (
	                    id	INTEGER NOT NULL,
	                    name	TEXT,
	                    model	TEXT,
	                    image_path_master	TEXT,
	                    image_path_result	TEXT,
	                    result	TEXT,
	                    created_at	TEXT,
	                    updated_at	TEXT,
	                    PRIMARY KEY(id AUTOINCREMENT)
                    )";
            SQliteDataAccess.Execute(sql, null);
        }

        public void Save(){
            string sql = @"INSERT INTO history (name, model, image_path_master, image_path_result, result, created_at, updated_at) VALUES (@name, @model, @image_path_master, @image_path_result, @result, @created_at, @updated_at)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", name);
            parameters.Add("@model", model);
            parameters.Add("@image_path_master", image_path_master);
            parameters.Add("@image_path_result", image_path_result);
            parameters.Add("@result", result);
            parameters.Add("@created_at", SQliteDataAccess.GetDateTimeNow());
            parameters.Add("@updated_at", SQliteDataAccess.GetDateTimeNow());
            SQliteDataAccess.Execute(sql, parameters);
        }

        public void Update(){
            string sql = @"UPDATE history SET name = @name, model = @model, image_path_master = @image_path_master, image_path_result = @image_path_result, result = @result, updated_at = @updated_at WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", name);
            parameters.Add("@model", model);
            parameters.Add("@image_path_master", image_path_master);
            parameters.Add("@image_path_result", image_path_result);
            parameters.Add("@result", result);
            parameters.Add("@updated_at", SQliteDataAccess.GetDateTimeNow());
            parameters.Add("@id", id);
            SQliteDataAccess.Execute(sql, parameters);
        }

        public void Delete(){
            string sql = @"DELETE FROM history WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            SQliteDataAccess.Execute(sql, parameters);
        }

        public static List<History> Get(){
            string sql = @"SELECT * FROM history ORDER BY id DESC LIMIT 20";
            return SQliteDataAccess.Query<History>(sql);
        }

        public static List<History> Get(int id){
            string sql = @"SELECT * FROM history WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return SQliteDataAccess.Query<History>(sql, parameters);
        }
        public static List<History> GetByDate(string date){
            string sql = @"SELECT * FROM history WHERE created_at LIKE '%"+date+"%' ORDER BY id DESC LIMIT 20";
            return SQliteDataAccess.Query<History>(sql);
        }

        public static List<History> GetByDateAndResult(string date, string result){
            string sql = @"SELECT * FROM history WHERE created_at LIKE '%"+date+"%' AND result LIKE '%"+result+"%' ORDER BY id DESC LIMIT 20";
            return SQliteDataAccess.Query<History>(sql);
        }

        public static List<History> GetByResult(string result){
            string sql = @"SELECT * FROM history WHERE result LIKE '%"+result+"%' ORDER BY id DESC LIMIT 20";
            return SQliteDataAccess.Query<History>(sql);
        }
    }
}
