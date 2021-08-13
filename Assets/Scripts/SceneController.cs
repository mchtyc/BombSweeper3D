using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes { MenuScene, GameScene } // Sahnelerin hepsi belirlenince sýralanacak..!!

public class SceneController : MonoBehaviour
{
    public GameObject loadingPanel;

    protected void LoadScene(int buildIndex)
    {
        OpenLoadingPanel();

        StartCoroutine(Loding(buildIndex));
    }

    protected void LoadScene(string sceneName)
    {
        OpenLoadingPanel();

        StartCoroutine(Loading(sceneName));
    }

    IEnumerator Loding(int index)
    {
        yield return null;
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);

        yield return new WaitForSeconds(1.5f);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator Loading(string name)
    {
        yield return null;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    void OpenLoadingPanel()
    {
        Instantiate(loadingPanel, FindObjectOfType<Canvas>().transform);
    }
}
