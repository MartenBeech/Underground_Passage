using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitBattlefield : MonoBehaviour
{
    private void Start()
    {
        Battlefield bf = new Battlefield();
        bf.Init();
    }
}
