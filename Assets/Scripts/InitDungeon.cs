using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitDungeon : MonoBehaviour
{
    private void Start()
    {
        Dungeon dungeon = new Dungeon();
        dungeon.Init();
        Explorer explorer = new Explorer();
        explorer.Init();
        Scene scene = new Scene();
        scene.LoadScene(Scene.SceneName.Battlefield);
    }
}
