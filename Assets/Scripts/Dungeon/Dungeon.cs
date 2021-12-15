using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dungeon : MonoBehaviour
{
    public enum EncounterType { NA, EnemyNormal, Random, EnemyElite, Bonfire, Treasure, Recruit}
    public void Start()
    {
        CreateDungeon();
    }

    private void CreateDungeon()
    {
        GameObject prefab = Resources.Load<GameObject>("Assets/MapTile");
        GameObject parent = GameObject.Find("MapTiles");
        
        for (int y = 0; y < 21; y++)
        {
            if (y == 0)
            {
                int x = 3;
                Vector3 pos = new Vector3(x, y * 2);
                GameObject mapTile = Instantiate(prefab, pos, new Quaternion(0, 0, 0, 0), parent.transform);
                mapTile.name = $"MapTile{x},{y}";
                EncounterType encounterType = EncounterType.NA;
                encounterType = SetTile(mapTile, 6);
                mapTile.GetComponent<Button>().onClick.AddListener(() => ClickTile(mapTile.name, encounterType));
            }
            else
            {
                for (int x = 0; x < 4; x++)
                {
                    Vector3 pos = new Vector3(x * 2, y * 2);
                    GameObject mapTile = Instantiate(prefab, pos, new Quaternion(0, 0, 0, 0), parent.transform);
                    mapTile.name = $"MapTile{x},{y}";
                    EncounterType encounterType = EncounterType.NA;
                    if (y == 10)
                    {
                        encounterType = SetTile(mapTile, 5);
                    }
                    else if (y % 2 == 0)
                    {
                        encounterType = SetTile(mapTile, 0);
                    }
                    else
                    {
                        encounterType = SetTile(mapTile);
                    }
                    mapTile.GetComponent<Button>().onClick.AddListener(() => ClickTile(mapTile.name, encounterType));
                }
            }
        }
    }

    public EncounterType SetTile(GameObject tile, int setNumber = -1)
    {
        Rng rng = new Rng();
        int number = setNumber == -1 ? rng.Range(1, 5) : setNumber;
        
        if (number == 0)
        {
            tile.GetComponent<Image>().sprite = Resources.Load<Sprite>("MapIcons/EnemyNormal");
            return EncounterType.EnemyNormal;
        }
        if (number == 1 || number == 2)
        {
            tile.GetComponent<Image>().sprite = Resources.Load<Sprite>("MapIcons/Random");
            return EncounterType.Random;
        }
        if (number == 3)
        {
            tile.GetComponent<Image>().sprite = Resources.Load<Sprite>("MapIcons/EnemyElite");
            return EncounterType.EnemyElite;
        }
        if (number == 4)
        {
            tile.GetComponent<Image>().sprite = Resources.Load<Sprite>("MapIcons/Bonfire");
            return EncounterType.Bonfire;
        }
        if (number == 5)
        {
            tile.GetComponent<Image>().sprite = Resources.Load<Sprite>("MapIcons/Treasure");
            return EncounterType.Treasure;
        }
        if (number == 6)
        {
            tile.GetComponent<Image>().sprite = Resources.Load<Sprite>("MapIcons/Recruit");
            return EncounterType.Recruit;
        }
        return EncounterType.NA;
    }

    public void ClickTile(string name, EncounterType encounterType)
    {
        Encounter encounter = new Encounter();
        encounter.StartEncounter(encounterType);
    }
}
