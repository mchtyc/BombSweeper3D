using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBtn : MonoBehaviour
{
    public GameData gameData;
    public Text levelText;
    public Button _button;
    public GameObject star1, star2, star3, middleLight;

    MM_Events mm_Events;
    int level, starCount;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = level.ToString();
        levelText.gameObject.SetActive(true);
        middleLight.SetActive(true);
        SetStars();

        _button.onClick.AddListener(delegate { OnClickLevelBtn(); });
    }

    public void InitialDatas(int _level, int _starCount, MM_Events events)
    {
        level = _level;
        starCount = _starCount;
        mm_Events = events;
    }

    void SetStars()
    {
        if(starCount == 3)
        {
            star3.SetActive(true);
        }
        if (starCount >= 2)
        {
            star2.SetActive(true);
        }
        if (starCount >= 1)
        {
            star1.SetActive(true);
        }
    }

    public void Deactivate()
    {
        gameObject.GetComponent<Button>().interactable = false;
        this.enabled = false;
    }

    void OnClickLevelBtn()
    {
        gameData.selectedLevel = level;

        //MM_Enums.SetMenuPage(MenuPage.WorldPage);   // TODO: Cubic leri silince burası levelPage de kalmalı ve 
        mm_Events.CallEventOpenGame();                // oyun oynanıp geri gelince burası direk açılmalı
    }
}
