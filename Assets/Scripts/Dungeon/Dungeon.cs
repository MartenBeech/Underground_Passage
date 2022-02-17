using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dungeon : MonoBehaviour
{
    public enum EncounterType { NA, Enemy, Boss, Bonfire, Treasure, Recruit}
    public static GameObject[] mapTiles = new GameObject[10];
    public void Start()
    {
        CreateDungeon();
    }

    private void CreateDungeon()
    {
        GameObject prefab = Resources.Load<GameObject>("Assets/MapTile");
        GameObject parent = GameObject.Find("MapTiles");
        
        for (int i = 1; i < 10; i++)
        {
            Vector3 pos = new Vector3(0, i * 2);
            mapTiles[i] = Instantiate(prefab, pos, new Quaternion(0, 0, 0, 0), parent.transform);
            mapTiles[i].name = $"MapTile{i}";
            EncounterType encounterType = EncounterType.NA;
            switch(i)
            {
                case 1:
                    encounterType = EncounterType.Recruit;
                    break;
                case 3:
                    encounterType = EncounterType.Bonfire;
                    break;
                case 5:
                    encounterType = EncounterType.Treasure;
                    break;
                case 7:
                    encounterType = EncounterType.Bonfire;
                    break;
                case 8:
                    encounterType = EncounterType.Boss;
                    break;

                default:
                    encounterType = EncounterType.Enemy;
                    break;
            }

            mapTiles[i].GetComponent<Image>().sprite = Resources.Load<Sprite>($"MapIcons/{encounterType}");
            if (i == Explorer.position + 1)
            {
                mapTiles[i].GetComponent<Image>().color = Color.HSVToRGB(120 / 360f, 0.4f, 1);
            }
            int index = i;
            mapTiles[i].GetComponent<Button>().onClick.AddListener(() => ClickTile(index, encounterType));
        }
    }

    public void ClickTile(int i, EncounterType encounterType)
    {
        if (i == Explorer.position + 1)
        {
            Explorer.position = i;
            Explorer.explorer.transform.position = mapTiles[i].transform.position;
            mapTiles[i].GetComponent<Image>().color = Color.HSVToRGB(0 / 360f, 0.6f, 1);
            mapTiles[i + 1].GetComponent<Image>().color = Color.HSVToRGB(120 / 360f, 0.4f, 1);

            Cam cam = new Cam();
            Encounter encounter = new Encounter();
            switch (encounterType)
            {
                case EncounterType.Enemy:
                    cam.Battlefield();
                    break;

                case EncounterType.Boss:
                    cam.Battlefield();
                    break;

                case EncounterType.Recruit:
                    cam.Encounter();
                    encounter.SetupEncounter(encounterType);
                    break;

                case EncounterType.Bonfire:
                    cam.Encounter();
                    encounter.SetupEncounter(encounterType);
                    break;

                case EncounterType.Treasure:
                    cam.Encounter();
                    encounter.SetupEncounter(encounterType);
                    break;
            }
        }
    }
}
