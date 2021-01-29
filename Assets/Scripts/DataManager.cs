using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	public static void SaveToLocal()
	{
		//BinaryFormatter bf = new BinaryFormatter();
		//FileStream file = File.Create(Application.persistentDataPath + "/gamePlatform.my");
		//bf.Serialize(file, gameDatas);
		//file.Close();
	}

	public static void LoadFromLocal()
	{
		if (File.Exists(Application.persistentDataPath + "/gamePlatform.my"))
		{
			//BinaryFormatter bf = new BinaryFormatter();
			//FileStream file = File.Open(Application.persistentDataPath + "/gamePlatform.my", FileMode.Open);
			//gameDatas = (Datas)bf.Deserialize(file);
			//file.Close();
		}
		//else
		//{
		//	//firstDataLoad();
		//}
		//if (!everRead)
		//{
		//	everRead = true;
		//}
		//openLevels();
	}

	void OnDestroy()
	{
		SaveToLocal();
	}

	//public static Datas gameDatas;
	//private const string savedGameFileName = "FB_gameDatasDeneme";
	//public static bool isWriting = false;
	//public static bool isReading = false;
	//public static bool everRead = false;
	//public ISavedGameMetadata currentGame = null;

	//// Use this for initialization
	//void Awake()
	//{
	//	if (GameObject.FindGameObjectsWithTag("Menu Manager").Length > 1)
	//	{
	//		Destroy(gameObject);
	//	}
	//	DontDestroyOnLoad(gameObject);
	//	//firstDataLoad ();
	//}

	//public static void Save()
	//{
	//	if (Social.localUser.authenticated && everRead)
	//	{
	//		isWriting = true;
	//		OpenSavedGame(savedGameFileName);
	//	}
	//	else
	//	{
	//		SaveToLocal();
	//	}
	//}

	//public static void Load()
	//{

	//	if (Social.localUser.authenticated)
	//	{
	//		isReading = true;
	//		OpenSavedGame(savedGameFileName);
	//	}
	//	else
	//	{
	//		LoadFromLocal();
	//	}
	//}

	//public static void OpenSavedGame(string filename)
	//{
	//	ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
	//	savedGameClient.OpenWithAutomaticConflictResolution(filename, DataSource.ReadCacheOrNetwork,
	//		ConflictResolutionStrategy.UseMostRecentlySaved, OnSavedGameOpened);
	//}

	//public static void OnSavedGameOpened(SavedGameRequestStatus status, ISavedGameMetadata game)
	//{
	//	if (status == SavedGameRequestStatus.Success)
	//	{
	//		// handle reading or writing of saved game.
	//		if (isWriting)
	//		{
	//			string gameDatasString = JsonUtility.ToJson(gameDatas);
	//			if (gameDatasString != "")
	//			{
	//				byte[] gameDatasByte = System.Text.Encoding.UTF8.GetBytes(gameDatasString);
	//				SaveGameData(game, gameDatasByte);
	//			}
	//			else
	//			{
	//				LoadFromLocal();
	//				Save();
	//			}
	//		}
	//		else if (isReading)
	//		{
	//			LoadGameData(game);
	//		}
	//	}
	//	else
	//	{
	//		// handle error
	//	}
	//}

	//public static void SaveGameData(ISavedGameMetadata game, byte[] savedData)
	//{
	//	ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;

	//	SavedGameMetadataUpdate.Builder builder = new SavedGameMetadataUpdate.Builder();
	//	builder = builder
	//		.WithUpdatedPlayedTime(TimeSpan.FromMinutes(game.TotalTimePlayed.Minutes + 1))
	//		.WithUpdatedDescription("Saved game at " + DateTime.Now);

	//	SavedGameMetadataUpdate updatedMetadata = builder.Build();
	//	savedGameClient.CommitUpdate(game, updatedMetadata, savedData, OnSavedGameWritten);
	//}

	//public static void OnSavedGameWritten(SavedGameRequestStatus status, ISavedGameMetadata game)
	//{
	//	if (status == SavedGameRequestStatus.Success)
	//	{
	//		// handle reading or writing of saved game.
	//		isWriting = false;
	//	}
	//	else
	//	{
	//		// handle error
	//		isWriting = false;
	//	}
	//}

	//public static void LoadGameData(ISavedGameMetadata game)
	//{
	//	ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
	//	savedGameClient.ReadBinaryData(game, OnSavedGameDataRead);
	//}

	//public static void OnSavedGameDataRead(SavedGameRequestStatus status, byte[] data)
	//{

	//	if (status == SavedGameRequestStatus.Success)
	//	{
	//		// handle processing the byte array data
	//		string gameDatasString = System.Text.Encoding.UTF8.GetString(data);

	//		if (gameDatasString != "")
	//		{
	//			gameDatas = JsonUtility.FromJson<Datas>(gameDatasString);
	//		}
	//		else
	//		{
	//			LoadFromLocal();
	//			Save();
	//		}
	//		isReading = false;
	//		if (!everRead)
	//		{
	//			everRead = true;
	//		}
	//	}
	//	else
	//	{
	//		// handle error
	//		isReading = false;
	//	}
	//	openLevels();
	//}

	//public static void sceneChange()
	//{
	//	if (SceneManager.GetActiveScene().name == "_First Scene")
	//	{
	//		SceneManager.LoadScene("Main Menu");
	//	}
	//}

	//public static void openLevels()
	//{
	//	if (SceneManager.GetActiveScene().name == "Main Menu")
	//	{
	//		GridLevelGroup gLGroup = GameObject.Find("Content").GetComponent<GridLevelGroup>();
	//		gLGroup.LevelDesign();
	//	}
	//}



	////public static void firstDataLoad()
	////{
	////	gameDatas = new Datas();
	////	gameDatas.RewardPoints = 0f;
	////	gameDatas.BallType = 1;
	////	gameDatas.LastLevel = 1;                    //Yayınlanmadan önce defaultlar değişecek
	////	gameDatas.Diamond = 100;
	////	gameDatas.Sound = true;
	////	gameDatas.AddBall = gameDatas.Quake = gameDatas.AddLaser = gameDatas.Remove = gameDatas.Unbreakable = 3; //Yayınlanmadan önce 3e düşecek
	////																											 // 0: Owned    1: watch an ad    2: buy it with actual currency    3: buy it with diamond
	////	gameDatas.BallStates = new int[16] { 0, 1, 3, 2, 1, 3, 1, 2, 2, 3, 2, 2, 2, 3, 3, 2 };
	////}

	////	public void DeleteFile(){
	////		File.Delete (Application.persistentDataPath + "/gamePlatform.my");		// Bu kod değil ama bağlı olduğu Button yayınlanmadan önce silinecek
	////	}
}
