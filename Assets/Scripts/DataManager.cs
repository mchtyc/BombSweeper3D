using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	public GameData gameData;
	string dataPath;
	public static DataManager instance; 

	void Awake()
	{
		instance = this;
		dataPath = Application.persistentDataPath + "/gameData.dat";
		LoadFromLocal();
	}

	private void OnDisable()
	{
		SaveAllGameDatas();
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
		//LoadFromLocal();
	}

	public void SaveToLocal(int id)
	{
		CubicData cubicData = DataFlow.instance.cubicDatas[id - 1];

		string filePath = Application.persistentDataPath + "/world" + cubicData.ID + ".dat";
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(filePath);
		bf.Serialize(file, cubicData);
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

	public void LoadFromLocal(int id)
	{
		string filePath = Application.persistentDataPath + "/world" + id + ".dat";

		if (File.Exists(filePath))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(filePath, FileMode.Open);
			DataFlow.instance.cubicDatas[id - 1] = (CubicData)bf.Deserialize(file);
			file.Close();
		}
		else
		{
			SaveToLocal(id);
		}
	}

	GameDataClone CloneFromGameData()
	{
		GameDataClone dataClone = new GameDataClone();

		dataClone.lastOpenedWorld = gameData.GetLastOpenedWorld();
		dataClone.boosterCount = gameData.GetBoosterCount();

		return dataClone;
	}

	void LoadFromClone(GameDataClone dataClone)
	{
		gameData.SetLastOpenedWorld(dataClone.lastOpenedWorld);
		gameData.SetBoosterCount(dataClone.boosterCount);
	}

	void SaveAllGameDatas()
	{
		SaveToLocal();

		for (int i = 1; i <= gameData.GetLastOpenedWorld(); i++)
		{
			SaveToLocal(i);
		}
	}
}
