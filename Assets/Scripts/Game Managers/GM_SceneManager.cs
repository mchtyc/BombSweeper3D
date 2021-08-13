using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_SceneManager : SceneController
{
    public GameData gameData;

    public void RestartGame()
    {
        LoadScene((int)Scenes.GameScene);
    }

    public void OpenMenu()
    {
        LoadScene((int)Scenes.MenuScene);
    }

    public void OpenNextLevel()
    {
        // Burada diğer bölüm seçilecek

        LoadScene((int)Scenes.GameScene);
    }

    public void SaveAndOpenMenu()
    {
        TestSaveManager.instance.Save();
        LoadScene((int)Scenes.MenuScene);
    }
}
