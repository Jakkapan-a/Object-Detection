using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Detection.SQliteDataAccess
{
    public class Module
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string path { get; set; }
        public int status { get; set; } = 0;
        public string created_at { get; set; }
        public string updated_at { get; set; }


        public Module()
        {
            // SQL Create Table Module
            // CREATE TABLE IF NOT EXISTS `module` (
                string sql = @"CREATE TABLE 'module' 
                        ('id'INTEGER NOT NULL,
                            'name'	TEXT,
                            'description'	TEXT,
                            'path'	TEXT,
                            'status'	INTEGER,
                            'created_at'	TEXT,
                            'updated_at'	TEXT,
                            PRIMARY KEY('id' AUTOINCREMENT));";

            // SQL Insert Module
            SQliteDataAccess.Execute(sql);
        }

        public void Save(){
            string sql = @"INSERT INTO module (name, description, path, status, created_at, updated_at) VALUES (@name, @description, @path, @status, @created_at, @updated_at)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", name);
            parameters.Add("@description", description);
            parameters.Add("@path", path);
            parameters.Add("@status", status);
            parameters.Add("@created_at", SQliteDataAccess.GetDateTimeNow());
            parameters.Add("@updated_at", SQliteDataAccess.GetDateTimeNow());
            SQliteDataAccess.Execute(sql, parameters);
        }

        public void Update(){
            string sql = @"UPDATE module SET name = @name, description = @description, path = @path, status = @status, created_at = @created_at, updated_at = @updated_at WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@name", name);
            parameters.Add("@description", description);
            parameters.Add("@path", path);
            parameters.Add("@status", status);
            parameters.Add("@updated_at", SQliteDataAccess.GetDateTimeNow());
            SQliteDataAccess.Execute(sql, parameters);
        }

        public void Delete(){
            string sql = @"DELETE FROM module WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            SQliteDataAccess.Execute(sql, parameters);
        }


        public static List<Module> Get(){
            string sql = @"SELECT * FROM module";
            return SQliteDataAccess.GetAll<Module>(sql);
        }

        public static List<Module> Get(int id)
        {
            string sql = @"SELECT * FROM module WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return SQliteDataAccess.Query<Module>(sql, parameters);
        }

        public static List<Module> Get(string name)
        {
            string sql = @"SELECT * FROM module WHERE name = @name";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", name);
            return SQliteDataAccess.Query<Module>(sql, parameters);
        }

        public static List<Module> Get(string name, string path)
        {
            string sql = @"SELECT * FROM module WHERE name = @name AND path = @path";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", name);
            parameters.Add("@path", path);
            return SQliteDataAccess.Query<Module>(sql, parameters);
        }

        public static List<Module> Get(string name, string path, int status)
        {
            string sql = @"SELECT * FROM module WHERE name = @name AND path = @path AND status = @status";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", name);
            parameters.Add("@path", path);
            parameters.Add("@status", status);
            return SQliteDataAccess.Query<Module>(sql, parameters);
        }
    }
}
