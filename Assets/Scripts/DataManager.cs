using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	public GameData gameData;
	string dataPath;

	void Awake()
	{
		dataPath = Application.persistentDataPath + "/gameData.dat";
		LoadFromLocal();
	}

	public void SaveToLocal()
	{
		GameDataClone dataClone = CloneFromGameData();
		//string json = JsonUtility.ToJson(dataClone);
		//File.WriteAllText(dataPath, json);

		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(dataPath);
		bf.Serialize(file, dataClone);
		file.Close();
		LoadFromLocal();
	}

	public void SaveToLocal(CubicData data)
	{
		string filePath = Application.persistentDataPath + "/world" + data.ID + ".dat";
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(filePath);
		bf.Serialize(file, data);
		file.Close();
	}

	public void LoadFromLocal()
	{
		if (File.Exists(dataPath))
		{
			try
			{
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Open(dataPath, FileMode.Open);
				GameDataClone dataClone = (GameDataClone)bf.Deserialize(file);
				file.Close();
				LoadFromClone(dataClone);
			
				//StreamReader r = new StreamReader(dataPath);
				//string json = r.ReadToEnd();
				//r.Close();
				//GameDataClone dataClone = JsonUtility.FromJson<GameDataClone>(json);
				//LoadFromClone(dataClone);
			}
			catch
			{
				Debug.Log("Something went wrong trying to loading from local save! Deleting local file and saving initial values.");
				File.Delete(dataPath);
				SaveToLocal();
			}
			
		}
		else
		{
			SaveToLocal();
		}
	}

	public CubicData LoadFromLocal(CubicData cubicData)
	{
		string filePath = Application.persistentDataPath + "/world" + cubicData.ID + ".dat";

		if (File.Exists(filePath))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(filePath, FileMode.Open);
			cubicData = (CubicData)bf.Deserialize(file);
			file.Close();
		}
		else
		{
			SaveToLocal(cubicData);
			return cubicData;			
		}
		return cubicData;
	}

	GameDataClone CloneFromGameData()
	{
		GameDataClone dataClone = new GameDataClone();

		dataClone.lastOpenedWorld = gameData.lastOpenedWorld;
		dataClone.boosterCount = gameData.boosterCount;

		return dataClone;
	}

	void LoadFromClone(GameDataClone dataClone)
	{
		gameData.lastOpenedWorld = dataClone.lastOpenedWorld;
		gameData.boosterCount = dataClone.boosterCount;
	}		

	void OnDestroy()
	{
		//SaveToLocal();
	}
}
