using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Battlefield : MonoBehaviour
{
    public void Start()
    {
        CreateBattlefield();
    }

    private void CreateBattlefield()
    {
        GameObject prefab = Resources.Load<GameObject>("Assets/BfTile");
        GameObject parent = GameObject.Find("BfTiles");
        Vector3 canvasOffset = GameObject.Find("CanvasBattlefield").GetComponent<Transform>().position;
        for (int y = -3; y <= 3; y++)
        {
            for (int x = -7; x <= 7; x++)
            {
                if (Mathf.Abs(x % 2) == Mathf.Abs(y % 2))
                {
                    if (Mathf.Abs(x) < 7 - Mathf.Abs(y))
                    {
                        Vector3 pos = new Vector3(canvasOffset.x + x, canvasOffset.y + y);
                        GameObject bfTile = Instantiate(prefab, pos, new Quaternion(0, 0, 0, 0), parent.transform);
                        bfTile.name = $"BfTile{x},{y}";
                        bfTile.GetComponent<Button>().onClick.AddListener(() => ClickTile(bfTile.name));
                    }
                }
            }
        }
    }

    public void ClickTile(string name)
    {
        
    }
}
