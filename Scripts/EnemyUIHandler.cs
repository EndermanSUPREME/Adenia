using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIHandler : MonoBehaviour
{
    Camera MainGameCam;
    Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        MainGameCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        canvas.worldCamera = MainGameCam;
    }
}//EndScript