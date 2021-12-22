using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dungeon : MonoBehaviour
{
    public enum EncounterType { NA, Enemy, Boss, Bonfire, Treasure, Recruit}
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
            GameObject mapTile = Instantiate(prefab, pos, new Quaternion(0, 0, 0, 0), parent.transform);
            mapTile.name = $"MapTile{i}";
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

            mapTile.GetComponent<Image>().sprite = Resources.Load<Sprite>($"MapIcons/{encounterType}");
            int index = i;
            mapTile.GetComponent<Button>().onClick.AddListener(() => ClickTile(index, encounterType));
        }
    }

    public void ClickTile(int i, EncounterType encounterType)
    {
        if (i == Explorer.position + 1)
        {
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
