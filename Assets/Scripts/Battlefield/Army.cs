using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Army : MonoBehaviour
{
    public static List<Champion> champions = new List<Champion>();

    public void AddChampionToArmy(Champion champion)
    {
        champions.Add(champion);
    }
}
