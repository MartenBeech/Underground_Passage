using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explorer : MonoBehaviour
{
    public static GameObject explorer;
    public static int position = 0;
    public void Start()
    {
        CreateExplorer();
    }

    private void CreateExplorer()
    {
        GameObject prefab = Resources.Load<GameObject>("Assets/Explorer");
        GameObject parent = GameObject.Find("CanvasDungeon");
        Vector3 pos = new Vector3(0, 0);
        explorer = Instantiate(prefab, pos, new Quaternion(0, 0, 0, 0), parent.transform);
        explorer.GetComponent<Image>().sprite = Resources.Load<Sprite>("MapIcons/Explorer");
        explorer.name = "Explorer";

        Cam cam = new Cam();
        cam.Dungeon();
    }
}
