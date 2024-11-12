using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net;
using Mono.Data.Sqlite;
using UnityEngine;
using System;



public class DataBaseManager
{
private static DataBaseManager _instance;

    public static DataBaseManager Instance
    {
        get
        {
            if (_instance == null)
            {
            _instance = new DataBaseManager();
            }

            return _instance;
        }
    }


    public DataBaseManager()
    {
        //Instance = this;

        //dbConnection = new SqliteConnection(dbUri);
    }

    string dbUri = "URI=file:MyDatabase.sqlite";

    SqliteConnection dbConnection;

    public void Skibidi()
    {
        dbConnection = new SqliteConnection(dbUri);

        try
        {
            dbConnection.Open();
            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "CREATE TABLE Players (id INTEGER NOT NULL PRIMARY KEY, clicks int);";
            dbCommand.ExecuteReader();
            dbConnection.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);

            dbConnection.Close();
        }
    }

    public void AddPlayer()
    {
        dbConnection = new SqliteConnection(dbUri);

        string sql = "INSERT INTO Players (id, clicks) VALUES (@id, @clicks)";

        try
        {

            dbConnection.Open();
            //IDbCommand dbCommand = dbConnection.CreateCommand();
            var command = new SqliteCommand(sql, dbConnection);



            command.Parameters.AddWithValue("@id", 1);
            command.Parameters.AddWithValue("@clicks", 0);

            var rowInserted = command.ExecuteNonQuery();

            Debug.Log(rowInserted.ToString());

            //dbCommand.CommandText;
            //dbCommand.ExecuteReader();
            //dbConnection.Close();
        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);

            dbConnection.Close();
        }
    }
    
    public void UpdatePlayer(int uid, int clicks)
    {
        dbConnection = new SqliteConnection(dbUri);

        string sql = "UPDATE Players" +
                "SET clicks = @clicks" +
                "WHERE id = @id ";

        try
        {
            dbConnection.Open();

            SqliteCommand command = new SqliteCommand(sql, dbConnection);

            command.Parameters.AddWithValue("@id", uid);
            command.Parameters.AddWithValue("@clicks", clicks);

            var rowInserted = command.ExecuteNonQuery();

            Debug.Log(rowInserted.ToString());

            //SqliteCommand command = new(
            //    "SELECT 1 FROM Players",
            //    dbConnection);

            //SqliteDataReader reader = command.ExecuteReader();

            //if (reader.HasRows) {
            //    while (reader.Read())
            //    {
            //        Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
            //            reader.GetString(1));
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No rows found.");
            //}
            //reader.Close();

            dbConnection.Close();

        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);

            dbConnection.Close();
        }
    }
}

