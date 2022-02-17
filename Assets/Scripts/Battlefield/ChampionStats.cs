using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChampionStats : MonoBehaviour
{
    public Champion GetChamptionStats(Recruit.ChampionTitle champtionTitle)
    {
        Champion champion = new Champion();
        switch (champtionTitle)
        {
            case Recruit.ChampionTitle.Nunu:
                champion.title = "Nunu";
                champion.image = Resources.Load<Sprite>($"Champions/{champion.title}");
                champion.attackDamage = 0;
                champion.buffPower = 5;
                champion.spellDamage = 5;
                champion.health = 25;
                champion.speed = 2;
                break;
        }
        return champion;
    }
}
