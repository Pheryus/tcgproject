using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class Database
{

    private Card[] cards = new Card[40];

    // constructor
    public Database(string path, string consult){
        IDbConnection dbconn = openDB(path);
        IDbCommand dbcmd = consultDB(dbconn, consult);
        IDataReader reader = dbcmd.ExecuteReader();
        populateCards(reader);
        closeDB(dbconn, dbcmd, reader);
    }

    //close database
    void closeDB(IDbConnection dbconn, IDbCommand dbcmd, IDataReader reader)
    {
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        reader.Close();
        reader = null;
    }

    //make connection with database
    IDbConnection openDB(string path)
    {
        //path to data
        string conn = "URI=file:" + Application.dataPath + "/Database/" + path;
        //connection with database
        IDbConnection dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        return dbconn;
    }

    //make consult 
    IDbCommand consultDB(IDbConnection dbconn, string consult)
    {
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = consult;
        return dbcmd;
    }


    public Card[] getCards()
    {
        return cards;
    }


    //algumas mudanças necessárias para o banco:
    //coluna para validação de carta, raridade, subtipo e mudança no custo para um vetor de 9 inteiros 
    void populateCards(IDataReader reader)
    {
        int size = 0;
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            if (id != 34)
            {
                string name = reader.GetString(7);
                string type = reader.GetString(12);
                string color = reader.GetString(2);
                string cost = reader.GetString(9);
                
                int armor, time, power;
                string text;

                if (reader.IsDBNull(1))
                    armor = -1;
                else
                    Int32.TryParse(reader.GetString(1), out armor);

                if (reader.IsDBNull(6))
                    time = -1;
                else
                    Int32.TryParse(reader.GetString(6), out time);


                if (reader.IsDBNull(8))
                    power = -1;
                else
                    Int32.TryParse(reader.GetString(8), out power);

                if (reader.IsDBNull(11))
                    text = "";
                else
                    text = reader.GetString(11);

                cards[size] = new Card(id, cost, armor, time, power, name, type, color, text);
                size++;
            }
        }
    }

}
