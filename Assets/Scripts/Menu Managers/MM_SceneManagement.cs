using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_SceneManagement : SceneController
{
    public MM_Events mm_Events;
    //public GameObject loadingPanel;
    public Transform canvas;

    private void OnEnable()
    {
        mm_Events.EventOpenGame += OnOpenGame;
    }

    private void OnDisable()
    {
        mm_Events.EventOpenGame -= OnOpenGame;
    }

    public void OnOpenGame()
    {
        LoadScene((int)Scenes.GameScene);
    }
}
