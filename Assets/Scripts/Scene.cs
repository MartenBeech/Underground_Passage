using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public enum SceneName { Dungeon, Battlefield};
    public void LoadScene(SceneName sceneName)
    {
        SceneManager.LoadScene(sceneName: sceneName.ToString());
    }
}
