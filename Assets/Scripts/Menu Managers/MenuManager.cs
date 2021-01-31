using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject levelsPage, cover;
    public Transform Cubics;
    public MM_Events MM_Events;
    public TextMesh worldNameText;

    public GameData gameData;
    public Database gameDatabase;

    // Start is called before the first frame update
    void Awake()
    {
        levelsPage.SetActive(false);
        cover.SetActive(true);

        InstantiateWorlds();

        cover.SetActive(false);
    }

    private void OnEnable()
    {
        MM_Events.EventSelectedWorld += WriteWorldName;
        MM_Events.EventOpenGame += LoadData;
    }

    private void OnDisable()
    {
        MM_Events.EventSelectedWorld -= WriteWorldName;
        MM_Events.EventOpenGame -= LoadData;
    }

    void InstantiateWorlds()
    {
        int i = 0;

        foreach (World world in gameDatabase.Worlds)
        {
            Transform parent = Cubics.GetChild(i);
            if (gameData.lastOpenedWorld > i)
            {
                Cubic cubic = Instantiate(world.MenuPrefabOpened, parent).GetComponent<Cubic>();
                cubic.InitData(world.ID, world.Levels.Length, true);
            }
            else
            {
                GameObject closed = Instantiate(world.MenuPrefabClosed, parent);
                closed.transform.localScale = new Vector3(3f, 3f, 3f);
            }
            i++;
        }
        // Translate cubics to last opened or selected world so it will be in front of the camera
        TranslateCubic(gameData.selectedWorld);
        WriteWorldName(gameData.selectedWorld);
    }

    public void TranslateCubic(int selectedWorldId)
    {
        Cubics.position = new Vector3(-20f * (float)(selectedWorldId - 1), 0f, 0f);
    }

    public void WriteWorldName(int selectedWorldId)
    {
        worldNameText.text = selectedWorldId + ". " + gameDatabase.Worlds[selectedWorldId - 1].WorldName;
    }

    public void LoadData()
    {
        World world = gameDatabase.Worlds[gameData.selectedWorld - 1];
        Level level = world.Levels[gameData.selectedLevel];

        gameData.gamePrefab = world.GamePrefab;
        gameData.targetSprite = level.TargetSprite;
        gameData.duration = level.Duration;
        gameData.stamina = level.Stamina;
        gameData.targetCount = level.TargetCount;
    }
}
