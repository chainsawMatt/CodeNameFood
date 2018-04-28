using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public static float timer = 300f;
    public static bool timeStarted = true;
    
    void Update()
    {
        if (timeStarted == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                timeStarted = false;
        }
        if (timeStarted == false)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    void OnGUI()
    {

        GUIStyle fontStyle = new GUIStyle();
        fontStyle.normal.textColor = Color.black;
        fontStyle.fontSize = 20;
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        
        GUI.Label(new Rect(450, 10, 250, 100), niceTime, fontStyle);
        
    }
}