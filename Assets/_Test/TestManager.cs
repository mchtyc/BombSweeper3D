using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    public Text[] texts, paths;

    string dataPath, streamingAssetsPath, persistantDataPath, temporaryCachePath;

    void Start()
    {
        dataPath = Application.dataPath;
        streamingAssetsPath = Application.streamingAssetsPath;
        persistantDataPath = Application.persistentDataPath;
        temporaryCachePath = Application.temporaryCachePath;

        WriteThePaths();
    }

    void WriteThePaths()
    {
        texts[0].text = "Application.dataPath";
        paths[0].text = dataPath;

        texts[1].text = "Application.streamingAssetsPath";
        paths[1].text = streamingAssetsPath;

        texts[2].text = "Application.persistantDataPath";
        paths[2].text = persistantDataPath;

        texts[3].text = "Application.temporaryCachePath";
        paths[3].text = temporaryCachePath;
    }
}
