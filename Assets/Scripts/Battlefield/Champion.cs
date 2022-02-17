using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Champion : MonoBehaviour
{
    public string title = "";
    public Sprite image = null;
    public int[] pos = new int[2];
    public int attackDamage = 0;
    public int spellDamage = 0;
    public int buffPower = 0;
    public int health = 0;
    public int speed = 0;
}
