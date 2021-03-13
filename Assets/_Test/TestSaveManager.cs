using System.Collections;
using System.IO;
using UnityEngine;


public enum Status { Fail, Pass }

public class TestSaveManager : MonoBehaviour
{
    public TestSaveData testSave;
    public GameData gameData;

    public static TestSaveManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void Save()
    {
        string path = FindPath();
        string json = JsonUtility.ToJson(testSave);

        File.WriteAllText(path, json);
    }

    string FindPath()
    {
        bool found = false;
        string randomPath = "";

        while (!found)
        {
            float rand = Random.Range(0, 1000000);
            randomPath = Application.persistentDataPath + "/TestSave_world" + gameData.selectedWorld + "_level" + gameData.selectedLevel + "_" + rand + ".json";

            if (!File.Exists(randomPath)) 
            {
                found = true;
            }
        }

        return randomPath;
    }
}
