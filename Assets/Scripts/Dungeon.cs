using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dungeon : MonoBehaviour
{
    public void Init()
    {
        CreateDungeon();
    }

    public void CreateDungeon()
    {
        GameObject prefab = Resources.Load<GameObject>("Assets/MapTile");
        GameObject parent = GameObject.Find("MapTiles");
        Vector3 pos = new Vector3(0, 0);
        for (int y = 0; y < 20; y++)
        {
            pos.y = y * 2;
            for (int x = 0; x < 4; x++)
            {
                pos.x = x * 2;
                GameObject tile = Instantiate(prefab, pos, new Quaternion(0, 0, 0, 0), parent.transform);
                tile.name = $"MapTile{x},{y}";
                if (y == 10)
                {
                    SetTile(tile, 5);
                }
                else if (y % 2 == 0)
                {
                    SetTile(tile, 0);
                }
                else
                {
                    SetTile(tile);
                }
            }
        }
    }

    public void SetTile(GameObject tile, int setNumber = -1)
    {
        Rng rng = new Rng();
        int number = setNumber == -1 ? rng.Range(1, 5) : setNumber;
        
        if (number == 0)
        {
            tile.GetComponent<Image>().sprite = Resources.Load<Sprite>("MapIcons/EnemyNormal");
        }
        if (number == 1 || number == 2)
        {
            tile.GetComponent<Image>().sprite = Resources.Load<Sprite>("MapIcons/Random");
        }
        if (number == 3)
        {
            tile.GetComponent<Image>().sprite = Resources.Load<Sprite>("MapIcons/EnemyElite");
        }
        if (number == 4)
        {
            tile.GetComponent<Image>().sprite = Resources.Load<Sprite>("MapIcons/Bonfire");
        }
        if (number == 5)
        {
            tile.GetComponent<Image>().sprite = Resources.Load<Sprite>("MapIcons/Treasure");
        }
    }
}
