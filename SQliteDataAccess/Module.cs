﻿using System;
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
        public string filename { get; set; }
        public string path_label { get; set; } // txt
        public string path { get; set; } // ONNX
        public string image { get; set; }
        public int status { get; set; } = 1;
        public string created_at { get; set; }
        public string updated_at { get; set; }


        public Module()
        {
            // SQL Create Table Module
            // CREATE TABLE IF NOT EXISTS `module` (
                string sql = @"CREATE TABLE IF NOT EXISTS 'module' 
                        ('id'INTEGER NOT NULL,
                            'name'	TEXT,
                            'description'	TEXT,
                            'filename'	TEXT,
                            'path_label'	TEXT,
                            'path'	TEXT,
                            'image'	TEXT,
                            'status'	INTEGER,
                            'created_at'	TEXT,
                            'updated_at'	TEXT,
                            PRIMARY KEY('id' AUTOINCREMENT));";

            // SQL Insert Module
            SQliteDataAccess.Execute(sql, null);
        }

        public void Save(){
            string sql = @"INSERT INTO module (name, description, filename, path_label, path, image, status, created_at, updated_at) VALUES (@name, @description, @filename, @path_label , @path, @image, @status, @created_at, @updated_at)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", name);
            parameters.Add("@description", description);
            parameters.Add("@filename", filename);
            parameters.Add("@path_label", path_label);
            parameters.Add("@path", path);
            parameters.Add("@image", image);
            parameters.Add("@status", status);
            parameters.Add("@created_at", SQliteDataAccess.GetDateTimeNow());
            parameters.Add("@updated_at", SQliteDataAccess.GetDateTimeNow());
            SQliteDataAccess.Execute(sql, parameters);
        }

        public void Update(){
            string sql = @"UPDATE module SET name = @name, description = @description, filename = @filename, path_label = @path_label, path = @path, image = @image, status = @status, updated_at = @updated_at WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@name", name);
            parameters.Add("@description", description);
            parameters.Add("@filename", filename);
            parameters.Add("@path_label", path_label);
            parameters.Add("@path", path);
            parameters.Add("@image", image);
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
            string sql = "module";
            return SQliteDataAccess.GetAll<Module>(sql);
        }

        /// <summary>
        ///  Get Module by id
        /// </summary>
        public static List<Module> Get(int id)
        {
            
            string sql = @"SELECT * FROM module WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return SQliteDataAccess.Query<Module>(sql, parameters);
        }

        /// <summary>
        ///  Get Module by name
        /// </summary>
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
