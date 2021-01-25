using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MM_SceneManagement : MonoBehaviour
{
    public MM_Events MM_Events;

    private void OnEnable()
    {
        MM_Events.EventOpenGame += OnOpenGame;
    }

    private void OnDisable()
    {
        MM_Events.EventOpenGame -= OnOpenGame;
    }

    public void OnOpenGame()
    {
        StartCoroutine(OpenGame());
    }

    IEnumerator OpenGame()
    {
        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene((int)Scenes.GameScene);
    }
}
