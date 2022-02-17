using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Encounter : MonoBehaviour
{
    public static GameObject[] options = new GameObject[2];
    public static string[] optionTitles = new string[2];
    private void Start()
    {
        CreateEncounter();
    }
    private void CreateEncounter()
    {
        for (int i = 0; i < 2; i++)
        {
            
            GameObject prefab = Resources.Load<GameObject>("Assets/EncounterButton");
            GameObject parent = GameObject.Find("OptionButtons");
            Vector3 canvasOffset = GameObject.Find("CanvasEncounter").GetComponent<Transform>().position;

            Vector3 pos = new Vector3(canvasOffset.x - 10, canvasOffset.y + (-i * 8) + 3);
            GameObject optionBtn = Instantiate(prefab, pos, new Quaternion(0, 0, 0, 0), parent.transform);
            optionBtn.name = $"OptionButton{i}";
            options[i] = optionBtn;
        }
    }

    public void SetupEncounter(Dungeon.EncounterType encounterType)
    {
        switch(encounterType)
        {
            case Dungeon.EncounterType.Bonfire:
                break;

            case Dungeon.EncounterType.Recruit:
                Recruit recruit = new Recruit();
                recruit.SetupRecruit();
                break;

            case Dungeon.EncounterType.Treasure:
                break;
        }
    }
}
