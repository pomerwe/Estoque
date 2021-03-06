﻿using SQLite4Unity3d;
using UnityEngine;

using System.Collections;
using System.IO;

using System.Collections.Generic;

public class DataService
{

	public SQLiteConnection con;
	public bool dbExists = false;
	public bool dropCreateTablesEnabled = false;

	public DataService(string DatabaseName)
	{

#if UNITY_EDITOR
		var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
		dbExists = File.Exists(dbPath);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }
		else
		{
			dbExists = true;
		}

        var dbPath = filepath;
#endif
		con = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
		Debug.Log("Final PATH: " + dbPath);
	}

	public void CreateDB()
	{
		if(!dbExists || dropCreateTablesEnabled)
        {
			con.DropTable<Category>();
			con.CreateTable<Category>();

			con.DropTable<Item>();
			con.CreateTable<Item>();

			con.DropTable<History>();
			con.CreateTable<History>();
		}
	}

	//public IEnumerable<Person> GetPersons()
	//{
	//	return _connection.Table<Person>();
	//}

	//public IEnumerable<Person> GetPersonsNamedRoberto()
	//{
	//	return _connection.Table<Person>().Where(x => x.Name == "Roberto");
	//}

	//public Item GetItem<Item>()
	//{
	//	return _connection.Table<T>().Where(x => x.Name == "Johnny").FirstOrDefault();
	//}

	public void Delete<T>(T obj) where T : class
	{
		con.Delete(obj);
	}

	public void Update<T>(T obj) where T : class
    {
		con.Update(obj);
    }

	public T Insert<T>(T obj) where T : class
	{
		con.Insert(obj);
		return obj;
	}

	public void CloseConnection()
    {
		con.Close();
    }

	public static DataService GetDataServiceInstance()
    {
		return new DataService("storageDatabase.db");
    }
}