using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Battlefield : MonoBehaviour
{
    public void Init()
    {
        GameObject prefab = Resources.Load<GameObject>("Assets/BfTile");
        GameObject parent = GameObject.Find("BfTiles");
        for (int y = -3; y <= 3; y++)
        {
            for (int x = -7; x <= 7; x++)
            {
                if (Mathf.Abs(x % 2) == Mathf.Abs(y % 2))
                {
                    if (Mathf.Abs(x) < 7 - Mathf.Abs(y))
                    {
                        GameObject bfTile = Instantiate(prefab, new Vector3(x, y), new Quaternion(0, 0, 0, 0), parent.transform);
                    }
                }
            }
        }
    }

    public void TileClicked()
    {
        Scene scene = new Scene();
        scene.LoadScene(Scene.SceneName.Dungeon);
    }
}
