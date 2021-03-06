using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject levelsPage, cover;
    public Transform Cubics;
    public MM_Events MM_Events;
    public TextMeshProUGUI worldNameText;

    public GameData gameData;
    public Database gameDatabase;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1f;
        MM_Enums.SetMenuPage(MenuPage.WorldPage);
        levelsPage.SetActive(false);
        cover.SetActive(true);

        InstantiateWorlds();

        cover.SetActive(false);
    }

    private void OnEnable()
    {
        MM_Events.EventWorldOnFocus += WriteWorldName;
        MM_Events.EventWorldUnfocus += UnfocusWorld;
        MM_Events.EventOpenGame += LoadData;
    }

    private void OnDisable()
    {
        MM_Events.EventWorldOnFocus -= WriteWorldName;
        MM_Events.EventWorldUnfocus -= UnfocusWorld;
        MM_Events.EventOpenGame -= LoadData;
    }

    void InstantiateWorlds()
    {
        int index = 0;

        foreach (World world in gameDatabase.Worlds)
        {
            Transform parent = Cubics.GetChild(index);
            if (gameData.GetLastOpenedWorld() > index)
            {
                Cubic cubic = Instantiate(world.MenuPrefabOpened, parent).GetComponent<Cubic>();
                cubic.InitData(world.ID);
            }
            else
            {
                GameObject closed = Instantiate(world.MenuPrefabClosed, parent);
                closed.transform.localScale = new Vector3(3f, 3f, 3f);
            }
            index++;
        }
        
        // Translate cubics to last opened or selected world so it will be in front of the camera
        TranslateCubic(gameData.GetLastOpenedWorld());
        WriteWorldName(gameData.GetLastOpenedWorld());
    }

    public void TranslateCubic(int selectedWorld)
    {
        Cubics.position = new Vector3(-20f * (float)(selectedWorld - 1), 0f, 0f);
    }

    public void WriteWorldName(int selectedWorld)
    {
        worldNameText.transform.parent.gameObject.SetActive(false);
        worldNameText.text = selectedWorld + ". " + gameDatabase.Worlds[selectedWorld - 1].WorldName;
        worldNameText.transform.parent.gameObject.SetActive(true);
    }

    public void UnfocusWorld()
    {
        //worldNameText.transform.parent.gameObject.SetActive(false);
        worldNameText.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("worldNameOut");
    }

    public void LoadData()
    {
        World world = gameDatabase.Worlds[gameData.selectedWorld - 1];
        Level level = world.Levels[gameData.selectedLevel - 1];

        gameData.gamePrefab = world.GamePrefab;
        gameData.targetSprite = level.TargetSprite;
        gameData.duration = level.Duration;
        gameData.stamina = level.Stamina;
        gameData.targetCount = level.TargetCount;
    }
}
