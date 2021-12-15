using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explorer : MonoBehaviour
{
    public void Start()
    {
        CreateExplorer();
    }

    private void CreateExplorer()
    {
        GameObject prefab = Resources.Load<GameObject>("Assets/Explorer");
        GameObject parent = GameObject.Find("CanvasDungeon");
        Vector3 pos = new Vector3(3, -2);
        GameObject explorer = Instantiate(prefab, pos, new Quaternion(0, 0, 0, 0), parent.transform);
        explorer.GetComponent<Image>().sprite = Resources.Load<Sprite>("MapIcons/Explorer");
    }
}
