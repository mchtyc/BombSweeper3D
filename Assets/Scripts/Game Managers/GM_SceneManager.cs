using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes { MenuScene, GameScene } // Sahnelerin hepsi belirlenince sıralanacak..!!

public class GM_SceneManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene((int)Scenes.GameScene);
    }
}
