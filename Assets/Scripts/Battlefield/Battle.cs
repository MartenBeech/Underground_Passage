using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public void StartFormation()
    {
        int[] startingPositionsX = { -3, -1, 1, 3};

        foreach (var champion in Army.champions)
        {
            Rng rng = new Rng();
            int rnd = rng.Range(0, 4);
            champion.pos[0] = startingPositionsX[rnd];
            champion.pos[1] = -3;
            startingPositionsX = startingPositionsX.Where((source, index) => index != rnd).ToArray();
        }
    }
}
