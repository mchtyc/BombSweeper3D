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
    public Worlds worlds;

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

        foreach (World w in worlds.worlds)
        {
            Transform parent = Cubics.GetChild(i);
            if (w.open)
            {
                Cubic cubic = Instantiate(w.WorldPrefab, parent).GetComponent<Cubic>();
                cubic.InitData(w.id, w.levelCount, w.open);
            }
            else
            {
                GameObject closed = Instantiate(w.closedPrefab, parent);
                closed.transform.localScale = new Vector3(3f, 3f, 3f);
            }
            i++;
        }
        // Translate cubics to last opened or selected world so it will be in front of the camera
        TranslateCubic(worlds);
    }

    public void TranslateCubic(Worlds w)
    {
        Cubics.position = new Vector3(-20f * (float)(w.selectedWorld - 1), 0f, 0f);

        WriteWorldName(w.selectedWorld);
    }

    public void WriteWorldName(int id)
    {
        worldNameText.text = id + ". " + worlds.worlds[id - 1].Name;
    }

    public void LoadData()
    {
        World w = worlds.worlds[gameData.playingWorldId - 1];
        Level l = w.levels[gameData.playingLevel];

        gameData.cubic = w.gamePrefab;
        gameData.target = l.target;
        gameData.duration = l.duration;
        gameData.stamina = l.stamina;
        gameData.targetCount = l.targetCount;
    }
}
