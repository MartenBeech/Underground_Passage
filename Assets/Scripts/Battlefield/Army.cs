using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Army : MonoBehaviour
{
    List<Champion> champions = new List<Champion>();

    public void RecruitChampion(Champion champion)
    {
        champions.Add(champion);
    }
}
