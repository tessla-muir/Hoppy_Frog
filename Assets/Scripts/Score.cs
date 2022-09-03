using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Transform doodler;
    public GUIStyle style;

    public float maxHeight = 0;
    public float playerHeight = 0;

    void Update()
    {
        playerHeight = doodler.position.y;

        if (maxHeight < playerHeight) {
            maxHeight = playerHeight;
        }
    }

    void OnGUI() 
    {
        style.fontSize = 25;
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(0, 0, 100, 50), "Max Height: " + maxHeight.ToString(), style);
    }
}
