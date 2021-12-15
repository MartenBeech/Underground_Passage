using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Encounter : MonoBehaviour
{
    private void Start()
    {
        CreateEncounter();
    }
    private void CreateEncounter()
    {
        for (int i = 0; i < 3; i++)
        {
            
            GameObject prefab = Resources.Load<GameObject>("Assets/EncounterButton");
            GameObject parent = GameObject.Find("OptionButtons");
            Vector3 canvasOffset = GameObject.Find("CanvasEncounter").GetComponent<Transform>().position;

            Vector3 pos = new Vector3(canvasOffset.x - 5, canvasOffset.y + (-i * 5) + 5);
            GameObject optionBtn = Instantiate(prefab, pos, new Quaternion(0, 0, 0, 0), parent.transform);
            optionBtn.name = $"OptionButton{i}";
            optionBtn.GetComponent<Button>().onClick.AddListener(() => ClickOption(optionBtn.name));
        }
    }

    public void StartEncounter(Dungeon.EncounterType encounterType)
    {
        Cam cam = new Cam();
        switch (encounterType)
        {
            case Dungeon.EncounterType.EnemyNormal:
                cam.Battlefield();
                break;

            case Dungeon.EncounterType.EnemyElite:
                cam.Battlefield();
                break;

            case Dungeon.EncounterType.Random:
                cam.Encounter();
                break;

            case Dungeon.EncounterType.Bonfire:
                cam.Encounter();
                break;

            case Dungeon.EncounterType.Treasure:
                cam.Encounter();
                break;
        }
    }

    public void ClickOption(string name)
    {

    }
}
