using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recruit : MonoBehaviour
{
    public enum ChampionTitle { Nunu, Zac, MasterYi, Annie, Karthus}
    private static ChampionTitle[] champions = new ChampionTitle[] { ChampionTitle.Nunu, ChampionTitle.Zac };
    public void SetupRecruit()
    {
        Rng rng = new Rng();
        for (int i = 0; i < Encounter.options.Length; i++)
        {
            int number = rng.Range(0, champions.Length);
            Encounter.options[i].GetComponent<Image>().sprite = Resources.Load<Sprite>($"Champions/{champions[number]}");
            ChampionTitle championTitle = champions[number];
            Encounter.options[i].GetComponent<Button>().onClick.AddListener(() => RecruitChampion(championTitle));
            champions = champions.Where((source, index) => index != number).ToArray();
        }
    }

    public void RecruitChampion(ChampionTitle championTitle)
    {
        ChampionStats championStats = new ChampionStats();
        Champion champion = championStats.GetChamptionStats(championTitle);
        Army army = new Army();
        army.AddChampionToArmy(champion);
        Cam cam = new Cam();
        cam.Dungeon();
    }
}
