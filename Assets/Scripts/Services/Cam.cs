using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cam : MonoBehaviour
{
    public void Dungeon()
    {
        GameObject cam = GameObject.Find("Main Camera");
        Vector3 canvasPos = GameObject.Find("Explorer").transform.position;
        cam.transform.position = new Vector3(canvasPos.x, canvasPos.y, -10);
    }

    public void Battlefield()
    {
        GameObject cam = GameObject.Find("Main Camera");
        Vector3 canvasPos = GameObject.Find("CanvasBattlefield").transform.position;
        cam.transform.position = new Vector3(canvasPos.x, canvasPos.y, -10);
    }

    public void Encounter()
    {
        GameObject cam = GameObject.Find("Main Camera");
        Vector3 canvasPos = GameObject.Find("CanvasEncounter").transform.position;
        cam.transform.position = new Vector3(canvasPos.x, canvasPos.y, -10);
    }
}
