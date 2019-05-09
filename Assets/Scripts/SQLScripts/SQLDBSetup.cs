using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class SQLDBSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Create database
        string connection = "URI=file:" + Application.persistentDataPath + "/" + "My_Database";

        // Open connection
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        // Create table
        IDbCommand dbcmd;
        dbcmd = dbcon.CreateCommand();
        string q_createTable =
            "CREATE TABLE IF NOT EXISTS pokemon_table (id INTEGER PRIMARY KEY, eng_name TEXT, url TEXT, ita_name TEXT, image_url TEXT, type TEXT, agilita TEXT, forza TEXT, intelligenza TEXT, spirito TEXT, vigore TEXT)";
        dbcmd.CommandText = q_createTable;
        dbcmd.ExecuteReader();

        dbcmd = dbcon.CreateCommand();
        q_createTable =
            "CREATE TABLE IF NOT EXISTS mossa_table (id INTEGER PRIMARY KEY, eng_name TEXT, url TEXT, ita_name TEXT, type TEXT)";
        dbcmd.CommandText = q_createTable;
        dbcmd.ExecuteReader();

        /*
        // Insert values in table
        IDbCommand cmnd = dbcon.CreateCommand();
        cmnd.CommandText = 
            "INSERT OR REPLACE INTO pokemon_table (id, eng_name) VALUES (-10, 'fakeMon')";
        cmnd.ExecuteNonQuery();

        // Read and print all values in table
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;
        string query = "SELECT * FROM pokemon_table";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        while (reader.Read()) {
            Debug.Log("id: " + reader[0].ToString());
            Debug.Log("eng_name: " + reader[1].ToString());
        }*/

        // Close connection
        dbcon.Close();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
