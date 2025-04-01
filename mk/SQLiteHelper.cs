using System;
using System.Data;
using System.Data.SQLite;

public class SQLiteHelper
{
    private string connectionString = "Data Source=MyDatabase.sqlite;Version=3;";

    public SQLiteHelper()
    {
        if (!System.IO.File.Exists("MyDatabase.sqlite"))
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = @"CREATE TABLE Customers (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Name TEXT NOT NULL,
                                Email TEXT,
                                Phone TEXT)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    public DataTable GetData(string sql)
    {
        DataTable dt = new DataTable();

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (var command = new SQLiteCommand(sql, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
        }

        return dt;
    }

    public int ExecuteNonQuery(string sql)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (var command = new SQLiteCommand(sql, connection))
            {
                return command.ExecuteNonQuery();
            }
        }
    }
}