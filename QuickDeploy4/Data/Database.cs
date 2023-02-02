using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

using QuickDeploy4.UI.Windows;

namespace QuickDeploy4.Data
{
    public class Database
    {

        static Database instance;
        public static Database Instance => instance ??= new();

        /// <summary>
        /// The SQL command to create the main deployments table.
        /// </summary>
        public const string sqlCreateDeploymentTable = "CREATE TABLE IF NOT EXISTS \"Deployments\" (\r\n\t\"Id\"\tINTEGER NOT NULL UNIQUE,\r\n\t\"Name\"\tTEXT NOT NULL,\r\n\t\"Description\"\tTEXT NOT NULL,\r\n\t\"BuildCounter\"\tINTEGER NOT NULL DEFAULT 0,\r\n\t\"RecursiveDirectoryCopying\"\tINTEGER NOT NULL DEFAULT 1,\r\n\t\"SourceDirectory\"\tTEXT NOT NULL,\r\n\t\"DestinationDirectory\"\tTEXT NOT NULL,\r\n\tPRIMARY KEY(\"Id\" AUTOINCREMENT)\r\n)";
        /// <summary>
        /// The SQL command to create the deployment targets table.
        /// </summary>
        public const string sqlCreateDeploymentTargetTable = "CREATE TABLE IF NOT EXISTS \"DeploymentTargets\" (\r\n\t\"Id\"\tINTEGER NOT NULL UNIQUE,\r\n\t\"DeploymentId\"\tINTEGER NOT NULL,\r\n\t\"Type\"\tINTEGER NOT NULL,\r\n\t\"ResourceName\"\tTEXT NOT NULL,\r\n\tPRIMARY KEY(\"Id\" AUTOINCREMENT)\r\n)";

        /// <summary>
        /// The name of the file to create the database in.
        /// </summary>
        public const string DatabaseName = "qdmaintable.db";


        /// <summary>
        /// Returns a simple connection string for the database, given the <see cref="DatabaseName"/>.
        /// </summary>
        public string GetConnectionString()
        {
            return $"Data Source={DatabaseName};Version=3";
        }

        /// <summary>
        /// A quick method to return a <see cref="SQLiteConnection"/> for the <see cref="DatabaseName"/> file.
        /// </summary>
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(GetConnectionString());
        }

        /// <summary>
        /// Called upon application startup, this method makes sure everything is in check with the database before loading deployments.
        /// </summary>
        public async void EnsureDeploymentTable()
        {
            WorkingDialog.Instance.CrsThrdShow();
            WorkingDialog.Instance.TaskUpdate("Checking database files...");

            if (!File.Exists(DatabaseName))
            {
                WorkingDialog.Instance.TaskUpdate("Creating database files & corresponding table(s)...");

                SQLiteConnection.CreateFile(DatabaseName);
            }

            using (var db = new SQLiteConnection(GetConnectionString()))
            {
                WorkingDialog.Instance.TaskUpdate("Ensuring main table...");
                db.Execute(sqlCreateDeploymentTable);
            }

            using (var db = new SQLiteConnection(GetConnection()))
            {
                WorkingDialog.Instance.TaskUpdate("Ensuring targets table...");
                db.Execute(sqlCreateDeploymentTargetTable);
            }

            WorkingDialog.Instance.TaskUpdate("Finalizing database...");
            await Task.Delay(2000);
            WorkingDialog.Instance.CrsThrdHide();
        }

    }
}
