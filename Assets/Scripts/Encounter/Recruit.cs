using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recruit : MonoBehaviour
{
    public enum Champion { Ashe, Nidalee, Nunu, Zac}
    private static Champion[] champions = new Champion[] { Champion.Ashe, Champion.Nidalee, Champion.Nunu, Champion.Zac };
    public void SetupRecruit()
    {
        Rng rng = new Rng();
        for (int i = 0; i < Encounter.options.Length; i++)
        {
            int number = rng.Range(0, champions.Length);
            Encounter.options[i].GetComponent<Image>().sprite = Resources.Load<Sprite>($"Champions/{champions[number]}");
            champions = champions.Where((source, index) => index != number).ToArray();
        }
    }

    public void RecruitChampion(Champion champion)
    {

    }
}
